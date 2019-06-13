using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

//ucHistory -> ucChart -> ChartControl 구조로 됨
namespace TMSServer
{
    public partial class ucHistory : UserControl
    {
        public ucHistory()
        {
            this.InitializeComponent();
            this.m_ucBtnSearch.TextColor = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            this.SizeChanged += ucHistory_SizeChanged;
            this.Loaded += ucHistory_Loaded;
        }

        void ucHistory_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateLayout();

            var timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(100) };
            timer.Tick += (senderTimer, args) =>
            {
                timer.Stop();
                
                if ( !CSHTML5.Extensions.Plotly.ChartControl.JSLibraryWasLoaded )
                    timer.Start();
                else
                {
                    UpdateLayout();
                    m_ChartNOX.SetChartLayout("", "White");
                    m_ChartNOX.SetChartData();
                }
            };
            timer.Start();
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

                m_ChartNOX.Width  = m_gdNOX.ActualWidth-15;
                m_ChartNOX.Height = m_gdNOX.ActualHeight-15;       
            }
            catch (System.Exception ex)
            {
            	
            }
     
        }
    }
}
