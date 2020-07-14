using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public class HttpPostHelper
    {

        /// <summary>
        /// post请求不带Token
        /// </summary>
        /// <param name="url"></param>
        /// <param name="dic"></param>
        /// <returns></returns>
        public static string Post(string url, Dictionary<string, string> dic)
        {
            string result = "";
            try
            {
                //添加Post 参数
                System.Text.StringBuilder builder = new System.Text.StringBuilder();
                int i = 0;
                foreach (var item in dic)
                {
                    if (i > 0)
                        builder.Append("&");
                    builder.AppendFormat("{0}={1}", item.Key, item.Value);
                    i++;
                }
                byte[] postData = System.Text.Encoding.UTF8.GetBytes(builder.ToString());

                System.Net.HttpWebRequest _webRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
                _webRequest.Method = "POST";
                //_webRequest.ContentType = "application/json";
                //内容类型  
                _webRequest.ContentType = "application/x-www-form-urlencoded";
                _webRequest.Timeout = 1000 * 30;
                _webRequest.ContentLength = postData.Length;

                using (System.IO.Stream reqStream = _webRequest.GetRequestStream())
                {
                    reqStream.Write(postData, 0, postData.Length);
                    reqStream.Close();
                }
                System.Net.HttpWebResponse resp = (System.Net.HttpWebResponse)_webRequest.GetResponse();
                System.IO.Stream stream = resp.GetResponseStream();
                //获取响应内容
                using (System.IO.StreamReader reader = new System.IO.StreamReader(stream, System.Text.Encoding.UTF8))
                {
                    result = reader.ReadToEnd();
                }
                return result;
            }
            catch (Exception)
            {
                return "";
            }

        }

        /// <summary>
        /// Get请求
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GetFunction(string url)
        {
            try
            {
                string serviceAddress = url;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(serviceAddress);
                request.Method = "GET";
                request.ContentType = "text/html;charset=UTF-8";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream myResponseStream = response.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
                string retString = myStreamReader.ReadToEnd();
                myStreamReader.Close();
                myResponseStream.Close();
                return retString;
            }
            catch (Exception)
            {
                return "";
            }
        }


        /// <summary>
        /// Get HttpClient方式
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="timeOut">参数</param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static string GetClient(string url, string token = "", int timeOut = 30)
        {
            string result = string.Empty;
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    if (token != "")
                    {
                        httpClient.Timeout = new TimeSpan(0, 0, timeOut);
                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    }
                    httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = httpClient.GetAsync(url).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        result = response.Content.ReadAsStringAsync().Result;
                    }
                }
                return result;
            }
            catch (Exception)
            {
                return "";
            }
        }


        /// <summary>
        /// Post HttpClient方式
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="dic">参数</param>
        /// <param name="timeOut">超时时间</param>
        /// <param name="token">Token</param>
        /// <returns></returns>
        public static string PostClient(string url, Dictionary<string, string> dic, string token = "", int timeOut = 20)
        {
            string result = string.Empty;
            try
            {
                //设置Http的正文
                var encodedContent = new FormUrlEncodedContent(dic);
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.Timeout = new TimeSpan(0, 0, timeOut);
                    if (token != "")
                    {
                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    }
                    //异步Post
                    HttpResponseMessage response = httpClient.PostAsync(url, encodedContent).Result;
                    //确保Http响应成功
                    if (response.IsSuccessStatusCode)
                    {
                        //异步读取json
                        result = response.Content.ReadAsStringAsync().Result;
                    }
                }
                return result;
            }
            catch (Exception)
            {
                return "";
            }
        }


    }
}
