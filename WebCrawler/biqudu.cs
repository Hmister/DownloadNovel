using Entity;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebCrawler
{
    public class biqudu
    {
        public static List<NovelList> GetSearchList(string Name = "凡人修仙传")
        {
            List<NovelList> novelLists = new List<NovelList>();
            string url = "http://www.biqudu.tv/s.php?q=" + Name;
            HtmlWeb web = new HtmlWeb();
            web.OverrideEncoding = Encoding.GetEncoding("utf-8");
            //从url中加载
            HtmlDocument doc = web.Load(url);
            //获得title标签节点，其子标签下的所有节点也在其中
            HtmlNode headNode = doc.DocumentNode.SelectSingleNode("//title");
            //获得title标签中的内容
            string Title = headNode.InnerText;
            Console.WriteLine(Title);
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
                novelList.Cover = $"http://www.biqudu.tv/files/article/image/{idArr[0]}/{idArr[1]}/{idArr[1]}s.jpg";
                // Console.WriteLine(Author);
                i++;
                novelLists.Add(novelList);
            }
            return novelLists;
        }

    }
}
