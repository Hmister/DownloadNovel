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
    }
}
