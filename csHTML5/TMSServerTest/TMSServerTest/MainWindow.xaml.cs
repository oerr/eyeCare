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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TMSServerTest
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        bool m_bMobile;
        UserControl m_ucUserCtrl = null;

        public MainWindow()
        {
            this.InitializeComponent();
            m_Container.Children.Clear();
            m_Container.Children.Add(new ucLogin());
        }

        public void ChangeMain(UserControl ucCtrl)
        {
            try
            {
                m_Container.Children.Clear();
                m_Container.Children.Add(ucCtrl);
            }
            catch (System.Exception ex)
            {
            }
        }

   
    }
}
