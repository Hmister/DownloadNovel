using GalaSoft.MvvmLight.Messaging;
using HandyControl.Controls;
using HandyControl.Data;
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
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //
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
            d =  Dialog.Show<ProgressDialog>();

            new Task(() => { Red(name); }).Start();
        }

        private void Red(string name)
        {
            var list = biqudu.GetSearchList(name);
          
            Dispatcher.Invoke(() =>
            {
                d.Close();
                NovelListData.ItemsSource = list;
            });
        }
    }
}
