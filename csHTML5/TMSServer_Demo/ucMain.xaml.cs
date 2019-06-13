using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Browser;
using System.Windows.Input;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Windows;
using System.Text;

namespace TMSServer
{
    public partial class ucMain : UserControl
    {
        public string m_sPwd = "";
        MainPage MainPage = null;

        public ucMain()
        {
            this.InitializeComponent();

            MainPage = (MainPage)Window.Current.Content;

            this.m_ucBtnAdd.TextColor      = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            this.m_ucBtnRemove.TextColor   = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            this.m_ucBtnRename.TextColor   = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));

            this.m_ucBtnAdd.EvtClicked    += m_ucBtnAdd_EvtClicked;
            this.m_ucBtnRename.EvtClicked += m_ucBtnRename_EvtClicked;
            this.m_ucBtnRemove.EvtClicked += m_ucBtnRemove_EvtClicked;
            this.SizeChanged              += ucMain_SizeChanged;
            this.Loaded                   += ucMain_Loaded;
        }

        void m_ucBtnAdd_EvtClicked(object sender, ButtonArgs e)
        {
            try
            {
                wndName wndName = new wndName();
                wndName.Pwd = m_sPwd;
                wndName.Type    = "Add";
                wndName.Closed += wndName_Closed;
                wndName.ShowAndWait();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void m_ucBtnRename_EvtClicked(object sender, ButtonArgs e)
        {
            string sTitle = "";
            try
            {
                foreach (ucSensorPannel ucSensorPannel in m_lstMain.Items)
                {
                    if (ucSensorPannel.IsChecked)
                    {
                        sTitle = ucSensorPannel.GetTitle();
                        break;
                    }
                }
                if (sTitle == "")
                {
                    MessageBox.Show("삭제한 항목이 하나도 없습니다.\n\n수정할 항목의 체크박스를 선택해 주세요");
                    return;
                }

                wndName wndName = new wndName();
                wndName.Pwd = m_sPwd;
                wndName.Type = "Modify";
                wndName.ID = sTitle;
                wndName.Closed += wndName_Closed;
                wndName.ShowAndWait();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void wndName_Closed(object sender, EventArgs e)
        {
            try
            {
                wndName wndName = sender as wndName;
                if( wndName.DialogResult.Value )
                {
                    GetMainData();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void m_ucBtnRemove_EvtClicked(object sender, ButtonArgs e)
        {
            string sTitle = "";
            try
            {
                if( MessageBoxResult.OK != MessageBox.Show("선택 항목을 삭제 하시겠습니까?", MessageBoxButton.OKCancel) )
                {
                    return;
                }

                foreach (ucSensorPannel ucSensorPannel in m_lstMain.Items)
                {
                    if (ucSensorPannel.IsChecked)
                    {
                        sTitle = ucSensorPannel.GetTitle();
                        break;
                    }
                }
                if( sTitle == "" )
                {
                    MessageBox.Show("삭제한 항목이 하나도 없습니다.\n\n삭제할 항목의 체크박스를 선택해 주세요");
                    return;
                }
                Cursor = Cursors.Wait;
                var webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                webClient.UploadStringCompleted += webClient_RemoveItemCompleted;
                webClient.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                webClient.Headers[HttpRequestHeader.Accept] = "text/plain";

                string sPostData = string.Format("PWD={0}&Title={1}&NewTitle=&Action=Remove", m_sPwd, sTitle);
                //webClient.UploadStringAsync(new Uri("http://tms.tenagent.com:8010/ServerPage/Action/Action.php"), "POST", sPostData);

                string sDomain = FileIO.GeneralIO.GetJustPath((string)CSHTML5.Interop.ExecuteJavaScript("location.toString()"));
                string sUrl = string.Format("{0}ServerPage/Action/Action.php", sDomain);
                webClient.UploadStringAsync(new Uri(sUrl), "POST", sPostData);
            }
            catch (System.Exception ex)
            {
                Cursor = Cursors.Arrow;
                MessageBox.Show(ex.Message);
            }
        }

        void webClient_RemoveItemCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            try
            {
                Cursor = Cursors.Arrow;

                string sRet = SuperString.StringParser.GetNthStr(e.Result, 2, "(Ret)");
                if( sRet != "" )
                {
                    MessageBox.Show(sRet);
                    return;
                }
                foreach (ucSensorPannel ucSensorPannel in m_lstMain.Items)
                {
                    if (ucSensorPannel.IsChecked)
                    {
                        m_lstMain.Items.Remove(ucSensorPannel);
                        break;
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void ucMain_Loaded(object sender, RoutedEventArgs e)
        {
            string sAMPM = "";
            try
            {
                UpdateLayout();

                string sYears = string.Format("{0}.{1:00}.{2:00}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                int nHour = DateTime.Now.Hour - 12;
                if (nHour > 0)
                    sAMPM = "오후";
                else
                {
                    sAMPM = "오전";
                    nHour = DateTime.Now.Hour;
                }
                string sTimes = string.Format("{0} {1:00}:{2:00}:{3:00}", sAMPM, nHour, DateTime.Now.Minute, DateTime.Now.Second);
                m_tbxCuDate.Text = string.Format("{0}  {1}", sYears, sTimes);

                var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
                timer.Tick += (senderTimer, args) =>
                {
                    sYears = string.Format("{0}.{1:00}.{2:00}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                    nHour = DateTime.Now.Hour - 12;
                    if (nHour > 0)
                        sAMPM = "오후";
                    else
                    {
                        sAMPM = "오전";
                        nHour = DateTime.Now.Hour;
                    }
                    sTimes = string.Format("{0} {1:00}:{2:00}:{3:00}", sAMPM, nHour, DateTime.Now.Minute, DateTime.Now.Second);
                    m_tbxCuDate.Text = string.Format("{0}  {1}", sYears, sTimes);
                };
                timer.Start();


                //데이터를 주기적으로 가져옴.
                
                //var timerGetData = new DispatcherTimer { Interval = TimeSpan.FromSeconds(5) };
                var timerGetData = new DispatcherTimer { Interval = TimeSpan.FromMinutes(3) };
                timerGetData.Tick += (senderTimer, args) =>
                {
                    try
                    {
                        GetMainData();                       
                    }
                    catch (System.Exception ex)
                    {
                        Cursor = Cursors.Arrow;
                        MessageBox.Show(ex.Message);
                    }
                };
                timerGetData.Start();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void ucMain_SizeChanged(object sender, SizeChangedEventArgs e)
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

            MainPage = (MainPage)Window.Current.Content;
            MainPage.ScrollEnable(false);
        }
        public async void GetMainData()
        {
            //try
            //{
            //    Cursor = Cursors.Wait;
            //    var webClient = new WebClient();
            //    webClient.Encoding = Encoding.UTF8;
            //    webClient.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
            //    webClient.Headers[HttpRequestHeader.Accept] = "text/plain";
            //    string sPostData = string.Format("PWD={0}", m_sPwd);
            //    //string sRet = await webClient.UploadStringTaskAsync(new Uri("http://tms.tenagent.com:8010/ServerPage/Login/getNOXLogin.php"), "POST", sPostData);
            //    //Cursor = Cursors.Arrow;
            //    //DisplayMainData(sRet);

            //    string sDomain = FileIO.GeneralIO.GetJustPath((string)CSHTML5.Interop.ExecuteJavaScript("location.toString()"));
            //    string sUrl = string.Format("{0}ServerPage/Login/getNOXLogin.php", sDomain);
            //    string sRet = await webClient.UploadStringTaskAsync(new Uri(sUrl), "POST", sPostData);
            //    Cursor = Cursors.Arrow;
            //    DisplayMainData(sRet);
            //}
            //catch (System.Exception ex)
            //{
            //    Cursor = Cursors.Arrow;
            //}
        }

        public void DisplayMainData(string sData)
        {
            try
            {
                MainPage = (MainPage)Window.Current.Content;

                ucSensorPannel ucSensorPannel1 = new ucSensorPannel();
                ucSensorPannel1.Width = 296;
                ucSensorPannel1.Height = 387;
                ucSensorPannel1.Margin = new Thickness(0, 0, 15, 15);
                ucSensorPannel1.SetData("DME TANK");
                m_lstMain.Items.Add(ucSensorPannel1);

                ucSensorPannel ucSensorPannel2 = new ucSensorPannel();
                ucSensorPannel2.Width = 296;
                ucSensorPannel2.Height = 387;
                ucSensorPannel2.Margin = new Thickness(0, 0, 15, 15);
                ucSensorPannel2.SetData("DME 발전기");
                m_lstMain.Items.Add(ucSensorPannel2);

                ucSensorPannel ucSensorPannel3 = new ucSensorPannel();
                ucSensorPannel3.Width = 296;
                ucSensorPannel3.Height = 387;
                ucSensorPannel3.Margin = new Thickness(0, 0, 15, 15);
                ucSensorPannel3.SetData("CO2 발생기");
                m_lstMain.Items.Add(ucSensorPannel3);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        void ucSensorPannel_EvtCheckBoxClick(object sender, ucSensorPannel.SensorPannelEventArgs e)
        {
            try
            {
                foreach (ucSensorPannel ucSensorPannel in m_lstMain.Items)
                {
                    if (ucSensorPannel.GetTitle() != e.Text)
                    {
                        ucSensorPannel.IsChecked = false;
                    }
                }
            }
            catch (System.Exception ex)
            {
            	MessageBox.Show(ex.Message);
            }
        }

        void ucSensorPannel_EvtTitleClick(object sender, ucSensorPannel.SensorPannelEventArgs e)
        {
            try
            {
                ucHistory ucHistory = new ucHistory();
                MainPage MainPage = Window.Current.Content as MainPage;
                MainPage.ChangeMain(ucHistory);
                ucHistory.SetID(e.Text);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        public void SetPwd(string sPwd)
        {
            m_sPwd = sPwd;
        }
    }
}
