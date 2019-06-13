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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

namespace TMSServer
{
    public partial class ucSensorPannelEntry : UserControl
    {
        MainPage MainPage = null;

        public ucSensorPannelEntry()
        {
            this.InitializeComponent();
            MainPage = (MainPage)Window.Current.Content;
        }

        public void SetPannel(string sType)
        {
            try
            {
                if (sType == "압력")
                {
                    //m_Img.Visibility = Visibility.Collapsed;
                    //m_tbxSensorIconName.Visibility = Visibility.Visible;
                    //m_tbxSensorIconName.Text = "";
                    //m_tbxSensorIconName.FontSize = 20;
                    m_tbxSensorName.Text = "압력";
                }
                else if (sType == "온도")
                {
                    //m_Img.Visibility = Visibility.Collapsed;
                    //m_tbxSensorIconName.Visibility = Visibility.Visible;
                    //m_tbxSensorIconName.Text = "";
                    //m_tbxSensorIconName.FontSize = 20;
                    m_tbxSensorName.Text = "온도";
                }
                else if (sType == "CO2")
                {
                    //m_Img.Visibility = Visibility.Visible;

                    //Uri uri = new Uri("ms-appx:/Img/CO.png", UriKind.RelativeOrAbsolute);
                    //BitmapImage bitmap = new BitmapImage(uri);
                    //m_Img.Source = bitmap;

                    //m_tbxSensorIconName.Visibility = Visibility.Visible;
                    //m_tbxSensorIconName.Text = "";
                    //m_tbxSensorIconName.FontSize = 10;
                    m_tbxSensorName.Text = "CO2";
                }
                else if (sType == "레벨")
                {
                    //m_Img.Visibility = Visibility.Collapsed;
                    //m_tbxSensorIconName.Visibility = Visibility.Visible;
                    //m_tbxSensorIconName.Text = "";
                    //m_tbxSensorIconName.FontSize = 20;
                    m_tbxSensorName.Text = "레벨";
                }
                else if (sType == "전력")
                {
                    //m_Img.Visibility = Visibility.Collapsed;
                    //m_tbxSensorIconName.Visibility = Visibility.Visible;
                    //m_tbxSensorIconName.Text = "";
                    //m_tbxSensorIconName.FontSize = 20;
                    m_tbxSensorName.Text = "전력";
                }
                else if (sType == "연료")
                {
                    //m_Img.Visibility = Visibility.Collapsed;
                    //m_tbxSensorIconName.Visibility = Visibility.Visible;
                    //m_tbxSensorIconName.Text = "";
                    //m_tbxSensorIconName.FontSize = 20;
                    m_tbxSensorName.Text = "연료";
                }
                else if (sType == "습도")
                {
                    //m_Img.Visibility = Visibility.Collapsed;
                    //m_tbxSensorIconName.Visibility = Visibility.Visible;
                    //m_tbxSensorIconName.Text = "";
                    //m_tbxSensorIconName.FontSize = 20;
                    m_tbxSensorName.Text = "습도";
                }
            }
            catch (System.Exception ex)
            {
            	
            }
        }

        public void SetData(string sType, string sData)
        {
            double dwValue;
            try
            {
                MainPage = (MainPage)Window.Current.Content;

                if (sType == "압력")
                {
                    dwValue = EConvert.ToDouble(sData);
                    m_bdSensorIcon.Child = new ucPressure05();
                    //m_bdSensorIcon.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
                    m_tbxSensorValue.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
                    m_tbxSensorValue.Text = string.Format("{0} bar", dwValue);
                }
                else if (sType == "온도")
                {
                    dwValue = EConvert.ToDouble(sData);
                    m_bdSensorIcon.Child = new ucTemperature_04();
                    //m_bdSensorIcon.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 242, 108, 0));
                    m_tbxSensorValue.Foreground = new SolidColorBrush(Color.FromArgb(255, 242, 108, 0));
                    m_tbxSensorValue.Text = string.Format("{0} C", dwValue);
                }
                else if (sType == "레벨")
                {
                    dwValue = EConvert.ToDouble(sData);
                    m_bdSensorIcon.Child = new ucLevel_01();
                    //m_bdSensorIcon.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 32, 230, 64));
                    m_tbxSensorValue.Foreground = new SolidColorBrush(Color.FromArgb(255, 32, 230, 64));
                    m_tbxSensorValue.Text = string.Format("{0} %", dwValue);
                }

                else if (sType == "전력")
                {
                    dwValue = EConvert.ToDouble(sData);
                    m_bdSensorIcon.Child = new ucElectricity_05();
                    //m_bdSensorIcon.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
                    m_tbxSensorValue.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
                    m_tbxSensorValue.Text = string.Format("{0} kwh", dwValue);
                }
                else if (sType == "연료")
                {
                    dwValue = EConvert.ToDouble(sData);
                    m_bdSensorIcon.Child = new ucFuel_04();
                    //m_bdSensorIcon.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 242, 108, 0));
                    m_tbxSensorValue.Foreground = new SolidColorBrush(Color.FromArgb(255, 242, 108, 0));
                    m_tbxSensorValue.Text = string.Format("{0} kg/h", dwValue);
                }

                else if (sType == "온도")
                {
                    dwValue = EConvert.ToDouble(sData);
                    m_bdSensorIcon.Child = new ucTemperature_04();
                    //m_bdSensorIcon.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 242, 108, 0));
                    m_tbxSensorValue.Foreground = new SolidColorBrush(Color.FromArgb(255, 242, 108, 0));
                    m_tbxSensorValue.Text = string.Format("{0} C", dwValue);
                }
                else if (sType == "습도")
                {
                    dwValue = EConvert.ToDouble(sData);
                    m_bdSensorIcon.Child = new ucHumidity_04();
                    //m_bdSensorIcon.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 242, 108, 0));
                    m_tbxSensorValue.Foreground = new SolidColorBrush(Color.FromArgb(255, 242, 108, 0));
                    m_tbxSensorValue.Text = string.Format("{0} %", dwValue);
                }
                else if (sType == "CO2")
                {
                    dwValue = EConvert.ToDouble(sData);
                    m_bdSensorIcon.Child = new ucCO2_01();
                    //m_bdSensorIcon.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 32, 230, 64));
                    m_tbxSensorValue.Foreground = new SolidColorBrush(Color.FromArgb(255, 32, 230, 64));
                    m_tbxSensorValue.Text = string.Format("{0} PPM", dwValue);
                }
            }
            catch (System.Exception ex)
            {
            	
            }
        }

    }
}
