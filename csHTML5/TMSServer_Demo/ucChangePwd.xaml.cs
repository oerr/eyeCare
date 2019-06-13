using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace TMSServer
{
    public partial class ucChangePwd : UserControl
    {
        public ucChangePwd()
        {
            this.InitializeComponent();

            this.m_ucBtnOK.ImgSrc = "ms-appx:/Img/Button_01.png";
            this.m_ucBtnOK.TextColor = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 255, 255, 255));
            this.m_ucBtnOK.EvtClicked += m_ucBtnOK_EvtClicked;

            this.m_ucBtnCancel.ImgSrc = "ms-appx:/Img/Button_02.png";
            this.m_ucBtnCancel.TextColor = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 255, 255, 255));
            this.m_ucBtnCancel.EvtClicked += m_ucBtnCancel_EvtClicked;

            this.SizeChanged += ucChangePwd_SizeChanged;
            this.Loaded += ucChangePwd_Loaded;
        }

        void ucChangePwd_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateLayout();

        }

        void ucChangePwd_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdateLayout();
        }
        public void UpdateLayout()
        {
            if (App.IsMobile())
            {
                // PC에서는 윈도우 사이즈가 조절되어 상관 없음
                double dwWidth = Convert.ToDouble(CSHTML5.Interop.ExecuteJavaScript("window.innerWidth"));
                if (this.MinWidth <= 0 || dwWidth < this.MinWidth)
                    this.MinWidth = dwWidth;
            }
            double dwHeight = Convert.ToDouble(CSHTML5.Interop.ExecuteJavaScript("window.innerHeight"));
            if (this.MinHeight <= 0 || dwHeight < this.MinHeight)
                this.MinHeight = dwHeight;

            MainPage MainPage = (MainPage)Window.Current.Content;
            MainPage.ScrollEnable(true);
        }
        void m_ucBtnCancel_EvtClicked(object sender, ButtonArgs e)
        {
            MainPage MainPage = Window.Current.Content as MainPage;
            MainPage.ChangeMain(new ucLogin());
        }

        void m_ucBtnOK_EvtClicked(object sender, ButtonArgs e)
        {
            try
            {
                if( m_pbxNEWPWD1.Password != m_pbxNEWPWD2.Password )
                {
                    MessageBox.Show("비밀번호가 일치하지 않습니다.");
                    return;
                }

                var webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                webClient.UploadStringCompleted += webClient_UploadStringCompleted;
                webClient.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                webClient.Headers[HttpRequestHeader.Accept] = "text/plain";

                string sPostData = string.Format("CUPWD={0}&NEWPWD={1}", m_pbxPWD.Password, m_pbxNEWPWD1.Password);
                //webClient.UploadStringAsync(new Uri("http://tms.tenagent.com:8010/ServerPage/ChangePWD/setNOXChangePWD.php"), "POST", sPostData);

                string sDomain = FileIO.GeneralIO.GetJustPath((string)CSHTML5.Interop.ExecuteJavaScript("location.toString()"));
                string sUrl = string.Format("{0}ServerPage/ChangePWD/setNOXChangePWD.php", sDomain);
                webClient.UploadStringAsync(new Uri(sUrl), "POST", sPostData);

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void webClient_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            try
            {
                string sRet = SuperString.StringParser.GetNthStr(e.Result, 2, "(Ret)");

                if (sRet != "")
                {
                    MessageBox.Show(sRet);
                    return;
                }
                MainPage MainPage = Window.Current.Content as MainPage;
                MainPage.ChangeMain(new ucLogin());
            }
            catch (System.Exception ex)
            {
            	
            }
        }
    }
}
