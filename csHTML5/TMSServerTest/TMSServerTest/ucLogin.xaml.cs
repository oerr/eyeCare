using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TMSServerTest
{
    /// <summary>
    /// ucLogin.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ucLogin : UserControl
    {
        public ucLogin()
        {
            InitializeComponent();
            this.m_ucBtnOK.ImgSrc = "/TMSServerTest;component/Img/Button_01.png";
            this.m_ucBtnOK.TextColor = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            this.m_ucBtnOK.EvtClicked += m_ucBtnOK_EvtClicked;

            this.m_ucBtnChangePwd.ImgSrc = "/TMSServerTest;component/Img/Button_02.png";
            this.m_ucBtnChangePwd.TextColor = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            this.m_ucBtnChangePwd.EvtClicked += m_ucBtnChangePwd_EvtClicked;
        }

        void m_ucBtnOK_EvtClicked(object sender, ButtonArgs e)
        {
            MainWindow MainPage = (MainWindow)App.Current.MainWindow;
            //MainPage.ChangeMain(new ucMain()); 
            MainPage.ChangeMain(new ucHistory()); 
        }

        void m_ucBtnChangePwd_EvtClicked(object sender, ButtonArgs e)
        {
            MainWindow MainPage = (MainWindow)App.Current.MainWindow;
            MainPage.ChangeMain(new ucChangePwd());
        }
    }
}
