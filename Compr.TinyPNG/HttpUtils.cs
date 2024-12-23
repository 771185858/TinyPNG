using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Compr.TinyPNG;

public class HttpUtils
{
    /// <summary>
    /// 发起POST同步请求
    /// 
    /// </summary>
    /// <param name="url"></param>
    /// <param name="postData"></param>
    /// <param name="contentType">application/xml、application/json、application/text、application/x-www-form-urlencoded</param>
    /// <param name="headers">填充消息头</param>        
    /// <returns></returns>
    public static string HttpPost(string url, string postData = null, string contentType = null, int timeOut = 30, Dictionary<string, string> headers = null)
    {
        postData ??= "";
        var httpclientHandler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (message, cert, chain, error) => true
        };
        using var client = new HttpClient(httpclientHandler);
        client.Timeout = new TimeSpan(0, 0, timeOut);
        if (headers != null)
        {
            foreach (var (key, value) in headers)
                client.DefaultRequestHeaders.Add(key, value);
        }

        using HttpContent httpContent = new StringContent(postData, Encoding.UTF8);
        if (contentType != null)
        {
            httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(contentType);
            var data = Encoding.UTF8.GetBytes(postData);
            httpContent.Headers.ContentLength = data.Length;
        }

        var response = client.PostAsync(url, httpContent).Result;
        try
        {
            var count = response.Headers.GetValues("Compression-Count").ToArray()[0];
            return count;
        }
        catch (Exception)
        {
            return response.ToString();
        }
    }
}