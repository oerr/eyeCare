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
    /// ucMain.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ucMain : UserControl
    {
        public ucMain()
        {
            InitializeComponent();

            this.m_ucBtnAdd.TextColor = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            this.m_ucBtnRemove.TextColor = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            this.m_ucBtnRename.TextColor = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            
            this.Loaded += ucMain_Loaded;
        }

        void ucMain_Loaded(object sender, RoutedEventArgs e)
        {
            //CSHTML5.Interop.ExecuteJavaScript(@"document.getElementById('cshtml5-root').style.heighth='500px' "); -> 아래로 해도 됨.
            //this.Width = 2000;
            //this.Height = 3000;
        }
    }
}
