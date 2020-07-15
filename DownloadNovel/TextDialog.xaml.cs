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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WebCrawler;

namespace DownloadNovel
{
    /// <summary>
    /// TextDialog.xaml 的交互逻辑
    /// </summary>
    public partial class TextDialog : UserControl
    {
        public TextDialog()
        {
            InitializeComponent();
        }

        public static NovelList Novel;

        public TextDialog(NovelList _Novel) :this ()
        {
            Novel = _Novel;
            this.DataContext = Novel;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
           var _introduction= biqudu.GetIntroduction(Novel.Url);
            string Content = _introduction.Trim();
            Content = Content.Replace("&nbsp;", "");
            Introduction.Text = Content;
        }

       
    }
}
