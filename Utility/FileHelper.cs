using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public class FileHelper
    {

        /// <summary>
        /// 下载网络文件
        /// </summary>
        /// <param name="Url">请求地址</param>
        /// <param name="fileName">文件名</param>
        /// <param name="Path">路径</param>
        /// <returns></returns>
        public static bool DownloadFile(string Url, string fileName, string Path)
        {
            WebClient myWebClient = new WebClient();
            try
            {
                IsFileCreateDir(Path);
                if (!File.Exists(Path + fileName))
                {
                    myWebClient.DownloadFile(Url, Path + fileName);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        /// <summary>
        /// 清空指定的文件夹，但不删除文件夹
        /// </summary>
        /// <param name="file"></param>
        public static void DeleteDir(string file)
        {

            //去除文件夹和子文件的只读属性
            //去除文件夹的只读属性
            System.IO.DirectoryInfo fileInfo = new DirectoryInfo(file);
            fileInfo.Attributes = FileAttributes.Normal & FileAttributes.Directory;

            //去除文件的只读属性
            System.IO.File.SetAttributes(file, System.IO.FileAttributes.Normal);

            //判断文件夹是否还存在
            if (Directory.Exists(file))
            {
                foreach (string f in Directory.GetFileSystemEntries(file))
                {
                    if (File.Exists(f))
                    {
                        //如果有子文件删除文件
                        File.Delete(f);
                        Console.WriteLine(f);
                    }
                    else
                    {
                        //循环递归删除子文件夹
                        DeleteDir(f);
                    }
                }
                Console.WriteLine(file);
            }
        }

        /// <summary>
        /// 判断文件是否存在
        /// </summary>
        /// <param name="Path"></param>
        /// <returns></returns>
        public static bool IsFileExist(string Path)
        {
            try
            {
                // 判断文件是否存在，没有则创建。
                if (!File.Exists(Path))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 判断文件夹是否存在，不存在就创建
        /// </summary>
        /// <param name="Path"></param>
        public static void IsFileCreateDir(string Path)
        {
            try
            {
                if (!Directory.Exists(Path))//如果不存在就创建 dir 文件夹  
                    Directory.CreateDirectory(Path);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// 根据路径删除文件
        /// </summary>
        /// <param name="path">路径</param>
        /// <returns>是否成功</returns>
        public static bool DeleteFile(string path)
        {
            try
            {
                FileAttributes attr = File.GetAttributes(path);
                if (attr == FileAttributes.Directory)
                {
                    Directory.Delete(path, true);
                }
                else
                {
                    File.Delete(path);
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }



        /// <summary>
        /// 读取JSON文件
        /// </summary>
        /// <param name="key">JSON文件中的key值</param>
        /// <returns>JSON文件中的value值</returns>
        public static string Readjson(string path, string key)
        {
            using (StreamReader file = System.IO.File.OpenText(path))
            {
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    JObject o = (JObject)JToken.ReadFrom(reader);
                    var value = o[key].ToString();
                    return value;
                }
            }
        }
    }
}
