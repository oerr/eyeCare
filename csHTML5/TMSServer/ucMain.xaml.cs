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

                //string sYears = string.Format("{0}.{1:00}.{2:00}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                //int nHour = DateTime.Now.Hour - 12;
                //if (nHour > 0)
                //    sAMPM = "오후";
                //else
                //{
                //    sAMPM = "오전";
                //    nHour = DateTime.Now.Hour;
                //}
                //string sTimes = string.Format("{0} {1:00}:{2:00}:{3:00}", sAMPM, nHour, DateTime.Now.Minute, DateTime.Now.Second);
                //m_tbxCuDate.Text = string.Format("{0}  {1}", sYears, sTimes);

                //var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
                //timer.Tick += (senderTimer, args) =>
                //{
                //    sYears = string.Format("{0}.{1:00}.{2:00}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                //    nHour = DateTime.Now.Hour - 12;
                //    if (nHour > 0)
                //        sAMPM = "오후";
                //    else
                //    {
                //        sAMPM = "오전";
                //        nHour = DateTime.Now.Hour;
                //    }
                //    sTimes = string.Format("{0} {1:00}:{2:00}:{3:00}", sAMPM, nHour, DateTime.Now.Minute, DateTime.Now.Second);
                //    m_tbxCuDate.Text = string.Format("{0}  {1}", sYears, sTimes);
                //};
                //timer.Start();


                //데이터를 주기적으로 가져옴.
                
                //var timerGetData = new DispatcherTimer { Interval = TimeSpan.FromSeconds(5) };
                //var timerGetData = new DispatcherTimer { Interval = TimeSpan.FromMinutes(1) };
                var timerGetData = new DispatcherTimer { Interval = TimeSpan.FromSeconds(30) };
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
                //MessageBox.Show(ex.Message);
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
            try
            {
                Cursor = Cursors.Wait;
                var webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                webClient.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                webClient.Headers[HttpRequestHeader.Accept] = "text/plain";
                string sPostData = string.Format("PWD={0}", m_sPwd);
                //string sRet = await webClient.UploadStringTaskAsync(new Uri("http://tms.tenagent.com:8010/ServerPage/Login/getNOXLogin.php"), "POST", sPostData);
                //Cursor = Cursors.Arrow;
                //DisplayMainData(sRet);

                string sDomain = FileIO.GeneralIO.GetJustPath((string)CSHTML5.Interop.ExecuteJavaScript("location.toString()"));
                string sUrl = string.Format("{0}ServerPage/Login/getNOXLogin.php", sDomain);
                string sRet = await webClient.UploadStringTaskAsync(new Uri(sUrl), "POST", sPostData);
                Cursor = Cursors.Arrow;
                DisplayMainData(sRet);
            }
            catch (System.Exception ex)
            {
                Cursor = Cursors.Arrow;
            }
        }

        public void DisplayMainData(string sData)
        {
            int i = 1;

            try
            {
                MainPage = (MainPage)Window.Current.Content;

                //각 센서가 데이터를 전송하는 주기 < 각 지역에서  데이터를 전송 시간

                //(Registration)센서A지역\n센서B지역\n센서C지역\n센서D지역(Registration)
                //현재시간 기준 T_SendorData 의 데이터중 최신것 가져옴.
                //-> 최신날짜를 먼저 가져오고, 해당 날짜의 등록된 Name and 최신날짜 를 가져옴
                //(RealData)
                //(Name)센서A지역(Name)(NOX)23(NOX)(CO)50(CO)(CO2)200(CO2)(FINEDUST)(1.0)수치(1.0)(2.5)수치(2.5)(10)수치(10)(FINEDUST)\n
                //(Name)센서B지역(Name)(NOX)23(NOX)(CO)50(CO)(CO2)200(CO2)(FINEDUST)(1.0)수치(1.0)(2.5)수치(2.5)(10)수치(10)(FINEDUST)\n
                //(Name)센서C지역(Name)(NOX)23(NOX)(CO)50(CO)(CO2)200(CO2)(FINEDUST)(1.0)수치(1.0)(2.5)수치(2.5)(10)수치(10)(FINEDUST)\n
                //여러개의 센서A지역은 안나옴 - uniqe 함
                //(RealData)
                //(DataValue)(NOX)100,300,500,700(NOX)(CO)50,70,120,200(CO)(CO2)50,0,120,200,250(CO2)(FINEDUST)(1.0)0.5,0.1,0.15,0.2(1.0)(2.5)0.5,0.1,0.15,0.2(2.5)(10)0.5,0.1,0.15,0.2(10)(FINEDUST)(DataValue)
                string sDataValue   = SuperString.StringParser.GetNthStr(sData, 2, "(DataValue)");
                string sNOX         = SuperString.StringParser.GetNthStr(sDataValue, 2, "(NOX)");
                string sCO          = SuperString.StringParser.GetNthStr(sDataValue, 2, "(CO)");
                string sCO2         = SuperString.StringParser.GetNthStr(sDataValue, 2, "(CO2)");
                string sFINEDUST    = SuperString.StringParser.GetNthStr(sDataValue, 2, "(FINEDUST)");
                string sFINEDUST_1_0 = SuperString.StringParser.GetNthStr(sFINEDUST, 2, "(1.0)");
                string sFINEDUST_2_5 = SuperString.StringParser.GetNthStr(sFINEDUST, 2, "(2.5)");
                string sFINEDUST_10  = SuperString.StringParser.GetNthStr(sFINEDUST, 2, "(10)");

                MainPage.m_lstMaxNOX.Clear();
                MainPage.m_lstMaxCO.Clear();
                MainPage.m_lstMaxCO2.Clear();
                MainPage.m_lstMaxFineDust1_0.Clear();
                MainPage.m_lstMaxFineDust2_5.Clear();
                MainPage.m_lstMaxFineDust10.Clear();

                for (i = 1; i <= 5; ++i)
                    MainPage.m_lstMaxNOX.Add(EConvert.ToDouble(SuperString.StringParser.GetNthStr(sNOX, i, ",")));
                for (i = 1; i <= 5; ++i)
                    MainPage.m_lstMaxCO.Add(EConvert.ToDouble(SuperString.StringParser.GetNthStr(sCO, i, ",")));
                for (i = 1; i <= 5; ++i)
                    MainPage.m_lstMaxCO2.Add(EConvert.ToDouble(SuperString.StringParser.GetNthStr(sCO2, i, ",")));
                for (i = 1; i <= 5; ++i)
                    MainPage.m_lstMaxFineDust1_0.Add(EConvert.ToDouble(SuperString.StringParser.GetNthStr(sFINEDUST_1_0, i, ",")));
                for (i = 1; i <= 5; ++i)
                    MainPage.m_lstMaxFineDust2_5.Add(EConvert.ToDouble(SuperString.StringParser.GetNthStr(sFINEDUST_2_5, i, ",")));
                for (i = 1; i <= 5; ++i)
                    MainPage.m_lstMaxFineDust10.Add(EConvert.ToDouble(SuperString.StringParser.GetNthStr(sFINEDUST_10, i, ",")));

                string sRegData = SuperString.StringParser.GetNthStr(sData, 2, "(Registration)");
                int nRegCnt = SuperString.StringParser.GetStrCount(sRegData, "\n");

                string sRealData = SuperString.StringParser.GetNthStr(sData, 2, "(RealData)");
                int nRealCnt = SuperString.StringParser.GetStrCount(sRealData, "\n");

                //상태 정보
                m_tbxTotalCnt.Text    = nRegCnt.ToString();
                m_tbxNormalCnt.Text   = nRealCnt.ToString();
                m_tbxAbnormalCnt.Text = (nRegCnt - nRealCnt).ToString();

                m_lstMain.Items.Clear();

                for (i = 1; i <= nRealCnt; ++i)
                {
                    string sEntry = SuperString.StringParser.GetNthStr(sRealData, i, "\n");
                    if (sEntry == "") continue;

                    ucSensorPannel ucSensorPannel = new ucSensorPannel();
                    ucSensorPannel.Width  = 296;
                    ucSensorPannel.Height = 297;
                    ucSensorPannel.Margin = new Thickness(0, 0, 15, 15);
                    ucSensorPannel.SetData(sEntry);
                    ucSensorPannel.EvtTitleClick += ucSensorPannel_EvtTitleClick;
                    ucSensorPannel.EvtCheckBoxClick += ucSensorPannel_EvtCheckBoxClick;
                    m_lstMain.Items.Add(ucSensorPannel);
                }
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
