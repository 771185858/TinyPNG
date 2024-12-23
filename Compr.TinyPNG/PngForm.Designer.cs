namespace TinyPNG
{
    partial class PngForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private async void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PngForm));
            folder = new Button();
            files = new Button();
            textSourceConsole = new TextBox();
            textFolder = new TextBox();
            label1 = new Label();
            textResultConsole = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            btnStartCompr = new Button();
            textOutFolder = new TextBox();
            btnOutFolder = new Button();
            labelSumQty = new Label();
            labelFinishQty = new Label();
            labelResidue = new Label();
            labelPercent = new Label();
            label6 = new Label();
            label7 = new Label();
            labelKeyCount = new Label();
            labelComprCount = new Label();
            newDir = new CheckBox();
            newName = new CheckBox();
            SuspendLayout();
            // 
            // folder
            // 
            folder.BackColor = SystemColors.ButtonHighlight;
            folder.ForeColor = SystemColors.MenuText;
            folder.Location = new Point(42, 132);
            folder.Name = "folder";
            folder.Size = new Size(94, 23);
            folder.TabIndex = 0;
            folder.Text = "选择文件夹";
            folder.UseVisualStyleBackColor = false;
            folder.Click += folder_Click;
            // 
            // files
            // 
            files.Location = new Point(42, 94);
            files.Name = "files";
            files.Size = new Size(360, 23);
            files.TabIndex = 1;
            files.Text = "选择图片";
            files.UseVisualStyleBackColor = true;
            files.Click += files_Click;
            // 
            // textSourceConsole
            // 
            textSourceConsole.Location = new Point(42, 172);
            textSourceConsole.Multiline = true;
            textSourceConsole.Name = "textSourceConsole";
            textSourceConsole.ScrollBars = ScrollBars.Both;
            textSourceConsole.Size = new Size(360, 193);
            textSourceConsole.TabIndex = 2;
            // 
            // textFolder
            // 
            textFolder.Location = new Point(142, 132);
            textFolder.Name = "textFolder";
            textFolder.Size = new Size(260, 23);
            textFolder.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(42, 395);
            label1.Name = "label1";
            label1.Size = new Size(44, 17);
            label1.TabIndex = 4;
            label1.Text = "共计：";
            // 
            // textResultConsole
            // 
            textResultConsole.Location = new Point(447, 172);
            textResultConsole.Multiline = true;
            textResultConsole.Name = "textResultConsole";
            textResultConsole.ScrollBars = ScrollBars.Both;
            textResultConsole.Size = new Size(360, 193);
            textResultConsole.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(447, 395);
            label2.Name = "label2";
            label2.Size = new Size(44, 17);
            label2.TabIndex = 6;
            label2.Text = "完成：";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(601, 395);
            label3.Name = "label3";
            label3.Size = new Size(44, 17);
            label3.TabIndex = 7;
            label3.Text = "剩余：";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(738, 395);
            label4.Name = "label4";
            label4.Size = new Size(44, 17);
            label4.TabIndex = 8;
            label4.Text = "占比：";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial Rounded MT Bold", 24F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(347, 31);
            label5.Name = "label5";
            label5.Size = new Size(152, 37);
            label5.TabIndex = 9;
            label5.Text = "TinyPNG";
            // 
            // btnStartCompr
            // 
            btnStartCompr.Location = new Point(447, 94);
            btnStartCompr.Name = "btnStartCompr";
            btnStartCompr.Size = new Size(360, 23);
            btnStartCompr.TabIndex = 10;
            btnStartCompr.Text = "开始压缩";
            btnStartCompr.UseVisualStyleBackColor = true;
            btnStartCompr.Click += btnStartCompr_Click;
            // 
            // textOutFolder
            // 
            textOutFolder.Location = new Point(651, 132);
            textOutFolder.Name = "textOutFolder";
            textOutFolder.Size = new Size(156, 23);
            textOutFolder.TabIndex = 11;
            // 
            // btnOutFolder
            // 
            btnOutFolder.Location = new Point(578, 132);
            btnOutFolder.Name = "btnOutFolder";
            btnOutFolder.Size = new Size(67, 23);
            btnOutFolder.TabIndex = 12;
            btnOutFolder.Text = "输出目录";
            btnOutFolder.UseVisualStyleBackColor = true;
            btnOutFolder.Click += btnOutFolder_Click;
            // 
            // labelSumQty
            // 
            labelSumQty.AutoSize = true;
            labelSumQty.Location = new Point(78, 395);
            labelSumQty.Name = "labelSumQty";
            labelSumQty.Size = new Size(15, 17);
            labelSumQty.TabIndex = 13;
            labelSumQty.Text = "0";
            // 
            // labelFinishQty
            // 
            labelFinishQty.AutoSize = true;
            labelFinishQty.Location = new Point(484, 395);
            labelFinishQty.Name = "labelFinishQty";
            labelFinishQty.Size = new Size(15, 17);
            labelFinishQty.TabIndex = 14;
            labelFinishQty.Text = "0";
            // 
            // labelResidue
            // 
            labelResidue.AutoSize = true;
            labelResidue.Location = new Point(637, 395);
            labelResidue.Name = "labelResidue";
            labelResidue.Size = new Size(15, 17);
            labelResidue.TabIndex = 15;
            labelResidue.Text = "0";
            // 
            // labelPercent
            // 
            labelPercent.AutoSize = true;
            labelPercent.Location = new Point(775, 395);
            labelPercent.Name = "labelPercent";
            labelPercent.Size = new Size(26, 17);
            labelPercent.TabIndex = 16;
            labelPercent.Text = "0%";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = SystemColors.ControlDarkDark;
            label6.Location = new Point(42, 19);
            label6.Name = "label6";
            label6.Size = new Size(92, 17);
            label6.TabIndex = 17;
            label6.Text = "密钥可用数量：";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = SystemColors.ControlDarkDark;
            label7.Location = new Point(187, 19);
            label7.Name = "label7";
            label7.Size = new Size(80, 17);
            label7.TabIndex = 18;
            label7.Text = "可压缩数量：";
            // 
            // labelKeyCount
            // 
            labelKeyCount.AutoSize = true;
            labelKeyCount.ForeColor = SystemColors.ControlDarkDark;
            labelKeyCount.Location = new Point(129, 20);
            labelKeyCount.Name = "labelKeyCount";
            labelKeyCount.Size = new Size(15, 17);
            labelKeyCount.TabIndex = 19;
            labelKeyCount.Text = "0";
            // 
            // labelComprCount
            // 
            labelComprCount.AutoSize = true;
            labelComprCount.ForeColor = SystemColors.ControlDarkDark;
            labelComprCount.Location = new Point(261, 20);
            labelComprCount.Name = "labelComprCount";
            labelComprCount.Size = new Size(15, 17);
            labelComprCount.TabIndex = 20;
            labelComprCount.Text = "0";
            // 
            // newDir
            // 
            newDir.AutoSize = true;
            newDir.Location = new Point(447, 134);
            newDir.Name = "newDir";
            newDir.Size = new Size(63, 21);
            newDir.TabIndex = 21;
            newDir.Text = "新目录";
            newDir.UseVisualStyleBackColor = true;
            newDir.CheckedChanged += newDir_CheckedChanged;
            // 
            // newName
            // 
            newName.AutoSize = true;
            newName.Location = new Point(516, 134);
            newName.Name = "newName";
            newName.Size = new Size(63, 21);
            newName.TabIndex = 22;
            newName.Text = "新名字";
            newName.UseVisualStyleBackColor = true;
            newName.CheckedChanged += newName_CheckedChanged;
            // 
            // PngForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(852, 450);
            Controls.Add(newName);
            Controls.Add(newDir);
            Controls.Add(labelComprCount);
            Controls.Add(labelKeyCount);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(labelPercent);
            Controls.Add(labelResidue);
            Controls.Add(labelFinishQty);
            Controls.Add(labelSumQty);
            Controls.Add(btnOutFolder);
            Controls.Add(textOutFolder);
            Controls.Add(btnStartCompr);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textResultConsole);
            Controls.Add(label1);
            Controls.Add(textFolder);
            Controls.Add(textSourceConsole);
            Controls.Add(files);
            Controls.Add(folder);
            Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "PngForm";
            Text = "TinyPNG";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button folder;
        private Button files;
        private TextBox textSourceConsole;
        private TextBox textFolder;
        private Label label1;
        private TextBox textResultConsole;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button btnStartCompr;
        private TextBox textOutFolder;
        private Button btnOutFolder;
        private Label labelSumQty;
        private Label labelFinishQty;
        private Label labelResidue;
        private Label labelPercent;
        private Label label6;
        private Label label7;
        private Label labelKeyCount;
        private Label labelComprCount;
        private CheckBox newDir;
        private CheckBox newName;
    }
}