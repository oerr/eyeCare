using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using CSHTML5.Extensions.Plotly;
namespace TMSServer
{
    
    public partial class ucChart : UserControl
    {
        public double _Width;
        public double Width
        {
            get
            {
                return _Width;
            }
            set
            {
                _Width = value;
                base.Width = _Width;
                m_Chart.Layout.Width = Convert.ToInt32(_Width);
                m_Chart.Render();
            }
        }
        public double _Height;
        public double Height
        {
            get
            {
                return _Height;
            }
            set
            {
                _Height = value;
                base.Height = _Height;
                m_Chart.Layout.Height = Convert.ToInt32(_Height);
                m_Chart.Render();
            }
        }


        public ucChart()
        {
            this.InitializeComponent();
            this.Loaded += ucChart_Loaded;
        }
        
        private async void ucChart_Loaded(object sender, RoutedEventArgs e)
        {
            await ChartControl.Initialize("ms-appx:/ChartControl/typedarray.js", "ms-appx:/ChartControl/plotly.min.js");
        }
        public void SetChartLayout(string sTitle, string sPlotColor)
        {
            m_Chart.Layout = new Layout()
            {
                Title       = sTitle,
                PlotBgColor = sPlotColor,
                Width = Convert.ToInt32(this.ActualWidth),
                Height = Convert.ToInt32(this.ActualHeight),
            };
            m_Chart.Render();
        }
        public void SetChartData()
        {
            m_Chart.Data = new Data()
            {
                Traces = new List<Trace>()
                {
                    new Trace()
                    {
                        X = new List<object>() { 1, 2, 3, 4 },
                        Y = new List<object>() { 10, 15, 13, 17 },
                        Type = TraceType.Scatter,
                    },
                    ////new Trace()
                    ////{
                    ////    X = new List<object>() { 2, 3, 4, 5 },
                    ////    Y = new List<object>() { 16, 5, 11, 9 },
                    ////    Type = TraceType.Scatter,
                    ////    Mode = TraceMode.Markers | TraceMode.Text,
                    ////    Text = new List<string>() { "B-a", "B-b", "B-c", "B-d", "B-e" },
                    ////    Marker = new Marker()
                    ////    {
                    ////        Size = 14
                    ////    }
                    ////},
                    //new Trace()
                    //{
                    //    X = new List<object>() { 1, 2, 3, 4 },
                    //    Y = new List<object>() { 12, 9, 15, 12 },
                    //    Type = TraceType.Scatter,
                    //    Mode = TraceMode.Lines | TraceMode.Markers
                    //},
                }
            };
            m_Chart.Render();
        }
 



    }
}
