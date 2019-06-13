using CSHTML5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSHTML5.Native.Html.Controls;



namespace TMSServer
{
    public class VideoCtrl : HtmlPresenter
    {
        private string _VideoUrl = "";

        public string VideoUrl
        {
            get
            {
                if (this.DomElement != null) //Note: the DOM element is null if the control has not been added to the visual tree yet.
                {
                    string valueString = Interop.ExecuteJavaScript("$0.src", this.DomElement).ToString();
                    _VideoUrl = valueString;
                }
                return _VideoUrl;
            }
            set
            {
                _VideoUrl = value;

                if (this.DomElement != null) //Note: the DOM element is null if the control has not been added to the visual tree yet.
                    Interop.ExecuteJavaScript("$0.src = $1", this.DomElement, _VideoUrl);
            }
        }

        public VideoCtrl()
        {
            this.Html = string.Format(@"<video  width='100%' height='100%'  type='video/mp4' controls autoplay> </video>"); 

            this.Loaded += VideoCtrl_Loaded;
        }

        void VideoCtrl_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Interop.ExecuteJavaScript("$0.src = $1", this.DomElement, _VideoUrl);
        }

    }
}
