using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace TMSServer
{
    public sealed partial class App : Application
    {
        public App()
        {
            this.InitializeComponent();

            // Enter construction logic here...

            var mainPage = new MainPage();
            Window.Current.Content = mainPage;
        }
        public static bool IsMobile()
        {
            var UserAgent = CSHTML5.Interop.ExecuteJavaScript(@"navigator.userAgent");
            string sUserAgent = UserAgent.ToString().ToLower();
            return (sUserAgent.IndexOf("iphone") != -1 || sUserAgent.IndexOf("android") != -1 || sUserAgent.IndexOf("galaxy") != -1 || sUserAgent.IndexOf("samsung") != -1);
        }
    }
}
