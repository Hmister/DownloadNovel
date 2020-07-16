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
    public partial class Window1 : Window
    {

        public static readonly DependencyProperty ProgressProperty = DependencyProperty.Register(
            "Progress", typeof(int), typeof(Window1), new PropertyMetadata(default(int)));

        public int Progress
        {
            get => (int)GetValue(ProgressProperty);
            set => SetValue(ProgressProperty, value);
        }

        public static readonly DependencyProperty IsUploadingProperty = DependencyProperty.Register(
            "IsUploading", typeof(bool), typeof(Window1), new PropertyMetadata(default(bool)));

        public bool IsUploading
        {
            get => (bool)GetValue(IsUploadingProperty);
            set => SetValue(IsUploadingProperty, value);
        }

        private readonly DispatcherTimer _timer;
        public Window1()
        {
            InitializeComponent();
            DataContext = this;

            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(200)
            };
            _timer.Tick += Timer_Tick;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            Progress++;
            if (Progress == 100)
            {
                Progress = 0;
                _timer.Stop();
                IsUploading = false;
            }
        }
        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            //IsUploading = true;
        }
    }
}
