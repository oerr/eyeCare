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

namespace TMSServer
{
    public partial class ucSensorPannel : UserControl
    {
        ucSensorPannelEntry m_ucSensorPannelNOX      = new ucSensorPannelEntry();
        ucSensorPannelEntry m_ucSensorPannelCO       = new ucSensorPannelEntry();
        ucSensorPannelEntry m_ucSensorPannelCO2      = new ucSensorPannelEntry();
        ucSensorPannelEntry m_ucSensorPannelFINEDUST = new ucSensorPannelEntry();

        private bool _IsChecked = false;
        public bool IsChecked
        {
            get
            {
                return _IsChecked;
            }
            set
            {
                _IsChecked = value;
                m_chkBox.IsChecked = value;
            }
        }

        public class SensorPannelEventArgs : EventArgs
        {
            public string Text { get; set; }
        
            public SensorPannelEventArgs(string param)
            {
                this.Text = param;
            }
        }
        
        public event EventHandler<SensorPannelEventArgs> EvtTitleClick;
        public event EventHandler<SensorPannelEventArgs> EvtCheckBoxClick;
        
        public ucSensorPannel()
        {
            this.InitializeComponent();



            this.m_chkBox.Click += m_chkBox_Click;
            this.m_ucBtnTitle.TextColor = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 0, 146, 255));
            this.m_ucBtnTitle.EvtClicked += m_ucBtnTitle_EvtClicked;
        }

        void m_chkBox_Click(object sender, RoutedEventArgs e)
        {
            _IsChecked = !m_chkBox.IsChecked.Value;

            SensorPannelEventArgs args = new SensorPannelEventArgs(m_ucBtnTitle.Text);
            if (EvtCheckBoxClick != null)
            {
                EvtCheckBoxClick(this, args);
            }
        }

        public string GetTitle()
        {
            return m_ucBtnTitle.Text;
        }
        

        void m_ucBtnTitle_EvtClicked(object sender, ButtonArgs e)
        {
            SensorPannelEventArgs args = new SensorPannelEventArgs(e.Text);
            if (EvtTitleClick != null)
            {
                EvtTitleClick(this, args);
            }
        }

        //(Name)센서A지역(Name)(NOX)23(NOX)(CO)50(CO)(CO2)200(CO2)(FINEDUST)(1.0)수치(1.0)(2.5)수치(2.5)(10)수치(10)(FINEDUST)
        public void SetData(string sEntry)
        {
            try
            {
                m_gdCO2.Visibility = Visibility.Visible;
                m_gdFineDust.Visibility = Visibility.Visible;


                if (sEntry == "DME TANK")
                {
                    m_ucBtnTitle.Text = "DME TANK";

                    m_ucSensorPannelNOX.SetPannel("압력");
                    m_gdNOX.Children.Add(m_ucSensorPannelNOX);
                    m_ucSensorPannelNOX.SetData("압력", "5.1");

                    m_ucSensorPannelCO.SetPannel("온도");
                    m_gdCO.Children.Add(m_ucSensorPannelCO);
                    m_ucSensorPannelCO.SetData("온도", "25.1");

                    m_ucSensorPannelCO2.SetPannel("레벨");
                    m_gdCO2.Children.Add(m_ucSensorPannelCO2);
                    m_ucSensorPannelCO2.SetData("레벨", "25.1");

                    m_gdFineDust.Visibility = Visibility.Collapsed;
                }
                else if (sEntry == "DME 발전기")
                {
                    m_ucBtnTitle.Text = "DME 발전기";

                    m_ucSensorPannelNOX.SetPannel("전력");
                    m_gdNOX.Children.Add(m_ucSensorPannelNOX);
                    m_ucSensorPannelNOX.SetData("전력", "25.1");

                    m_ucSensorPannelCO.SetPannel("연료");
                    m_gdCO.Children.Add(m_ucSensorPannelCO);
                    m_ucSensorPannelCO.SetData("연료", "25.1");

                    m_gdCO2.Visibility = Visibility.Collapsed;
                    m_gdFineDust.Visibility = Visibility.Collapsed;
                }
                else if (sEntry == "CO2 발생기")
                {
                    m_ucBtnTitle.Text = "CO2 발생기";

                    m_ucSensorPannelNOX.SetPannel("온도");
                    m_gdNOX.Children.Add(m_ucSensorPannelNOX);
                    m_ucSensorPannelNOX.SetData("온도", "25.1");

                    m_ucSensorPannelCO.SetPannel("습도");
                    m_gdCO.Children.Add(m_ucSensorPannelCO);
                    m_ucSensorPannelCO.SetData("습도", "60");

                    m_ucSensorPannelCO2.SetPannel("CO2");
                    m_gdCO2.Children.Add(m_ucSensorPannelCO2);
                    m_ucSensorPannelCO2.SetData("CO2", "400");

                    m_gdFineDust.Visibility = Visibility.Collapsed;
                }

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



    }
}
