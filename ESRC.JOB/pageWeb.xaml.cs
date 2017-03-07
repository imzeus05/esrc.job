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

namespace ESRC.JOB
{
    /// <summary>
    /// pageWeb.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class pageWeb : Page
    {
        public pageWeb()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Maximized;
            myBrowser.Navigate(new Uri("http://www.social-eq.co.kr/movie/login.do"));
        }

        private void myBrowser_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            MessageBox.Show("현재 URL : " + e.Uri.ToString());

            if (e.Uri.ToString() == "http://www.social-eq.co.kr/movie/testft_start.do")
            {
                NavigationService.Navigate(new Uri("pageLocal.xaml", UriKind.Relative));
            }
        }
    }
}
