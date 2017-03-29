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

using System.Windows.Navigation;


namespace ESRC.JOB
{
    /// <summary>
    /// Main.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class winMain : NavigationWindow
    {
        public winMain()
        {
            InitializeComponent();
            //this.ShowsNavigationUI = false;
            //this.ResizeMode = ResizeMode.NoResize;

            //Uri iconUri = new Uri(@"pack://application:img\favicon.ico", UriKind.RelativeOrAbsolute);
            //this.Icon = BitmapFrame.Create(iconUri);

        }
    }
}
