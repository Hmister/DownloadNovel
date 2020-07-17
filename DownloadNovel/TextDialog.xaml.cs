using Entity;
using HandyControl.Controls;
using HandyControl.Data;
using System;
using System.Collections.Generic;
using System.IO;
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
        string ProcedurePath = AppDomain.CurrentDomain.BaseDirectory;//获取程序所在路径


        public TextDialog()
        {
            InitializeComponent();
        }

        public static NovelDetails Novel;

        public TextDialog(NovelDetails _Novel) : this()
        {
            Novel = _Novel;
            this.DataContext = Novel;

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Author.Text = "作者：" + Novel.Author;
            Introduction.Text = "简介：" + Novel.Introduction;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(ProcedurePath + "Book/" + Novel.Name + ".txt"))
            {
                Growl.Error(new GrowlInfo
                {
                    Message = "小说已存在，请勿重复操作！",
                    WaitTime = 3,
                    Token = "InfoMsg"
                });
                Btn.IsChecked = false;
                return;
            }

            Btn.IsEnabled = false;
            new Task(() =>
            {
                string Url = $"http://www.biqudu.tv/modules/article/txtarticle.php?id={Novel.NovelId.Split('_')[1]}";
                var status = biqudu.Download(Url, Novel.Name + ".txt", ProcedurePath + "Book/");
                Dispatcher.Invoke(() =>
                {
                    Btn.IsEnabled = true;
                    Btn.IsChecked = false;
                    if (status)
                    {
                        Growl.Ask("下载成功,是否打开文件夹？", isConfirmed =>
                        {
                            if (isConfirmed)
                            {
                                //打开文件夹
                                System.Diagnostics.Process.Start(ProcedurePath + "Book/");
                            }
                            return true;
                        }, "InfoMsg");
                    }
                    else
                    {
                        Growl.Error(new GrowlInfo
                        {
                            Message = "很遗憾，你的网络太差了，失败了！",
                            WaitTime = 3,
                            Token = "InfoMsg"
                        });
                    }
                });

            }).Start();
        }



    }
}
