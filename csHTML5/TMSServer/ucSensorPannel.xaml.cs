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

            m_ucSensorPannelNOX.SetPannel("NOX");
            m_gdNOX.Children.Add(m_ucSensorPannelNOX);

            m_ucSensorPannelCO.SetPannel("CO");
            m_gdCO.Children.Add(m_ucSensorPannelCO);

            //m_ucSensorPannelCO2.SetPannel("CO2");
            //m_gdCO2.Children.Add(m_ucSensorPannelCO2);

            m_ucSensorPannelFINEDUST.SetPannel("FINEDUST");
            m_gdFineDust.Children.Add(m_ucSensorPannelFINEDUST);

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
                m_ucBtnTitle.Text = SuperString.StringParser.GetNthStr(sEntry, 2, "(ID)");

                m_ucSensorPannelNOX.SetData("NOX", SuperString.StringParser.GetNthStr(sEntry, 2, "(NOX)") );
                m_ucSensorPannelCO.SetData("CO", SuperString.StringParser.GetNthStr(sEntry, 2, "(CO)") );
                m_ucSensorPannelCO2.SetData("CO2", SuperString.StringParser.GetNthStr(sEntry, 2, "(CO2)") );
                m_ucSensorPannelFINEDUST.SetData("FINEDUST", SuperString.StringParser.GetNthStr(sEntry, 2, "(FINEDUST)"));
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



    }
}
