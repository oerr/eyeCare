using System;
using System.ComponentModel;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Windows.UI.Xaml.Media;

namespace TMSServer
{
    public class HouseStateEntry : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };


        public string _House;
        public string House 
        {
            get
            {
                return _House;
            }

            set
            {
                try
                {
                    _House = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("House"));
                }
                catch (System.Exception ex) {}
            }
        }
        public int SensorCnt { get; set; }
        public string NotiStep { get; set; }
        public string SensorState { get; set; }

        public Brush NotiColor { get; set; }
        public Brush SensorColor { get; set; }
        
        
              
    }
}
