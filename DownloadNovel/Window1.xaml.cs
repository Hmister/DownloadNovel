using GalaSoft.MvvmLight.Command;
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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace DownloadNovel
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : System.Windows.Window
    {
        public RelayCommand SendNotificationCmd => new Lazy<RelayCommand>(() =>
           new RelayCommand(SendNotification)).Value;

        private bool _contextMenuIsShow;
  
        private readonly DispatcherTimer _timer;
        public Window1()
        {
            InitializeComponent();
            DataContext = this;

        }
        private void SendNotification()
        {
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NotifyIcon.ShowBalloonTip("DownloadNovel", "来了，老弟儿~", NotifyIconInfoType.None, "mess");
        }
    }
}
