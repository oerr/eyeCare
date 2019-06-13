using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Windows.Input;
using System.Text;

namespace TMSServer
{
    public partial class wndName : ChildWindow
    {
        public string m_sOldID = "";
        public string Pwd { get; set; }
        public string Type { get; set; }
        public string ID { get; set; }
        public wndName()
        {
            InitializeComponent();
            this.m_ucBtnOK.TextColor = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            this.m_ucBtnOK.EvtClicked += m_ucBtnOK_EvtClicked;
            this.m_ucBtnCancel.TextColor = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            this.m_ucBtnCancel.EvtClicked += m_ucBtnCancel_EvtClicked;
            this.Loaded += wndName_Loaded;
        }

        void m_ucBtnCancel_EvtClicked(object sender, ButtonArgs e)
        {
            DialogResult = false;
        }

        void m_ucBtnOK_EvtClicked(object sender, ButtonArgs e)
        {
            try
            {
                var webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                webClient.UploadStringCompleted += webClient_UploadStringCompleted;
                webClient.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                webClient.Headers[HttpRequestHeader.Accept] = "text/plain";
                Cursor = Cursors.Wait;

                if( Type == "Add")
                {
                    string sPostData = string.Format("PWD={0}&Title=&NewTitle={1}&Action=Add", Pwd, m_tbxName.Text);
                    //webClient.UploadStringAsync(new Uri("http://tms.tenagent.com:8010/ServerPage/Action/Action.php"), "POST", sPostData);

                    string sDomain = FileIO.GeneralIO.GetJustPath((string)CSHTML5.Interop.ExecuteJavaScript("location.toString()"));
                    string sUrl = string.Format("{0}ServerPage/Action/Action.php", sDomain);
                    webClient.UploadStringAsync(new Uri(sUrl), "POST", sPostData);
                }
                else if (Type == "Modify")
                {
                    string sPostData = string.Format("PWD={0}&Title={1}&NewTitle={2}&Action=Modify", Pwd, m_sOldID, m_tbxName.Text);
                    //webClient.UploadStringAsync(new Uri("http://tms.tenagent.com:8010/ServerPage/Action/Action.php"), "POST", sPostData);

                    string sDomain = FileIO.GeneralIO.GetJustPath((string)CSHTML5.Interop.ExecuteJavaScript("location.toString()"));
                    string sUrl = string.Format("{0}ServerPage/Action/Action.php", sDomain);
                    webClient.UploadStringAsync(new Uri(sUrl), "POST", sPostData);
                }
                else
                {
                    MessageBox.Show("Type 오류");	
                }
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

                string sRet = SuperString.StringParser.GetNthStr(e.Result, 2, "(Ret)");
                if (sRet != "")
                {
                    MessageBox.Show(sRet);
                    return;
                }
                DialogResult = true;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void wndName_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                this.FontSize = 16;

                if( Type == "Add")
                {
                    this.Title = "추가";
                }
                else if( Type == "Modify")
                {
                    this.Title = "이름 변경";
                    m_sOldID = ID;
                    this.m_tbxName.Text = ID;
                }
                m_tbxName.Focus();
            }
            catch (System.Exception ex)
            {
            	
            }
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}

