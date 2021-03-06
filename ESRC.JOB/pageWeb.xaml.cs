﻿using System;
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

using mshtml;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;

namespace ESRC.JOB
{
    
    /// <summary>
    /// pageWeb.xaml에 대한 상호 작용 논리
    /// </summary>
    //[PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    //[ComVisibleAttribute(true)]
    public partial class pageWeb : Page
    {
        // This nested class must be ComVisible for the JavaScript to be able to call it.
        [ComVisible(true)]
        public class ScriptManager
        {
            // Variable to store the form of type Form1.
            private pageWeb mForm;

            // Constructor.
            public ScriptManager(pageWeb form)
            {
                // Save the form so it can be referenced later.
                mForm = form;
            }

            // This method can be called from JavaScript.
            public void MethodToCallFromScript(object obj)
            {
                // Call a method on the form.
                mForm.Fn_Call(obj.ToString());
            }

            // This method can also be called from JavaScript.
            public void AnotherMethod(string message)
            {
                MessageBox.Show(message);
            }
        }


        private static string prefixURL = "http://localhost:8099/prj/movie/";
        //private static string prefixURL = "http://www.social-eq.co.kr/movie/";

        public pageWeb()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            //myBrowser.ObjectForScripting = this; // 이 라인이 굉장히 중요!!!
            //myBrowser.ObjectForScripting = new WpfCallObject();
            myBrowser.ObjectForScripting = new ScriptManager(this);

            myBrowser.Navigate(new Uri(prefixURL + "intro.do"));

        }

        private void myBrowser_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            //MessageBox.Show("현재 URL : " + e.Uri.ToString());

            if (e.Uri.ToString() == prefixURL + "audition1.do")
            {
                imgCam.Opacity = 1;
                imgPpg.Opacity = 1;
                txtCam.Opacity = 1;
                txtPpg.Opacity = 1;
            }
            else if (e.Uri.ToString() == prefixURL + "result.do")
            {
                imgCam.Opacity = 0;
                imgPpg.Opacity = 0;
                txtCam.Opacity = 0;
                txtPpg.Opacity = 0;
            }

            if (e.Uri.ToString() == prefixURL + "ot.do")
            {
                mshtml.IHTMLDocument3 document = (mshtml.IHTMLDocument3)myBrowser.Document;
                var user_email = document.getElementsByName("user_email")
                                .OfType<IHTMLElement>()
                                .Select(element => element.getAttribute("value"))
                                .FirstOrDefault();

                MessageBox.Show("현재 사용자 : " + user_email);
            }

        }

        private void myBrowser_Navigated(object sender, NavigationEventArgs e)
        {
            
            


            //var document = myBrowser.Document as mshtml.HTMLDocument;
            //var inputs = document.getElementsByTagName("input");
            //MessageBox.Show(document.title);
            
             
                        
         
        }

        private void Image_Loaded(object sender, RoutedEventArgs e)
        {
            // ... Create a new BitmapImage.
            BitmapImage b = new BitmapImage();
            b.BeginInit();
            b.UriSource = new Uri(@"img\ppg.jpg", UriKind.Relative);
            b.EndInit();

            // ... Get Image reference from sender.
            var image = sender as Image;
            // ... Assign Source.
            image.Source = b;
        }

        private void Image_Loaded_1(object sender, RoutedEventArgs e)
        {
            // ... Create a new BitmapImage.
            BitmapImage b = new BitmapImage();
            b.BeginInit();
            b.UriSource = new Uri(@"img\cam.jpg", UriKind.Relative);
            b.EndInit();

            // ... Get Image reference from sender.
            var image = sender as Image;
            // ... Assign Source.
            image.Source = b;
        }


        public void Fn_Call(object message)
        {
            MessageBox.Show(message.ToString());
        }
        
    }
}
