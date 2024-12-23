using Compr.TinyPNG;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TinyPng;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TinyPNG
{
    public partial class PngForm : Form
    {
        private readonly Dictionary<string, int> keys = new();

        public PngForm()
        {
            InitializeComponent();
            GetApiKey();
            CompressionCount();
        }

        /// <summary>
        /// 获取API_KEY
        /// 注册地址https://tinify.com/developers
        /// </summary>
        private void GetApiKey()
        {
            string filePath = Path.Combine(AppContext.BaseDirectory, "api_key.txt");
            if (File.Exists(filePath))
            {
                Console.WriteLine("api_key.txt 文件已存在，读取内容：");

                // 逐行读取文件内容
                foreach (var line in File.ReadLines(filePath))
                {
                    if (!line.Contains("tinify.com"))
                    {
                        keys[line.Trim()] = 0;
                    }
                }
            }
            else
            {
                // 创建文件并写入初始内容
                File.WriteAllText(filePath, "你应从https://tinify.com/developers获取API_KEY并填入到这里（每一行代表一个API_KEY，可多个）");
            }
        }

        /// <summary>
        /// 选择文件夹
        /// </summary>
        private void folder_Click(object sender, EventArgs e)
        {
            using var path = new FolderBrowserDialog();
            if (path.ShowDialog() == DialogResult.OK)
            {
                textFolder.Text = path.SelectedPath;
                ReadImages(path.SelectedPath);
                SetOutputFolder(path.SelectedPath);
            }
        }

        /// <summary>
        /// 设置输出文件夹
        /// </summary>
        private void SetOutputFolder(string inPath)
        {
            if (File.Exists(inPath))
            {
                inPath = Path.GetDirectoryName(inPath);
            }
            //新目录
            if (newDir.Checked)
            {
                inPath += "-TinyPNG";
            }
            textOutFolder.Text = inPath;
            textOutFolder.SelectionStart = textOutFolder.Text.Length;
            textOutFolder.ScrollToCaret();
        }

        /// <summary>
        /// 读取图片到控制台输出
        /// </summary>
        private void ReadImages(string path)
        {
            if (string.IsNullOrEmpty(path)) return;

            var dir = new DirectoryInfo(path);

            if (!dir.Exists) return;

            textSourceConsole.Clear();
            labelSumQty.Text = "0";

            var fsinfos = dir.GetFiles();
            int index = 0;

            foreach (var fsinfo in fsinfos)
            {
                string ext = Path.GetExtension(fsinfo.Name).ToLower();
                const string imgexts = ".jpg,.jpeg,.png,.webp";
                if (!imgexts.Contains(ext)) continue;
                textSourceConsole.AppendText(fsinfo.FullName + Environment.NewLine);
                index++;
            }
            labelSumQty.Text = index.ToString();
        }

        /// <summary>
        /// 选择图片
        /// </summary>
        private void files_Click(object sender, EventArgs e)
        {
            using var dialog = new OpenFileDialog
            {
                Multiselect = true,
                Title = "请选择图片",
                Filter = "图片文件(*.jpg,*.jpeg,*.png,*.webp)|*.jpg;*.jpeg;*.png;*.webp"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textSourceConsole.Clear();
                textFolder.Clear();
                labelSumQty.Text = "0";

                foreach (var fileName in dialog.FileNames)
                {
                    textSourceConsole.AppendText(fileName + Environment.NewLine);
                }

                labelSumQty.Text = dialog.FileNames.Length.ToString();
                SetOutputFolder(dialog.FileNames.First());
            }
        }

        /// <summary>
        /// 输入目录选择
        /// </summary>
        private void btnOutFolder_Click(object sender, EventArgs e)
        {
            using var path = new FolderBrowserDialog();
            if (path.ShowDialog() == DialogResult.OK)
            {
                textOutFolder.Text = path.SelectedPath;
            }
        }

        /// <summary>
        /// 开始压缩
        /// </summary>
        private void btnStartCompr_Click(object sender, EventArgs e)
        {
            var textSourceConsole = this.textSourceConsole.Text;
            if (string.IsNullOrEmpty(textSourceConsole))
            {
                MessageBox.Show("请选择图片");
                return;
            }
            var textOutFolder = this.textOutFolder.Text;
            if (string.IsNullOrEmpty(textOutFolder))
            {
                MessageBox.Show("请选择输出目录");
                return;
            }

            labelFinishQty.Text = "0";
            labelResidue.Text = labelSumQty.Text;
            labelPercent.Text = "0%";
            textResultConsole.Clear();

            var inPaths = textSourceConsole.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            if (!Directory.Exists(textOutFolder))
            {
                Directory.CreateDirectory(textOutFolder);
            }

            btnStartCompr.Text = "压缩中 ……";
            btnStartCompr.Enabled = false;

            while (inPaths.Any())
            {
                string key = "";
                var tinyPng = GetTinyPngClient(ref key);
                if (tinyPng == null) return;

                var availableQty = keys[key];
                var availablePaths = inPaths.Take(availableQty).ToArray();
                var residuePaths = inPaths.Skip(availableQty).ToArray();

                CompressImages(tinyPng, availablePaths, textOutFolder);

                inPaths = residuePaths;
                keys[key] -= availablePaths.Length;

                labelKeyCount.Text = keys.Count(x => x.Value > 0).ToString();
                labelComprCount.Text = keys.Where(x => x.Value > 0).Sum(x => x.Value).ToString();
            }
        }

        /// <summary>
        /// 设置完成数
        /// </summary>
        private void SetFinishQty(string fileName)
        {
            var sumQty = Convert.ToDecimal(labelSumQty.Text);
            var finishQty = Convert.ToDecimal(labelFinishQty.Text);

            labelFinishQty.Text = (finishQty + 1).ToString();
            labelResidue.Text = (sumQty - (finishQty + 1)).ToString();

            decimal percent = Math.Round((finishQty + 1) / sumQty * 100, 1);
            labelPercent.Text = percent + "%";

            textResultConsole.AppendText(fileName + Environment.NewLine);

            if (percent >= 100)
            {
                btnStartCompr.Text = "开始压缩";
                btnStartCompr.Enabled = true;
            }
        }

        /// <summary>
        /// TinyPng图片压缩
        /// </summary>
        private void CompressImages(TinyPngClient tinyPng, string[] inPaths, string outPath)
        {
            foreach (var path in inPaths)
            {
                Task.Run(async () =>
                {
                    try
                    {
                        var result = await tinyPng.Compress(path).ConfigureAwait(false);
                        var name = Path.GetFileNameWithoutExtension(path);
                        var extension = Path.GetExtension(path);
                        if (!string.IsNullOrEmpty(result.Output.Url))
                        {
                            if (newName.Checked)
                            {
                                name += "-TinyPNG";
                            }
                            var outputPath = Path.Combine(outPath, name + extension);
                            await result.Download().SaveImageToDisk(outputPath).ConfigureAwait(false);
                            Invoke(new Action(() => SetFinishQty(outputPath)));
                        }
                    }
                    catch (Exception ex)
                    {
                        textResultConsole.AppendText($"Error processing {path}: {ex.Message}" + Environment.NewLine);
                    }
                });
            }
        }

        /// <summary>
        /// 获取TinyPng客户端
        /// </summary>
        private TinyPngClient GetTinyPngClient(ref string key)
        {
            foreach (var item in keys)
            {
                if (item.Value > 0)
                {
                    key = item.Key;
                    return new TinyPngClient(item.Key);
                }
            }
            MessageBox.Show("没有可用的Key了，下个月再来吧");
            btnStartCompr.Text = "开始压缩";
            btnStartCompr.Enabled = true;
            return null;
        }

        /// <summary>
        /// 验证Key&压缩使用数量
        /// </summary>
        private int VerifyKeyUseCount(string key)
        {
            var headers = new Dictionary<string, string>
            {
                { "Authorization", "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes(key)) }
            };
            var result = HttpUtils.HttpPost("https://api.tinify.com/shrink", "", "application/json", 30, headers);
            if (!Regex.IsMatch(result, @"^\d+$"))
            {
                textSourceConsole.HandleCreated += (s, e) =>
                {
                    textSourceConsole.Invoke(new Action(() =>
                    {
                        textSourceConsole.AppendText($"无效的API_KEY：{key}{Environment.NewLine}");
                        textSourceConsole.AppendText($"{result}{Environment.NewLine}");
                    }));
                };
                return 500;
            }
            return Convert.ToInt32(result);
        }

        /// <summary>
        /// API_KEY压缩剩余计数
        /// </summary>
        private void CompressionCount()
        {
            int totalQty = 0;
            Parallel.ForEach(keys.Keys.ToList(), key =>
            {
                var count = VerifyKeyUseCount(key);
                keys[key] = 500 - count;
                totalQty += 500 - count;
            });
            labelKeyCount.Text = keys.Count(x => x.Value > 0).ToString();
            labelComprCount.Text = totalQty.ToString();
        }

        /// <summary>
        /// 选择新目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newDir_CheckedChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textOutFolder.Text) && newDir.Checked)
            {
                textOutFolder.Text += "-TinyPNG";
            }
            else
            {
                textOutFolder.Text = textOutFolder.Text.Replace("-TinyPNG", "");
            }
            textOutFolder.SelectionStart = textOutFolder.Text.Length;
            textOutFolder.ScrollToCaret();
        }

        /// <summary>
        /// 选择新名字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newName_CheckedChanged(object sender, EventArgs e)
        {
            //使用文件名字新名称事件
        }
    }
}
