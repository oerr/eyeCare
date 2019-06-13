using System;
using System.IO;
using System.Linq;
using System.Windows.Browser;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Net;
using System.Text;
using System.Windows.Input;


namespace TMSServer
{
    public partial class ucLogin : UserControl
    {
        public ucLogin()
        {
            this.InitializeComponent();

            this.m_ucBtnOK.ImgSrc = "ms-appx:/Img/Button_01.png";
            this.m_ucBtnOK.TextColor = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 255, 255, 255));
            this.m_ucBtnOK.EvtClicked += m_ucBtnOK_EvtClicked;

            this.m_ucBtnChangePwd.ImgSrc = "ms-appx:/Img/Button_02.png";
            this.m_ucBtnChangePwd.TextColor = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 255, 255, 255));
            this.m_ucBtnChangePwd.EvtClicked += m_ucBtnChangePwd_EvtClicked;

            this.SizeChanged += ucLogin_SizeChanged;
            this.Loaded += ucLogin_Loaded;
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

        void ucLogin_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdateLayout();
        }

        void ucLogin_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateLayout();
            m_tbxID.Focus();            
        }

        void m_ucBtnChangePwd_EvtClicked(object sender, ButtonArgs e)
        {
            MainPage MainPage = Window.Current.Content as MainPage;
            MainPage.ChangeMain(new ucChangePwd());
        }

        void m_ucBtnOK_EvtClicked(object sender, ButtonArgs e)
        {
            try
            {
                Cursor = Cursors.Wait;

                var webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                webClient.UploadStringCompleted += webClient_UploadStringCompleted;
                webClient.Headers[HttpRequestHeader.ContentType] = "Application/x-www-form-urlencoded";
                webClient.Headers[HttpRequestHeader.Accept] = "text/plain";

                string sPostData = string.Format("PWD={0}", m_pbxPWD.Password);
                //webClient.UploadStringAsync(new Uri("http://tms.tenagent.com:8010/ServerPage/Login/getNOXLogin.php"), "POST", sPostData);

                string sDomain = FileIO.GeneralIO.GetJustPath((string)CSHTML5.Interop.ExecuteJavaScript("location.toString()"));
                string sUrl = string.Format("{0}ServerPage/Login/getNOXLogin.php", sDomain);
                webClient.UploadStringAsync(new Uri(sUrl), "POST", sPostData);
            }
            catch (System.Exception ex)
            {
                Cursor = Cursors.Arrow;
                MessageBox.Show(ex.Message);
            }
        }

        void webClient_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            try
            {
                Cursor = Cursors.Arrow;

                string sRet = e.Result;

                sRet = SuperString.StringParser.GetNthStr(sRet, 2, "(Ret)");
                if (sRet.IndexOf("Error") != -1)
                {
                    MessageBox.Show(sRet);
                    return;
                }
                ucMain ucMain = new ucMain();
                MainPage MainPage = Window.Current.Content as MainPage;

                MainPage = (MainPage)Window.Current.Content;
                MainPage.Pwd = m_pbxPWD.Password;
                ucMain.SetPwd(m_pbxPWD.Password);

                MainPage.ChangeMain(ucMain);
                ucMain.DisplayMainData(sRet);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }




    }
}
