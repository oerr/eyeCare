// <CSHTML5><XamlHash>8D61E169947A161A94BE955E23189CC9</XamlHash><PassNumber>2</PassNumber><CompilationDate>2018-12-29 오후 10:52:07</CompilationDate></CSHTML5>



public static class ǀǀTmsserverǀǀComponentǀǀUcpannel_MainǀǀXamlǀǀFactory
{
    public static object Instantiate()
    {
        global::System.Type type = typeof(TMSServer.ucPannel_Main);
        return global::CSHTML5.Internal.TypeInstantiationHelper.Instantiate(type);
    }
}

namespace TMSServer
{


//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by "C#/XAML for HTML5"
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------



partial class ucPannel_Main : global::Windows.UI.Xaml.Controls.UserControl
{

#pragma warning disable 169, 649, 0628 // Prevents warning CS0169 ('field ... is never used'), CS0649 ('field ... is never assigned to, and will always have its default value null'), and CS0628 ('member : new protected member declared in sealed class')
protected global::Windows.UI.Xaml.Controls.Button m_btnTitle;


#pragma warning restore 169, 649, 0628


        private bool _contentLoaded;
        public void InitializeComponent()
        {
            if (_contentLoaded)
                return;
            _contentLoaded = true;

#pragma warning disable 0184 // Prevents warning CS0184 ('The given expression is never of the provided ('type') type')
            if (this is global::Windows.UI.Xaml.UIElement)
            {
                ((global::Windows.UI.Xaml.UIElement)(object)this).XamlSourcePath = @"TMSServer\ucPannel_Main.xaml";
            }
#pragma warning restore 0184



var Grid_e4638635606d40d9b5112ace07681e08 = new global::Windows.UI.Xaml.Controls.Grid();
var Border_7a1b8d439bd04d15a932609133b9d95c = new global::Windows.UI.Xaml.Controls.Border();
Border_7a1b8d439bd04d15a932609133b9d95c.BorderBrush = (global::Windows.UI.Xaml.Media.Brush)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::Windows.UI.Xaml.Media.Brush), @"#FF919191");
Border_7a1b8d439bd04d15a932609133b9d95c.BorderThickness = (global::Windows.UI.Xaml.Thickness)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::Windows.UI.Xaml.Thickness), @"1");
var Grid_3cb664cb953241f7a1dd748fe8871c6a = new global::Windows.UI.Xaml.Controls.Grid();
var RowDefinition_1dcfa42db71c4a1690c835e13b795937 = new global::Windows.UI.Xaml.Controls.RowDefinition();

var RowDefinition_6aaa75bae4964b68b7f4d9377e4a6e8a = new global::Windows.UI.Xaml.Controls.RowDefinition();
RowDefinition_6aaa75bae4964b68b7f4d9377e4a6e8a.Height = (global::Windows.UI.Xaml.GridLength)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::Windows.UI.Xaml.GridLength), @"3*");

var RowDefinition_0030e9ffde9b4b4fbe9ee85eabec8146 = new global::Windows.UI.Xaml.Controls.RowDefinition();
RowDefinition_0030e9ffde9b4b4fbe9ee85eabec8146.Height = (global::Windows.UI.Xaml.GridLength)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::Windows.UI.Xaml.GridLength), @"0*");

Grid_3cb664cb953241f7a1dd748fe8871c6a.RowDefinitions.Add(RowDefinition_1dcfa42db71c4a1690c835e13b795937);
Grid_3cb664cb953241f7a1dd748fe8871c6a.RowDefinitions.Add(RowDefinition_6aaa75bae4964b68b7f4d9377e4a6e8a);
Grid_3cb664cb953241f7a1dd748fe8871c6a.RowDefinitions.Add(RowDefinition_0030e9ffde9b4b4fbe9ee85eabec8146);

var CheckBox_f25a7520fe3a4f92b6a988d6435041b9 = new global::Windows.UI.Xaml.Controls.CheckBox();
CheckBox_f25a7520fe3a4f92b6a988d6435041b9.Content = (global::System.Object)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::System.Object), @"");
CheckBox_f25a7520fe3a4f92b6a988d6435041b9.VerticalAlignment = global::Windows.UI.Xaml.VerticalAlignment.Top;
CheckBox_f25a7520fe3a4f92b6a988d6435041b9.Height = (global::System.Double)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::System.Double), @"24.96");
CheckBox_f25a7520fe3a4f92b6a988d6435041b9.Margin = (global::Windows.UI.Xaml.Thickness)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::Windows.UI.Xaml.Thickness), @"0,0,5,0");

var Button_a8286237f6474684ab8a7396913efd76 = new global::Windows.UI.Xaml.Controls.Button();
this.RegisterName("m_btnTitle", Button_a8286237f6474684ab8a7396913efd76);
Button_a8286237f6474684ab8a7396913efd76.Name = "m_btnTitle";
Button_a8286237f6474684ab8a7396913efd76.Content = (global::System.Object)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::System.Object), @"봉화 농장 A");
Button_a8286237f6474684ab8a7396913efd76.FontSize = (global::System.Double)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::System.Double), @"16");
Button_a8286237f6474684ab8a7396913efd76.Foreground = (global::Windows.UI.Xaml.Media.Brush)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::Windows.UI.Xaml.Media.Brush), @"White");
Button_a8286237f6474684ab8a7396913efd76.Margin = (global::Windows.UI.Xaml.Thickness)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::Windows.UI.Xaml.Thickness), @"20,0,0,0");
var NullExtension_e1276ba1ccb54cb8b6b15cbb429793a1 = new global::System.Windows.Markup.NullExtension();

Button_a8286237f6474684ab8a7396913efd76.Background = null;


var Grid_f4d947c6ea8944ddb3162f4960b22bbb = new global::Windows.UI.Xaml.Controls.Grid();
Grid_f4d947c6ea8944ddb3162f4960b22bbb.Margin = (global::Windows.UI.Xaml.Thickness)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::Windows.UI.Xaml.Thickness), @"0");
global::Windows.UI.Xaml.Controls.Grid.SetRow(Grid_f4d947c6ea8944ddb3162f4960b22bbb,(global::System.Int32)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::System.Int32), @"1"));
var ColumnDefinition_36f21d8a55764b97899be0c9ef0a48a1 = new global::Windows.UI.Xaml.Controls.ColumnDefinition();
ColumnDefinition_36f21d8a55764b97899be0c9ef0a48a1.Width = (global::Windows.UI.Xaml.GridLength)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::Windows.UI.Xaml.GridLength), @"1*");

var ColumnDefinition_d649d54f01ba4bad919f78da04be438c = new global::Windows.UI.Xaml.Controls.ColumnDefinition();
ColumnDefinition_d649d54f01ba4bad919f78da04be438c.Width = (global::Windows.UI.Xaml.GridLength)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::Windows.UI.Xaml.GridLength), @"1*");

var ColumnDefinition_07b46629114f4581a04da641aef74a8c = new global::Windows.UI.Xaml.Controls.ColumnDefinition();
ColumnDefinition_07b46629114f4581a04da641aef74a8c.Width = (global::Windows.UI.Xaml.GridLength)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::Windows.UI.Xaml.GridLength), @"1*");

Grid_f4d947c6ea8944ddb3162f4960b22bbb.ColumnDefinitions.Add(ColumnDefinition_36f21d8a55764b97899be0c9ef0a48a1);
Grid_f4d947c6ea8944ddb3162f4960b22bbb.ColumnDefinitions.Add(ColumnDefinition_d649d54f01ba4bad919f78da04be438c);
Grid_f4d947c6ea8944ddb3162f4960b22bbb.ColumnDefinitions.Add(ColumnDefinition_07b46629114f4581a04da641aef74a8c);

var RowDefinition_8c65530bdf5a4ffea589ca896ce7e517 = new global::Windows.UI.Xaml.Controls.RowDefinition();
RowDefinition_8c65530bdf5a4ffea589ca896ce7e517.Height = (global::Windows.UI.Xaml.GridLength)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::Windows.UI.Xaml.GridLength), @"40");

var RowDefinition_1470678e52264fbba669b9aa72455028 = new global::Windows.UI.Xaml.Controls.RowDefinition();
RowDefinition_1470678e52264fbba669b9aa72455028.Height = (global::Windows.UI.Xaml.GridLength)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::Windows.UI.Xaml.GridLength), @"*");

Grid_f4d947c6ea8944ddb3162f4960b22bbb.RowDefinitions.Add(RowDefinition_8c65530bdf5a4ffea589ca896ce7e517);
Grid_f4d947c6ea8944ddb3162f4960b22bbb.RowDefinitions.Add(RowDefinition_1470678e52264fbba669b9aa72455028);

var TextBlock_11354d51c8744d6ab94735c68c280559 = new global::Windows.UI.Xaml.Controls.TextBlock();
TextBlock_11354d51c8744d6ab94735c68c280559.Text = @"온도";
TextBlock_11354d51c8744d6ab94735c68c280559.Margin = (global::Windows.UI.Xaml.Thickness)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::Windows.UI.Xaml.Thickness), @"0");
TextBlock_11354d51c8744d6ab94735c68c280559.FontSize = (global::System.Double)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::System.Double), @"16");
TextBlock_11354d51c8744d6ab94735c68c280559.Foreground = (global::Windows.UI.Xaml.Media.Brush)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::Windows.UI.Xaml.Media.Brush), @"White");
TextBlock_11354d51c8744d6ab94735c68c280559.HorizontalAlignment = global::Windows.UI.Xaml.HorizontalAlignment.Center;
TextBlock_11354d51c8744d6ab94735c68c280559.VerticalAlignment = global::Windows.UI.Xaml.VerticalAlignment.Center;

var TextBlock_aadbad2c3d784bfa9b63fe23ae7748a8 = new global::Windows.UI.Xaml.Controls.TextBlock();
TextBlock_aadbad2c3d784bfa9b63fe23ae7748a8.Text = @"습도";
TextBlock_aadbad2c3d784bfa9b63fe23ae7748a8.Margin = (global::Windows.UI.Xaml.Thickness)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::Windows.UI.Xaml.Thickness), @"2,0,10,0");
TextBlock_aadbad2c3d784bfa9b63fe23ae7748a8.FontSize = (global::System.Double)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::System.Double), @"16");
global::Windows.UI.Xaml.Controls.Grid.SetColumn(TextBlock_aadbad2c3d784bfa9b63fe23ae7748a8,(global::System.Int32)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::System.Int32), @"1"));
TextBlock_aadbad2c3d784bfa9b63fe23ae7748a8.Foreground = (global::Windows.UI.Xaml.Media.Brush)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::Windows.UI.Xaml.Media.Brush), @"White");
TextBlock_aadbad2c3d784bfa9b63fe23ae7748a8.HorizontalAlignment = global::Windows.UI.Xaml.HorizontalAlignment.Center;
TextBlock_aadbad2c3d784bfa9b63fe23ae7748a8.VerticalAlignment = global::Windows.UI.Xaml.VerticalAlignment.Center;

var TextBlock_588135384b8f4649b58f7de51e339766 = new global::Windows.UI.Xaml.Controls.TextBlock();
TextBlock_588135384b8f4649b58f7de51e339766.Text = @"CO2";
TextBlock_588135384b8f4649b58f7de51e339766.Margin = (global::Windows.UI.Xaml.Thickness)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::Windows.UI.Xaml.Thickness), @"0");
TextBlock_588135384b8f4649b58f7de51e339766.FontSize = (global::System.Double)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::System.Double), @"16");
global::Windows.UI.Xaml.Controls.Grid.SetColumn(TextBlock_588135384b8f4649b58f7de51e339766,(global::System.Int32)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::System.Int32), @"2"));
TextBlock_588135384b8f4649b58f7de51e339766.Foreground = (global::Windows.UI.Xaml.Media.Brush)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::Windows.UI.Xaml.Media.Brush), @"White");
TextBlock_588135384b8f4649b58f7de51e339766.HorizontalAlignment = global::Windows.UI.Xaml.HorizontalAlignment.Center;
TextBlock_588135384b8f4649b58f7de51e339766.VerticalAlignment = global::Windows.UI.Xaml.VerticalAlignment.Center;

var Grid_745709cf75434f0aad8b2bdfcd5c3f97 = new global::Windows.UI.Xaml.Controls.Grid();
Grid_745709cf75434f0aad8b2bdfcd5c3f97.Margin = (global::Windows.UI.Xaml.Thickness)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::Windows.UI.Xaml.Thickness), @"5,5,2.5,5");
global::Windows.UI.Xaml.Controls.Grid.SetRow(Grid_745709cf75434f0aad8b2bdfcd5c3f97,(global::System.Int32)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::System.Int32), @"1"));
Grid_745709cf75434f0aad8b2bdfcd5c3f97.Background = (global::Windows.UI.Xaml.Media.Brush)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::Windows.UI.Xaml.Media.Brush), @"Lime");
var TextBlock_c6fa1dda050d4f9daee9b758bc6927a3 = new global::Windows.UI.Xaml.Controls.TextBlock();
TextBlock_c6fa1dda050d4f9daee9b758bc6927a3.Text = @"23도";
TextBlock_c6fa1dda050d4f9daee9b758bc6927a3.FontSize = (global::System.Double)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::System.Double), @"16");
TextBlock_c6fa1dda050d4f9daee9b758bc6927a3.Foreground = (global::Windows.UI.Xaml.Media.Brush)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::Windows.UI.Xaml.Media.Brush), @"White");
TextBlock_c6fa1dda050d4f9daee9b758bc6927a3.Padding = (global::Windows.UI.Xaml.Thickness)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::Windows.UI.Xaml.Thickness), @"5");
TextBlock_c6fa1dda050d4f9daee9b758bc6927a3.HorizontalAlignment = global::Windows.UI.Xaml.HorizontalAlignment.Center;
TextBlock_c6fa1dda050d4f9daee9b758bc6927a3.VerticalAlignment = global::Windows.UI.Xaml.VerticalAlignment.Center;

Grid_745709cf75434f0aad8b2bdfcd5c3f97.Children.Add(TextBlock_c6fa1dda050d4f9daee9b758bc6927a3);


var Grid_5013424f486c490bb26f2f5da09df7c6 = new global::Windows.UI.Xaml.Controls.Grid();
global::Windows.UI.Xaml.Controls.Grid.SetColumn(Grid_5013424f486c490bb26f2f5da09df7c6,(global::System.Int32)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::System.Int32), @"1"));
Grid_5013424f486c490bb26f2f5da09df7c6.Margin = (global::Windows.UI.Xaml.Thickness)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::Windows.UI.Xaml.Thickness), @"2.5,5,5,5");
global::Windows.UI.Xaml.Controls.Grid.SetRow(Grid_5013424f486c490bb26f2f5da09df7c6,(global::System.Int32)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::System.Int32), @"1"));
Grid_5013424f486c490bb26f2f5da09df7c6.Background = (global::Windows.UI.Xaml.Media.Brush)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::Windows.UI.Xaml.Media.Brush), @"#FF0800FF");
var TextBlock_1eefbd466e50409480143741eca05706 = new global::Windows.UI.Xaml.Controls.TextBlock();
TextBlock_1eefbd466e50409480143741eca05706.Text = @"50%";
TextBlock_1eefbd466e50409480143741eca05706.FontSize = (global::System.Double)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::System.Double), @"16");
TextBlock_1eefbd466e50409480143741eca05706.Foreground = (global::Windows.UI.Xaml.Media.Brush)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::Windows.UI.Xaml.Media.Brush), @"White");
TextBlock_1eefbd466e50409480143741eca05706.Padding = (global::Windows.UI.Xaml.Thickness)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::Windows.UI.Xaml.Thickness), @"5");
TextBlock_1eefbd466e50409480143741eca05706.HorizontalAlignment = global::Windows.UI.Xaml.HorizontalAlignment.Center;
TextBlock_1eefbd466e50409480143741eca05706.VerticalAlignment = global::Windows.UI.Xaml.VerticalAlignment.Center;

Grid_5013424f486c490bb26f2f5da09df7c6.Children.Add(TextBlock_1eefbd466e50409480143741eca05706);


var Grid_ee43a6cc444a4a44bb33acdb44a8ebfe = new global::Windows.UI.Xaml.Controls.Grid();
global::Windows.UI.Xaml.Controls.Grid.SetColumn(Grid_ee43a6cc444a4a44bb33acdb44a8ebfe,(global::System.Int32)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::System.Int32), @"2"));
Grid_ee43a6cc444a4a44bb33acdb44a8ebfe.Margin = (global::Windows.UI.Xaml.Thickness)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::Windows.UI.Xaml.Thickness), @"2.5,5,5,5");
global::Windows.UI.Xaml.Controls.Grid.SetRow(Grid_ee43a6cc444a4a44bb33acdb44a8ebfe,(global::System.Int32)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::System.Int32), @"1"));
Grid_ee43a6cc444a4a44bb33acdb44a8ebfe.Background = (global::Windows.UI.Xaml.Media.Brush)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::Windows.UI.Xaml.Media.Brush), @"Red");
var TextBlock_ca52e5932e204ce7b30b809987d38438 = new global::Windows.UI.Xaml.Controls.TextBlock();
TextBlock_ca52e5932e204ce7b30b809987d38438.Text = @"200PPM";
TextBlock_ca52e5932e204ce7b30b809987d38438.FontSize = (global::System.Double)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::System.Double), @"16");
TextBlock_ca52e5932e204ce7b30b809987d38438.Foreground = (global::Windows.UI.Xaml.Media.Brush)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::Windows.UI.Xaml.Media.Brush), @"White");
TextBlock_ca52e5932e204ce7b30b809987d38438.Padding = (global::Windows.UI.Xaml.Thickness)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::Windows.UI.Xaml.Thickness), @"5");
TextBlock_ca52e5932e204ce7b30b809987d38438.HorizontalAlignment = global::Windows.UI.Xaml.HorizontalAlignment.Center;
TextBlock_ca52e5932e204ce7b30b809987d38438.VerticalAlignment = global::Windows.UI.Xaml.VerticalAlignment.Center;

Grid_ee43a6cc444a4a44bb33acdb44a8ebfe.Children.Add(TextBlock_ca52e5932e204ce7b30b809987d38438);


Grid_f4d947c6ea8944ddb3162f4960b22bbb.Children.Add(TextBlock_11354d51c8744d6ab94735c68c280559);
Grid_f4d947c6ea8944ddb3162f4960b22bbb.Children.Add(TextBlock_aadbad2c3d784bfa9b63fe23ae7748a8);
Grid_f4d947c6ea8944ddb3162f4960b22bbb.Children.Add(TextBlock_588135384b8f4649b58f7de51e339766);
Grid_f4d947c6ea8944ddb3162f4960b22bbb.Children.Add(Grid_745709cf75434f0aad8b2bdfcd5c3f97);
Grid_f4d947c6ea8944ddb3162f4960b22bbb.Children.Add(Grid_5013424f486c490bb26f2f5da09df7c6);
Grid_f4d947c6ea8944ddb3162f4960b22bbb.Children.Add(Grid_ee43a6cc444a4a44bb33acdb44a8ebfe);


var Button_70563e9d320d4a18aadd97a3ec503e78 = new global::Windows.UI.Xaml.Controls.Button();
Button_70563e9d320d4a18aadd97a3ec503e78.Content = (global::System.Object)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::System.Object), @"감지 화면");
Button_70563e9d320d4a18aadd97a3ec503e78.FontSize = (global::System.Double)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::System.Double), @"16");
Button_70563e9d320d4a18aadd97a3ec503e78.Foreground = (global::Windows.UI.Xaml.Media.Brush)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::Windows.UI.Xaml.Media.Brush), @"White");
Button_70563e9d320d4a18aadd97a3ec503e78.Margin = (global::Windows.UI.Xaml.Thickness)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::Windows.UI.Xaml.Thickness), @"0");
global::Windows.UI.Xaml.Controls.Grid.SetRow(Button_70563e9d320d4a18aadd97a3ec503e78,(global::System.Int32)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::System.Int32), @"2"));
Button_70563e9d320d4a18aadd97a3ec503e78.Visibility = global::Windows.UI.Xaml.Visibility.Collapsed;
var NullExtension_7175902653f94f469751d16330854cc6 = new global::System.Windows.Markup.NullExtension();

Button_70563e9d320d4a18aadd97a3ec503e78.Background = null;


Grid_3cb664cb953241f7a1dd748fe8871c6a.Children.Add(CheckBox_f25a7520fe3a4f92b6a988d6435041b9);
Grid_3cb664cb953241f7a1dd748fe8871c6a.Children.Add(Button_a8286237f6474684ab8a7396913efd76);
Grid_3cb664cb953241f7a1dd748fe8871c6a.Children.Add(Grid_f4d947c6ea8944ddb3162f4960b22bbb);
Grid_3cb664cb953241f7a1dd748fe8871c6a.Children.Add(Button_70563e9d320d4a18aadd97a3ec503e78);


Border_7a1b8d439bd04d15a932609133b9d95c.Child = Grid_3cb664cb953241f7a1dd748fe8871c6a;


Grid_e4638635606d40d9b5112ace07681e08.Children.Add(Border_7a1b8d439bd04d15a932609133b9d95c);


this.Content = Grid_e4638635606d40d9b5112ace07681e08;



m_btnTitle = Button_a8286237f6474684ab8a7396913efd76;


    
        }


}


}