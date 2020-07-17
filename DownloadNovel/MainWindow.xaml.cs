using GalaSoft.MvvmLight.Command;
using HandyControl.Controls;
using HandyControl.Tools.Extension;
using HandyControl.Data;
using System;
using System.Threading.Tasks;
using System.Windows;
using WebCrawler;
using System.Data;
using Entity;
using Utility;

namespace DownloadNovel
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        string ProcedurePath = AppDomain.CurrentDomain.BaseDirectory;//获取程序所在路径
        public MainWindow()
        {
            InitializeComponent();
            
        }


        Dialog d = null;
        private void SName_SearchStarted(object sender, FunctionEventArgs<string> e)
        {
           
            string name = SName.Text;
            if (string.IsNullOrEmpty(name) || name == "")
            {
                Growl.Warning(new GrowlInfo
                {
                    Message = "请输入内容",
                    WaitTime = 3,
                    ActionBeforeClose = isConfirmed =>
                    {
                        Growl.Info(isConfirmed.ToString());
                        return true;
                    },
                    Token = "SuccessMsg"
                });
                return;
            }
            d = Dialog.Show<ProgressDialog>();
            new Task(() => { Red(name); }).Start();
        }

        private void Red(string name)
        {
            var list = biqudu.GetSearchList(name, ProcedurePath);
            Dispatcher.Invoke(() =>
            {
                d.Close();
                if (list.Count==0)
                {
                    Growl.Error(new GrowlInfo
                    {
                        Message = "骚年，没有搜索到你想要的结果！",
                        WaitTime = 3,
                        Token = "SuccessMsg"
                    });
                }
                NovelListData.ItemsSource = list;
            });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            var a = this.NovelListData.SelectedItem;
            var Info = (NovelList)a;
            d = Dialog.Show<ProgressDialog>();
            new Task(() => {
                RedDetails(Info);
            }).Start();
           

        }
        private void RedDetails(NovelList Info)
        {
            var list = GetDetails(Info) ;
            Dispatcher.Invoke(() =>
            {
                d.Close();
                Dialog.Show(new TextDialog(list));
            });
        }
        private NovelDetails GetDetails(NovelList Info)
        {
            NovelDetails novelDetails = new NovelDetails();
            novelDetails.Name = Info.Name;
            novelDetails.NovelId = Info.NovelId;
            novelDetails.Url = Info.Url;
            novelDetails.Cover = Info.Cover;
            novelDetails.Author = Info.Author;
            var _introduction = biqudu.GetIntroduction(Info.Url);
            string Content = _introduction.Trim();
            Content = Content.Replace("&nbsp;", "");
            novelDetails.Introduction = Content; 
            return novelDetails;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string PathImg = ProcedurePath + "Img/";
            string PathBook = ProcedurePath + "Book/";
            FileHelper.CreateDir(PathImg);
            FileHelper.CreateDir(PathBook);
            FileHelper.DeleteDir(ProcedurePath + "Img/bqd/");
            FileHelper.DeleteDir(ProcedurePath + "Book/");
       
        }

   
    }
}
