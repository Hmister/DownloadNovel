using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WebCrawler;

namespace DownloadNovel
{
    /// <summary>
    /// ReadOnline.xaml 的交互逻辑
    /// </summary>
    public partial class ReadOnline : Window
    {
        public ReadOnline()
        {
            InitializeComponent();
        }

        public static ChapterInfo ChapterInfo;
        public ReadOnline(ChapterInfo _chapterInfo) : this()
        {
            ChapterInfo = _chapterInfo;
        }


        private void GetChapter(string Url)
        {
            ChapterInfo Nrs = biqudu.GetContent(Url);
            string Content = "获取失败。。。";
            if (Nrs != null)
            {
                zj.Content = Nrs.Name;
                Content = Nrs.Content;
            }
            nr.Inlines.Clear();
            nr.Inlines.Add(new Run(Content));

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GetChapter("http://www.biqudu.tv/16_16017/9609574.html");
        }
    }
}
