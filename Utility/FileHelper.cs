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
        /// 创建目录
        /// </summary>
        /// <param name="dir">路径</param>
        public static void CreateDir(string dir)
        {
            if (!Directory.Exists(dir))//如果不存在就创建 dir 文件夹  
                Directory.CreateDirectory(dir);
        }

        public static string DownloadFileImg(string Url, string fileName, string Path)
        {
            WebClient myWebClient = new WebClient();
            try
            {
                CreateDir(Path);
                if (!File.Exists(Path + fileName))
                {
                    myWebClient.DownloadFile(Url, Path + fileName);
                }
                return Path + fileName;
            }
            catch (Exception)
            {
                if (!File.Exists(Path  +"nocover.jpg"))
                {
                    string StrUrl = "http://www.biqudu.tv/modules/article/images/nocover.jpg";
                    myWebClient.DownloadFile(StrUrl, Path + "nocover.jpg");
                }
                return Path + "nocover.jpg";
            }
        }


        public static bool DownloadFile(string Url, string fileName, string Path)
        {
            WebClient myWebClient = new WebClient();
            try
            {
                CreateDir(Path);
                if (!File.Exists(Path + fileName))
                {
                    myWebClient.DownloadFile(Url, Path + fileName);
                }
                return true;
            }
            catch (Exception)
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
    }
}
