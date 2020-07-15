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
                NovelListData.ItemsSource = list;
            });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            var a = this.NovelListData.SelectedItem;
            var Info = (NovelList)a;
            //Console.WriteLine(Info.Author);
            Dialog.Show(new TextDialog(Info));

        }

    }
}
