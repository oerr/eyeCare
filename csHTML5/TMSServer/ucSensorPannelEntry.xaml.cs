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
                if (sType == "NOX")
                {
                    m_tbxSensorName.Text = "질소산화물";
                }
                else if (sType == "CO")
                {
                    m_tbxSensorName.Text = "일산화탄소";
                }
                else if (sType == "CO2")
                {
                    m_tbxSensorName.Text = "CO2";
                }
                else if (sType == "FINEDUST")
                {
                    m_tbxSensorName.Text = "미세먼지";
                }
            }
            catch (System.Exception ex)
            {
            	
            }
        }

        public void SetData(string sType, string sData)
        {
            try
            {
                MainPage = (MainPage)Window.Current.Content;

                if (sType == "NOX")
                {
                    double dwNOX = EConvert.ToDouble(sData);
                    if (dwNOX < MainPage.m_lstMaxNOX[0])
                    {
                        m_bdSensorIcon.Child = new ucNOX_01();
                        m_tbxSensorValue.Foreground =  new SolidColorBrush(Color.FromArgb(255, 32, 230, 64));
                    }
                    else if (dwNOX >= MainPage.m_lstMaxNOX[0] && dwNOX <= MainPage.m_lstMaxNOX[1])
                    {
                        m_bdSensorIcon.Child = new ucNOX_02();
                        m_tbxSensorValue.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 146, 255));
                    }
                    else if (dwNOX >= MainPage.m_lstMaxNOX[1] && dwNOX <= MainPage.m_lstMaxNOX[2])
                    {
                        m_bdSensorIcon.Child = new ucNOX_03();
                        m_tbxSensorValue.Foreground = new SolidColorBrush(Color.FromArgb(255, 237, 248, 0));
                    }
                    else if (dwNOX >= MainPage.m_lstMaxNOX[2] && dwNOX <= MainPage.m_lstMaxNOX[3])
                    {
                        m_bdSensorIcon.Child = new ucNOX_04();
                        m_tbxSensorValue.Foreground = new SolidColorBrush(Color.FromArgb(255, 242, 108, 0));
                    }
                    else if (dwNOX >= MainPage.m_lstMaxNOX[3])
                    {
                        m_bdSensorIcon.Child = new ucNOX_05();
                        m_tbxSensorValue.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
                    }
                    else
                    {
                        m_bdSensorIcon.Child = new ucNOX_05();
                    }
                    //m_tbxSensorValue.Text = string.Format("{0:00.0} PPM", dwNOX);
                    //m_tbxSensorValue.Text = string.Format("{0:0.#} PPM", dwNOX);
                    m_tbxSensorValue.Text = string.Format("{0:0} PPM", dwNOX);
                    
                }
                else if (sType == "CO")
                {
                    double dwCO = EConvert.ToDouble(sData);
                    if (dwCO < MainPage.m_lstMaxCO[0])
                    {
                        m_bdSensorIcon.Child = new ucCO_01();
                        m_tbxSensorValue.Foreground = new SolidColorBrush(Color.FromArgb(255, 32, 230, 64));
                    }
                    else if (dwCO >= MainPage.m_lstMaxCO[0] && dwCO <= MainPage.m_lstMaxCO[1])
                    {
                        m_bdSensorIcon.Child = new ucCO_02();
                        m_tbxSensorValue.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 146, 255));
                    }
                    else if (dwCO >= MainPage.m_lstMaxCO[1] && dwCO <= MainPage.m_lstMaxCO[2])
                    {
                        m_bdSensorIcon.Child = new ucCO_03();
                        m_tbxSensorValue.Foreground = new SolidColorBrush(Color.FromArgb(255, 237, 248, 0));
                    }
                    else if (dwCO >= MainPage.m_lstMaxCO[2] && dwCO <= MainPage.m_lstMaxCO[3])
                    {
                        m_bdSensorIcon.Child = new ucCO_04();
                        m_tbxSensorValue.Foreground = new SolidColorBrush(Color.FromArgb(255, 242, 108, 0));
                    }
                    else if (dwCO >= MainPage.m_lstMaxCO[3])
                    {
                        m_bdSensorIcon.Child = new ucCO_05();
                        m_tbxSensorValue.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
                    }
                    else
                    {
                        m_bdSensorIcon.Child = new ucCO_05();
                        m_tbxSensorValue.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
                    }
                    //m_tbxSensorValue.Text = string.Format("{0:00.0} PPM", dwCO);
                    //m_tbxSensorValue.Text = string.Format("{0:0.#} PPM", dwCO);
                    m_tbxSensorValue.Text = string.Format("{0:0} PPM", dwCO);
                }
                else if (sType == "CO2")
                {
                    double dwCO2 = EConvert.ToDouble(sData);
                    if (dwCO2 < MainPage.m_lstMaxCO2[0])
                    {
                        m_bdSensorIcon.Child = new ucCO2_01();
                        m_tbxSensorValue.Foreground = new SolidColorBrush(Color.FromArgb(255, 32, 230, 64));
                    }
                    else if (dwCO2 >= MainPage.m_lstMaxCO2[0] && dwCO2 <= MainPage.m_lstMaxCO2[1])
                    {
                        m_bdSensorIcon.Child = new ucCO2_02();
                        m_tbxSensorValue.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 146, 255));
                    }
                    else if (dwCO2 >= MainPage.m_lstMaxCO2[1] && dwCO2 <= MainPage.m_lstMaxCO2[2])
                    {
                        m_bdSensorIcon.Child = new ucCO2_03();
                        m_tbxSensorValue.Foreground = new SolidColorBrush(Color.FromArgb(255, 237, 248, 0));
                    }
                    else if (dwCO2 >= MainPage.m_lstMaxCO2[2] && dwCO2 <= MainPage.m_lstMaxCO2[3])
                    {
                        m_bdSensorIcon.Child = new ucCO2_04();
                        m_tbxSensorValue.Foreground = new SolidColorBrush(Color.FromArgb(255, 242, 108, 0));
                    }
                    else if (dwCO2 >= MainPage.m_lstMaxCO2[3])
                    {
                        m_bdSensorIcon.Child = new ucCO2_05();
                        m_tbxSensorValue.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
                    }
                    else
                    {
                        m_bdSensorIcon.Child = new ucCO2_05();
                        m_tbxSensorValue.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
                    }

                    //m_tbxSensorValue.Text = string.Format("{0:00.0} PPM", dwCO2);
                    //m_tbxSensorValue.Text = string.Format("{0:0.#} PPM", dwCO2);
                    m_tbxSensorValue.Text = string.Format("{0:0} PPM", dwCO2);
                }
                else if (sType == "FINEDUST")
                {
                    //미세먼지 2.5 수치 사용
                    double dwFineDust2_5 = EConvert.ToDouble(SuperString.StringParser.GetNthStr(sData, 2, "(2.5)"));

                    if (dwFineDust2_5 < MainPage.m_lstMaxFineDust2_5[0])
                    {
                        m_bdSensorIcon.Child = new ucFineDust_01();
                        m_tbxSensorValue.Foreground = new SolidColorBrush(Color.FromArgb(255, 32, 230, 64));
                    }
                    else if (dwFineDust2_5 >= MainPage.m_lstMaxFineDust2_5[0] && dwFineDust2_5 <= MainPage.m_lstMaxFineDust2_5[1])
                    {
                        m_bdSensorIcon.Child = new ucFineDust_02();
                        m_tbxSensorValue.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 146, 255));
                    }
                    else if (dwFineDust2_5 >= MainPage.m_lstMaxFineDust2_5[1] && dwFineDust2_5 <= MainPage.m_lstMaxFineDust2_5[2])
                    {
                        m_bdSensorIcon.Child = new ucFineDust_03();
                        m_tbxSensorValue.Foreground = new SolidColorBrush(Color.FromArgb(255, 237, 248, 0));
                    }
                    else if (dwFineDust2_5 >= MainPage.m_lstMaxFineDust2_5[2] && dwFineDust2_5 <= MainPage.m_lstMaxFineDust2_5[3])
                    {
                        m_bdSensorIcon.Child = new ucFineDust_04();
                        m_tbxSensorValue.Foreground = new SolidColorBrush(Color.FromArgb(255, 242, 108, 0));
                    }
                    else if (dwFineDust2_5 >= MainPage.m_lstMaxFineDust2_5[3])
                    {
                        m_bdSensorIcon.Child = new ucFineDust_05();
                        m_tbxSensorValue.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
                    }
                    else
                    {
                        m_bdSensorIcon.Child = new ucFineDust_05();
                        m_tbxSensorValue.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
                    }

                    //m_tbxSensorValue.Text = string.Format("{0:00.0} ㎛", dwFineDust2_5);
                    //m_tbxSensorValue.Text = string.Format("{0:0.#} ㎛", dwFineDust2_5);
                    m_tbxSensorValue.Text = string.Format("{0:0} ㎛", dwFineDust2_5);

                    //미세먼지 수치㎛
                }
            }
            catch (System.Exception ex)
            {
            	
            }
        }

    }
}
