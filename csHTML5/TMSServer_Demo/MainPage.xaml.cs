using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace TMSServer
{
    public partial class MainPage : Page
    {
        public string Pwd = "";
        public List<double> m_lstMaxNOX      = new List<double>();
        public List<double> m_lstMaxCO       = new List<double>();
        public List<double> m_lstMaxCO2      = new List<double>();
        public List<double> m_lstMaxFineDust1_0 = new List<double>();
        public List<double> m_lstMaxFineDust2_5 = new List<double>();
        public List<double> m_lstMaxFineDust10  = new List<double>();

        public MainPage()
        {
            this.InitializeComponent();

            var UserAgent = CSHTML5.Interop.ExecuteJavaScript(@"navigator.userAgent");
            string sUserAgent = UserAgent.ToString();
            sUserAgent = sUserAgent.ToLower();
            bool bMobile = (sUserAgent.IndexOf("iphone") != -1 || sUserAgent.IndexOf("android") != -1 || sUserAgent.IndexOf("galaxy") != -1 || sUserAgent.IndexOf("samsung") != -1);

            if (bMobile)
            {
                m_Container.Children.Clear();
                m_Container.Children.Add(new ucLogin());
            }
            else
            {
                m_Container.Children.Clear();
                m_Container.Children.Add(new ucLogin());
            }
        }
        public void ScrollEnable(bool bAuto)
        {
            if( bAuto )
                m_scMain.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
            else
                m_scMain.VerticalScrollBarVisibility = ScrollBarVisibility.Disabled;
        }


        public void ChangeMain(UserControl ucCtrl)
        {
            try
            {
                m_Container.Children.Clear();
                m_Container.Children.Add(ucCtrl);
            }
            catch (System.Exception ex)
            {
            }
        }


    }
}
