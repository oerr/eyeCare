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
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace TMSServerTest
{
    //xaml TMSServerTest: assembly
    //<local:ucButton IsShadow="True" ImgSrc = "/TMSServerTest;component/Img/Button_01.png" TextHorizentalAllignment="Center"  TextVerticalAllignment="Center" TextMargin="30,0,0,0" TextSize="15" Text="안녕" IsTextBold="True" />

    //cs
    //this.m_ucButton.TextColor = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 155, 0, 0));
    //this.m_ucButton.EvtClicked += m_ucButton_EvtClicked;

    public class ButtonArgs : EventArgs
    {
        public string e { get; set; }

        public ButtonArgs(string param)
        {
            this.e = param;
        }
    }


    /// <summary>
    /// ucButton.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ucButton : UserControl
    {
        Storyboard m_Storyboard = null;

        public event EventHandler<ButtonArgs> EvtClicked;

        //this.m_ucButton.ImgSrc = "ms-appx:/Img/1.png"; 이렇게 사용
        public string _ImgSrc;
        public string ImgSrc
        {
            get
            {
                return _ImgSrc;
            }

            set
            {
                try
                {
                    this.m_Img.Visibility = Visibility.Visible;
                    _ImgSrc = value;
                    Uri uri = new Uri(_ImgSrc, UriKind.RelativeOrAbsolute);
                    BitmapImage bitmap = new BitmapImage(uri);
                    m_Img.Source = bitmap;
                }
                catch (System.Exception ex) { }
            }
        }

        public string _Text;
        public string Text
        {
            get
            {
                return _Text;
            }

            set
            {
                try
                {
                    _Text = value;
                    m_tbxText.Text = _Text;
                }
                catch (System.Exception ex) { }
            }
        }

        public string _TextMargin;
        public string TextMargin
        {
            get
            {
                return _TextMargin;
            }

            set
            {
                try
                {
                    _TextMargin = value;
                    double dwLeft   = Convert.ToDouble(GetNthStr(_TextMargin, 1, ","));
                    double dwTop    = Convert.ToDouble(GetNthStr(_TextMargin, 2, ","));
                    double dwRight  = Convert.ToDouble(GetNthStr(_TextMargin, 3, ","));
                    double dwBottom = Convert.ToDouble(GetNthStr(_TextMargin, 3, ","));
                    m_tbxText.Margin = new Thickness(dwLeft, dwTop, dwRight, dwBottom);
                }
                catch (System.Exception ex) { }
            }
        }

        private Brush _TextColor;

        public Brush TextColor
        {
            get
            {
                return _TextColor;
            }

            set
            {
                try
                {
                    _TextColor = value;

                    //m_tbxText.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(TextColor));
                    //string sTextColor = _TextColor;
                    //sTextColor = sTextColor.Replace("#", "");
                    //int nAlpha = Convert.ToInt32(Mid(sTextColor, 0, 2), 16);
                    //int nRed   = Convert.ToInt32(Mid(sTextColor, 2, 2), 16);
                    //int nGreen = Convert.ToInt32(Mid(sTextColor, 4, 2), 16);
                    //int nBlue  = Convert.ToInt32(Mid(sTextColor, 6, 2), 16);
                    //csHTML5 버그.. 씨뱅이들.. -> 변수지원 안함.
                    //m_tbxText.Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb((byte)nAlpha, (byte)nRed, (byte)nGreen, (byte)nBlue));
                    //m_tbxText.Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb(255,0, 0, 0));
                    m_tbxText.Foreground = _TextColor;
                }
                catch (System.Exception ex) { }
            }
        }

        //10
        public string _TextSize;
        public string TextSize
        {
            get
            {
                return _TextSize;
            }

            set
            {
                try
                {
                    _TextSize = value;
                    m_tbxText.FontSize = Convert.ToDouble(_TextSize);
                }
                catch (System.Exception ex) { }
            }
        }

        //Left or Center or Right
        public string _TextHorizentalAllignment;
        public string TextHorizentalAllignment
        {
            get
            {
                return _TextHorizentalAllignment;
            }

            set
            {
                try
                {
                    _TextHorizentalAllignment = value;
                    if (_TextHorizentalAllignment == "Left")
                        m_tbxText.HorizontalAlignment = HorizontalAlignment.Left;
                    else if (_TextHorizentalAllignment == "Center")
                        m_tbxText.HorizontalAlignment = HorizontalAlignment.Strectch;
                    else if (_TextHorizentalAllignment == "Right")
                        m_tbxText.HorizontalAlignment = HorizontalAlignment.Right;
                }
                catch (System.Exception ex) { }
            }
        }

        //Top or Center or Bottom
        public string _TextVerticalAllignment;
        public string TextVerticalAllignment
        {
            get
            {
                return _TextVerticalAllignment;
            }

            set
            {
                try
                {
                    _TextVerticalAllignment = value;
                    if (_TextVerticalAllignment == "Top")
                        m_tbxText.VerticalAlignment = VerticalAlignment.Top;
                    else if (_TextVerticalAllignment == "Center")
                        m_tbxText.VerticalAlignment = VerticalAlignment.Center;
                    else if (_TextVerticalAllignment == "Bottom")
                        m_tbxText.VerticalAlignment = VerticalAlignment.Bottom;
                }
                catch (System.Exception ex) { }
            }
        }


        public string _IsTextBold;
        public string IsTextBold
        {
            get
            {
                return _IsTextBold;
            }

            set
            {
                try
                {
                    _IsTextBold = value;

                    string sbTextBold = _IsTextBold.ToLower(); //true or false
                    if (sbTextBold == "true")
                        m_tbxText.FontWeight = FontWeights.Bold;
                    else
                    {
                        m_tbxText.FontWeight = FontWeights.Normal;
                    }

                }
                catch (System.Exception ex) { }
            }
        }



        public string _IsShadow;
        public string IsShadow
        {
            get
            {
                return _IsShadow;
            }

            set
            {
                try
                {
                    _IsShadow = value;

                    string sbShadow = _IsShadow.ToLower(); //true or false
                    if (sbShadow == "false")
                        grid.Effect = null;
                    else
                    {
                        DropShadowEffect effect = new DropShadowEffect();
                        effect.BlurRadius = 5;
                        effect.Color = Color.FromArgb(255, 0, 0, 0);
                        effect.Direction = 315;
                        effect.Opacity = 255;
                        //effect.RenderingBias = RenderingBias.Performance;
                        effect.ShadowDepth = 5;
                        grid.Effect = effect;
                    }

                }
                catch (System.Exception ex) { }
            }
        }


        public ucButton()
        {
            this.InitializeComponent();

            this.m_Img.Visibility = Visibility.Collapsed;

            m_Storyboard = this.Resources["stHighlite"] as Storyboard;

            //this.m_btn.MouseEnter += m_btn_MouseEnter;
            //this.m_btn.MouseLeave += m_btn_MouseLeave;
            this.m_btn.PreviewMouseLeftButtonDown += m_btn_PreviewMouseLeftButtonDown;
            this.m_btn.PreviewMouseLeftButtonUp += m_btn_PreviewMouseLeftButtonUp;
        }

        public string GetNthStr(string sSource, int nFrom, string sBase)
        {
            try
            {
                string[] sARet = sSource.Split(new string[] { sBase }, StringSplitOptions.None);
                return sARet[nFrom - 1];
            }
            catch (System.Exception ex)
            {
                return "";
            }
        }

        public static string Left(string str, int len)
        {
            string convertStr;
            if (str.Length < len)
                len = str.Length;

            convertStr = str.Substring(0, len);

            return convertStr;
        }

        /// <summary>
        /// VB에서 RIGHT 기능
        /// </summary>
        /// <param name="str">문자열</param>
        /// <param name="len">자르고자 하는 수</param>
        /// <returns></returns>
        public static string Right(string str, int len)
        {
            string convertStr;
            if (str.Length < len)
                len = str.Length;

            convertStr = str.Substring(str.Length - len, len);

            return convertStr;
        }

        /// <summary>
        /// VB에서 MID 기능
        /// </summary>
        /// <param name="str">문자열</param>
        /// <param name="startInt">시작 Index</param>
        /// <param name="endInt">종료 Index</param>
        /// <returns></returns>
        public static string Mid(string str, int startInt, int endInt)
        {
            string convertStr;
            if (startInt < str.Length || endInt < str.Length)
            {
                convertStr = str.Substring(startInt, endInt);
                return convertStr;
            }
            else
                return str;
        }
        public static string Mid(string str, int startInt)
        {
            int endInt = str.Length - startInt;
            string convertStr;
            if (startInt < str.Length || endInt < str.Length)
            {
                convertStr = str.Substring(startInt, endInt);
                return convertStr;
            }
            else
                return str;
        }




        void Leave()
        {
            try
            {
                //if (m_Storyboard != null)
                //{
                //    m_Storyboard.Stop(this);
                //}
            }
            catch (System.Exception ex)
            {

            }
        }
        void m_btn_MouseLeave(object sender, MouseEventArgs e)
        {
            Leave();
        }

        void Entered()
        {
            try
            {
                //if (m_Storyboard != null)
                //{
                //    //지원 안함.
                //    //stybd.RepeatBehavior = RepeatBehavior.Forever;
                //    m_Storyboard.Begin();
                //}
            }
            catch (System.Exception ex)
            {
            }
        }
        void m_btn_MouseEnter(object sender, MouseEventArgs e)
        {
            Entered();
        }

        void ButtonUp()
        {
            try
            {
                this.RenderTransformOrigin = new Point(0.5, 0.5);
                TranslateTransform transform = new TranslateTransform();
                transform.X = 0;
                transform.Y = 0;
                this.RenderTransform = transform;

                var timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(10) };
                timer.Tick += (senderTimer, args) =>
                {
                    timer.Stop();

                    ButtonArgs argsBtn = new ButtonArgs("");
                    if (EvtClicked != null)
                    {
                        EvtClicked(this, argsBtn);
                    }

                };
                timer.Start();
            }
            catch (System.Exception ex)
            {
            }
        }
        void m_btn_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ButtonUp();
        }

        void ButtonDown()
        {
            try
            {
                this.RenderTransformOrigin = new Point(0.5, 0.5);
                TranslateTransform transform = new TranslateTransform();
                transform.X = 1;
                transform.Y = 1;
                this.RenderTransform = transform;
            }
            catch (System.Exception ex)
            {
            }
        }

        void m_btn_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ButtonDown();
        }

    }
}
