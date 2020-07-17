using Entity;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace WebCrawler
{
    public class biqudu
    {
        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Path"></param>
        /// <returns></returns>
        public static List<NovelList> GetSearchList(string Name = "凡人修仙传", string Path = "")
        {
            List<NovelList> novelLists = new List<NovelList>();
            string url = "http://www.biqudu.tv/s.php?q=" + Name;
            HtmlWeb web = new HtmlWeb();
            web.OverrideEncoding = Encoding.GetEncoding("utf-8");
            //从url中加载
            HtmlDocument doc = web.Load(url);
            try
            {
                var allList = doc.DocumentNode.SelectNodes("//*[@id='nr']").ToList();
                int i = 1;
                foreach (var item in allList)
                {
                    NovelList novelList = new NovelList();
                    HtmlDocument adoc = new HtmlDocument();
                    adoc.LoadHtml(item.InnerHtml);
                    var List = adoc.DocumentNode.SelectNodes("//td").ToList();
                    novelList.Id = i;
                    novelList.Name = List[0].SelectSingleNode("//*[@class='odd']/a").InnerText;
                    novelList.Url = List[0].SelectSingleNode("//*[@class='odd']/a").Attributes["href"].Value;
                    novelList.LastChapter = List[1].InnerText;
                    novelList.Author = List[2].InnerText;
                    novelList.Number = List[3].InnerText;
                    novelList.UpdateTime = List[4].InnerText;
                    novelList.Status = List[5].InnerText;
                    novelList.NovelId = novelList.Url.Split('/')[3];
                    var idArr = novelList.NovelId.Split('_');
                    string ImgUrl = $"http://www.biqudu.tv/files/article/image/{idArr[0]}/{idArr[1]}/{idArr[1]}s.jpg";
                    novelList.Cover = DownloadFileImg(ImgUrl, $"{idArr[1]}s.jpg", Path + "Img/bqd/");
                    i++;
                    novelLists.Add(novelList);
                }
                return novelLists;
            }
            catch (Exception)
            {
                return novelLists;
            }

        }

        /// <summary>
        /// 获取简介
        /// </summary>
        /// <param name="Url"></param>
        /// <returns></returns>
        public static string GetIntroduction(string Url)
        {
            List<NovelList> novelLists = new List<NovelList>();
            HtmlWeb web = new HtmlWeb();
            web.OverrideEncoding = Encoding.GetEncoding("utf-8");
            //从url中加载
            HtmlDocument doc = web.Load(Url);
            //获得title标签节点，其子标签下的所有节点也在其中
            HtmlNode headNode = doc.DocumentNode.SelectSingleNode("//*[@id='intro']/p");
            //获得title标签中的内容
            string Introduction = headNode.InnerText;
            Console.WriteLine(Introduction);
            return Introduction;
        }

        /// <summary>
        /// 下载网络图片到本地
        /// </summary>
        /// <param name="UrlIng"></param>
        /// <param name="FileName"></param>
        /// <param name="Path"></param>
        /// <returns></returns>
        public static string DownloadFileImg(string UrlIng, string FileName, string Path)
        {
            string PathImg = Path + FileName;
            if (FileHelper.IsFileExist(PathImg))
                return PathImg;

            bool Status = FileHelper.DownloadFile(UrlIng, FileName, Path);
            if (Status)
            {
                return PathImg;
            }
            else
            {
                if (FileHelper.IsFileExist(Path + "nocover.jpg"))
                    return Path + "nocover.jpg";

                string StrUrl = "http://www.biqudu.tv/modules/article/images/nocover.jpg";
                FileHelper.DownloadFile(StrUrl, "nocover.jpg", Path);
                return Path + "nocover.jpg";
            }
        }

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="Url">网络地址</param>
        /// <param name="Name">名称</param>
        /// <param name="Path">需要存储的路径</param>
        /// <returns></returns>
        public static bool Download(string Url, string Name, string Path)
        {
            return FileHelper.DownloadFile(Url, Name, Path);
        }


        public static ChapterInfo GetContent(string Url = "http://www.biqudu.tv/15_15998/9600071.html")
        {
            ChapterInfo chapterInfo = new ChapterInfo();
            try
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.GetEncoding("utf-8");
                //从url中加载
                HtmlDocument doc = web.Load(Url);
                HtmlNode node = doc.DocumentNode.SelectSingleNode("//*[@id='content']");     //根据XPath查找节点，跟XmlNode差不多
                string chapterName = "/html/body/div[@id='wrapper']/div[@class='content_read']/div[@class='box_con']/div[@class='bookname']/h1";
                string Last = "/html/body/div[@id='wrapper']/div[@class='content_read']/div[@class='box_con']/div[@class='bookname']/div[@class='bottem1']/a[4]";
                string Previous = "/html/body/div[@id='wrapper']/div[@class='content_read']/div[@class='box_con']/div[@class='bookname']/div[@class='bottem1']/a[2]";
                chapterInfo.Content = node.InnerText.Trim().Replace("\r\n", "").Replace("&nbsp;", " ");
                HtmlNode nodes = doc.DocumentNode.SelectSingleNode(chapterName);     //根据XPath查找节点，跟XmlNode差不多
                chapterInfo.Name = nodes.InnerText;
                HtmlNode nodeLast = doc.DocumentNode.SelectSingleNode(Last);     //根据XPath查找节点，跟XmlNode差不多
                chapterInfo.LastUrl = "http://www.biqudu.tv" + nodeLast.Attributes["href"].Value;
                HtmlNode nodePrevious = doc.DocumentNode.SelectSingleNode(Previous);     //根据XPath查找节点，跟XmlNode差不多
                chapterInfo.PreviousUrl = "http://www.biqudu.tv" + nodePrevious.Attributes["href"].Value;
                return chapterInfo;
            }
            catch (Exception)
            {
                return chapterInfo;
            }

        }

    }
}
