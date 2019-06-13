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
    public partial class ucHistory : UserControl
    {
        public string m_sID = "";
        bool m_bExtended = false;

        public ucHistory()
        {
            this.InitializeComponent();

            this.m_Img.PointerPressed += m_Img_PointerPressed;
            this.m_ucBtnSearch.TextColor   = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            this.m_ucBtnSearch.EvtClicked += m_ucBtnSearch_EvtClicked;
            this.m_ucBtnNOX.TextColor      = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 39, 104, 140));
            this.m_ucBtnCO.TextColor       = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 39, 104, 140));
            this.m_ucBtnCO2.TextColor      = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 39, 104, 140));
            this.m_ucBtnFineDust.TextColor = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 39, 104, 140));

            this.SizeChanged += ucHistory_SizeChanged;
            this.m_ucBtnNOX.EvtClicked += m_ucBtnNOX_EvtClicked;
            this.m_ucBtnCO.EvtClicked += m_ucBtnCO_EvtClicked;
            this.m_ucBtnCO2.EvtClicked += m_ucBtnCO2_EvtClicked;
            this.m_ucBtnFineDust.EvtClicked += m_ucBtnFineDust_EvtClicked;
            this.Loaded += ucHistory_Loaded;
        }

        void m_Img_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            try
            {
                ucMain ucMain = new ucMain();
                MainPage MainPage = Window.Current.Content as MainPage;

                ucMain.SetPwd(MainPage.Pwd);

                MainPage.ChangeMain(ucMain);
                ucMain.GetMainData();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void m_ucBtnSearch_EvtClicked(object sender, ButtonArgs e)
        {
            Search();
        }

        public void Search()
        {
            try
            {
                //m_gdList.Items.Clear();
                string sData = string.Format("{0}-{1:00}-{2:00}~{3}-{4:00}-{5:00}",
                                             EConvert.ToInt32(m_tbxFromYear.Text),
                                             EConvert.ToInt32(m_tbxFromMonth.Text),
                                             EConvert.ToInt32(m_tbxFromDay.Text),
                                             EConvert.ToInt32(m_tbxToYear.Text),
                                             EConvert.ToInt32(m_tbxToMonth.Text),
                                             EConvert.ToInt32(m_tbxToDay.Text)
                                            );

                MainPage MainPage = (MainPage)Window.Current.Content;

                Cursor = Cursors.Wait;

                var webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                webClient.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                webClient.Headers[HttpRequestHeader.Accept] = "text/plain";
                
                webClient.UploadStringCompleted += webClient_SearchCompleted;
                string sPostData = string.Format("PWD={0}&Name={1}&Data={2}", MainPage.Pwd, m_sID, sData);
                //webClient.UploadStringAsync(new Uri("http://tms.tenagent.com:8010/ServerPage/History/GetChartData.php"), "POST", sPostData);

                string sDomain = FileIO.GeneralIO.GetJustPath((string)CSHTML5.Interop.ExecuteJavaScript("location.toString()"));
                string sUrl = string.Format("{0}ServerPage/History/GetChartData.php", sDomain);
                webClient.UploadStringAsync(new Uri(sUrl), "POST", sPostData);
            }
            catch (System.Exception ex)
            {
                Cursor = Cursors.Arrow;
                MessageBox.Show(ex.Message);
            }
        }


        void webClient_SearchCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            SuperString.StringParser strParser = new SuperString.StringParser();

            try
            {
                Cursor = Cursors.Arrow;

                string sRet = SuperString.StringParser.GetNthStr(e.Result, 2, "(Ret)");
                if (sRet.IndexOf("Error") != -1)
                {
                    MessageBox.Show(sRet);
                    return;
                }
                List<object> lstXDate = new List<object>();
                List<object> lstYNOX = new List<object>();
                List<object> lstYCO  = new List<object>();
                List<object> lstYCO2 = new List<object>();
                List<object> lstYFineDust = new List<object>();

                //sDate,sNOX,sCO,sCO2,sFineDust2_5\nsDate,sNOX,sCO,sCO2,sFineDust2_5\n
                strParser.Parse(sRet, "\n");
                int nTotal = strParser.GetParseCount();
                for( int i = 0 ; i < nTotal; ++i )
                {
                    string sEntry    = strParser.GetParseAt(i);

                    lstXDate.Add(SuperString.StringParser.GetNthStr(sEntry, 1, ","));
                    lstYNOX.Add(SuperString.StringParser.GetNthStr(sEntry, 2, ","));
                    lstYCO.Add(SuperString.StringParser.GetNthStr(sEntry, 3, ","));
                    lstYCO2.Add(SuperString.StringParser.GetNthStr(sEntry, 4, ","));
                    lstYFineDust.Add(SuperString.StringParser.GetNthStr(sEntry, 5, ","));
                }
                m_ChartNOX.SetChartData(lstXDate, lstYNOX);
                m_ChartNOX.SetChartLayout("", "White");

                m_ChartCO.SetChartData(lstXDate, lstYCO);
                m_ChartCO.SetChartLayout("", "White");

                m_ChartCO2.SetChartData(lstXDate, lstYCO2);
                m_ChartCO2.SetChartLayout("", "White");

                m_ChartFineDust.SetChartData(lstXDate, lstYFineDust);
                m_ChartFineDust.SetChartLayout("", "White");

                //////////FineDust
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void m_ucBtnFineDust_EvtClicked(object sender, ButtonArgs e)
        {
            try
            {
                m_bExtended = !m_bExtended;
                if( m_bExtended )
                {
                    this.m_bdFineDust.SetValue(Grid.ColumnProperty, 1);
                    this.m_bdFineDust.SetValue(Grid.RowProperty, 0);
                    this.m_bdFineDust.SetValue(Grid.RowSpanProperty, 3);
                    this.m_bdFineDust.SetValue(Grid.ColumnSpanProperty, 5);
                    Canvas.SetZIndex(m_bdFineDust, 1);
                }
                else
                {
                    this.m_bdFineDust.SetValue(Grid.ColumnProperty, 5);
                    this.m_bdFineDust.SetValue(Grid.RowProperty, 2);
                    this.m_bdFineDust.SetValue(Grid.ColumnSpanProperty, 1);
                    this.m_bdFineDust.SetValue(Grid.RowSpanProperty, 1);
                    Canvas.SetZIndex(m_bdFineDust, 0);
                }
                UpdateLayout();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void m_ucBtnCO2_EvtClicked(object sender, ButtonArgs e)
        {
            try
            {
                m_bExtended = !m_bExtended;
                if (m_bExtended)
                {
                    this.m_bdCO2.SetValue(Grid.ColumnProperty, 1);
                    this.m_bdCO2.SetValue(Grid.RowProperty, 0);
                    this.m_bdCO2.SetValue(Grid.RowSpanProperty, 3);
                    this.m_bdCO2.SetValue(Grid.ColumnSpanProperty, 5);
                    Canvas.SetZIndex(m_bdCO2, 1);
                }
                else
                {
                    this.m_bdCO2.SetValue(Grid.ColumnProperty, 3);
                    this.m_bdCO2.SetValue(Grid.RowProperty, 2);
                    this.m_bdCO2.SetValue(Grid.ColumnSpanProperty, 1);
                    this.m_bdCO2.SetValue(Grid.RowSpanProperty, 1);
                    Canvas.SetZIndex(m_bdCO2, 0);
                }
                UpdateLayout();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void m_ucBtnCO_EvtClicked(object sender, ButtonArgs e)
        {
            try
            {
                m_bExtended = !m_bExtended;
                if (m_bExtended)
                {
                    this.m_bdCO.SetValue(Grid.ColumnProperty, 1);
                    this.m_bdCO.SetValue(Grid.RowSpanProperty, 3);
                    this.m_bdCO.SetValue(Grid.ColumnSpanProperty, 5);
                    Canvas.SetZIndex(m_bdCO, 1);
                }
                else
                {
                    this.m_bdCO.SetValue(Grid.ColumnProperty, 5);
                    this.m_bdCO.SetValue(Grid.RowSpanProperty, 1);
                    this.m_bdCO.SetValue(Grid.ColumnSpanProperty, 1);
                    this.m_bdNOX.SetValue(Grid.RowSpanProperty, 1);
                    Canvas.SetZIndex(m_bdCO, 0);
                }
                UpdateLayout();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void m_ucBtnNOX_EvtClicked(object sender, ButtonArgs e)
        {
            try
            {
                m_bExtended = !m_bExtended;
                if (m_bExtended)
                {
                    this.m_bdNOX.SetValue(Grid.ColumnProperty, 1);
                    this.m_bdNOX.SetValue(Grid.RowSpanProperty, 3);
                    this.m_bdNOX.SetValue(Grid.ColumnSpanProperty, 5);
                    Canvas.SetZIndex(m_bdNOX, 1);
                }
                else
                {
                    this.m_bdNOX.SetValue(Grid.ColumnProperty, 3);
                    this.m_bdNOX.SetValue(Grid.RowSpanProperty, 1);
                    this.m_bdNOX.SetValue(Grid.ColumnSpanProperty, 1);
                    this.m_bdNOX.SetValue(Grid.RowSpanProperty, 1);
                    Canvas.SetZIndex(m_bdNOX, 0);
                }
                UpdateLayout();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        async void ucHistory_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                await System.Threading.Tasks.Task.Delay(1000);

                UpdateLayout();

                var timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(100) };
                timer.Tick += (senderTimer, args) =>
                {
                    if (CSHTML5.Extensions.Plotly.ChartControl.JSLibraryWasLoaded)
                    {
                        timer.Stop();

                        UpdateLayout();
                        m_ChartNOX.SetChartLayout("", "White");
                        m_ChartCO.SetChartLayout("", "White");
                        m_ChartCO2.SetChartLayout("", "White");
                        m_ChartFineDust.SetChartLayout("", "White");
                    }
                };
                timer.Start();

               m_tbxFromYear.Text  =  DateTime.Now.Year.ToString();
               m_tbxFromMonth.Text =  DateTime.Now.Month.ToString();
               m_tbxFromDay.Text   =  DateTime.Now.Day.ToString();

               m_tbxToYear.Text    = DateTime.Now.Year.ToString();
               m_tbxToMonth.Text   = DateTime.Now.Month.ToString();
               m_tbxToDay.Text     = DateTime.Now.Day.ToString();

               Search();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void ucHistory_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdateLayout();
        }

        public void UpdateLayout()
        {
            try
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
                MainPage.ScrollEnable(false);

                m_ChartNOX.Width = m_gdNOX.ActualWidth - 15;
                m_ChartNOX.Height = m_gdNOX.ActualHeight - 15;

                m_ChartCO.Width = m_gdCO.ActualWidth - 15;
                m_ChartCO.Height = m_gdCO.ActualHeight - 15;

                m_ChartCO2.Width = m_gdCO2.ActualWidth - 15;
                m_ChartCO2.Height = m_gdCO2.ActualHeight - 15;

                m_ChartFineDust.Width = m_gdFineDust.ActualWidth - 15;
                m_ChartFineDust.Height = m_gdFineDust.ActualHeight - 15;  
            }
            catch (System.Exception ex)
            {
            	
            }
     
        }

        public void SetID(string sID)
        {
            m_sID = sID;
            this.m_tbxName.Text = m_sID;
        }
    }
}
