// <CSHTML5><XamlHash>51CC432FE2C1914548E6AD3C8BD87331</XamlHash><PassNumber>2</PassNumber><CompilationDate>2018-12-29 오후 10:52:07</CompilationDate></CSHTML5>



public static class ǀǀTmsserverǀǀComponentǀǀWndselectrecmovieǀǀXamlǀǀFactory
{
    public static object Instantiate()
    {
        global::System.Type type = typeof(TMSServer.wndSelectRecMovie);
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



partial class wndSelectRecMovie : global::Windows.UI.Xaml.Controls.ChildWindow
{

#pragma warning disable 169, 649, 0628 // Prevents warning CS0169 ('field ... is never used'), CS0649 ('field ... is never assigned to, and will always have its default value null'), and CS0628 ('member : new protected member declared in sealed class')
protected global::Windows.UI.Xaml.Controls.DataGrid m_dgMain;
protected global::Windows.UI.Xaml.Controls.Grid LayoutRoot;


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
                ((global::Windows.UI.Xaml.UIElement)(object)this).XamlSourcePath = @"TMSServer\wndSelectRecMovie.xaml";
            }
#pragma warning restore 0184



this.Width = (global::System.Double)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::System.Double), @"400");
this.Height = (global::System.Double)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::System.Double), @"300");
this.Title = (global::System.Object)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::System.Object), @"저장된 영상 선택");
this.FontSize = (global::System.Double)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::System.Double), @"16");
var Grid_e42f975fbd3845e0b4a4e8862136cc71 = new global::Windows.UI.Xaml.Controls.Grid();
this.RegisterName("LayoutRoot", Grid_e42f975fbd3845e0b4a4e8862136cc71);
Grid_e42f975fbd3845e0b4a4e8862136cc71.Name = "LayoutRoot";
Grid_e42f975fbd3845e0b4a4e8862136cc71.Background = (global::Windows.UI.Xaml.Media.Brush)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::Windows.UI.Xaml.Media.Brush), @"#FF292828");
var Grid_e66439015ea7461f957e729a009ab8db = new global::Windows.UI.Xaml.Controls.Grid();
var RowDefinition_741e541fff624232ac17ff21c14bf680 = new global::Windows.UI.Xaml.Controls.RowDefinition();
RowDefinition_741e541fff624232ac17ff21c14bf680.Height = (global::Windows.UI.Xaml.GridLength)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::Windows.UI.Xaml.GridLength), @"20");

var RowDefinition_8ab78e5a854d41fe8818f28e8ece0926 = new global::Windows.UI.Xaml.Controls.RowDefinition();
RowDefinition_8ab78e5a854d41fe8818f28e8ece0926.Height = (global::Windows.UI.Xaml.GridLength)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::Windows.UI.Xaml.GridLength), @"37");

var RowDefinition_c71fcd9c24a849df8a0d6b889711ab85 = new global::Windows.UI.Xaml.Controls.RowDefinition();
RowDefinition_c71fcd9c24a849df8a0d6b889711ab85.Height = (global::Windows.UI.Xaml.GridLength)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::Windows.UI.Xaml.GridLength), @"23");

var RowDefinition_608dfe084b3e44e39e4f5c328f896b72 = new global::Windows.UI.Xaml.Controls.RowDefinition();

var RowDefinition_09d2930bfea44b419d54fc5fda703af8 = new global::Windows.UI.Xaml.Controls.RowDefinition();
RowDefinition_09d2930bfea44b419d54fc5fda703af8.Height = (global::Windows.UI.Xaml.GridLength)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::Windows.UI.Xaml.GridLength), @"20");

Grid_e66439015ea7461f957e729a009ab8db.RowDefinitions.Add(RowDefinition_741e541fff624232ac17ff21c14bf680);
Grid_e66439015ea7461f957e729a009ab8db.RowDefinitions.Add(RowDefinition_8ab78e5a854d41fe8818f28e8ece0926);
Grid_e66439015ea7461f957e729a009ab8db.RowDefinitions.Add(RowDefinition_c71fcd9c24a849df8a0d6b889711ab85);
Grid_e66439015ea7461f957e729a009ab8db.RowDefinitions.Add(RowDefinition_608dfe084b3e44e39e4f5c328f896b72);
Grid_e66439015ea7461f957e729a009ab8db.RowDefinitions.Add(RowDefinition_09d2930bfea44b419d54fc5fda703af8);

var Grid_0a1ec54534234f4697ce24d6582c180b = new global::Windows.UI.Xaml.Controls.Grid();
global::Windows.UI.Xaml.Controls.Grid.SetRow(Grid_0a1ec54534234f4697ce24d6582c180b,(global::System.Int32)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::System.Int32), @"1"));
var ColumnDefinition_32aa8b9a51e84395846041ff39e47129 = new global::Windows.UI.Xaml.Controls.ColumnDefinition();
ColumnDefinition_32aa8b9a51e84395846041ff39e47129.Width = (global::Windows.UI.Xaml.GridLength)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::Windows.UI.Xaml.GridLength), @"180");

var ColumnDefinition_0b3cd8b226e2449db175ec71eceaaacf = new global::Windows.UI.Xaml.Controls.ColumnDefinition();
ColumnDefinition_0b3cd8b226e2449db175ec71eceaaacf.Width = (global::Windows.UI.Xaml.GridLength)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::Windows.UI.Xaml.GridLength), @"5");

var ColumnDefinition_09624cc815214d168d651e0b74efcbcf = new global::Windows.UI.Xaml.Controls.ColumnDefinition();
ColumnDefinition_09624cc815214d168d651e0b74efcbcf.Width = (global::Windows.UI.Xaml.GridLength)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::Windows.UI.Xaml.GridLength), @"63");

var ColumnDefinition_6f7d7c47c45649efa2995756024e6557 = new global::Windows.UI.Xaml.Controls.ColumnDefinition();

Grid_0a1ec54534234f4697ce24d6582c180b.ColumnDefinitions.Add(ColumnDefinition_32aa8b9a51e84395846041ff39e47129);
Grid_0a1ec54534234f4697ce24d6582c180b.ColumnDefinitions.Add(ColumnDefinition_0b3cd8b226e2449db175ec71eceaaacf);
Grid_0a1ec54534234f4697ce24d6582c180b.ColumnDefinitions.Add(ColumnDefinition_09624cc815214d168d651e0b74efcbcf);
Grid_0a1ec54534234f4697ce24d6582c180b.ColumnDefinitions.Add(ColumnDefinition_6f7d7c47c45649efa2995756024e6557);

var Grid_1d6ff471a8bd4e888b72f0842b84ea08 = new global::Windows.UI.Xaml.Controls.Grid();
Grid_1d6ff471a8bd4e888b72f0842b84ea08.Margin = (global::Windows.UI.Xaml.Thickness)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::Windows.UI.Xaml.Thickness), @"20,0,0,0");
var TextBox_283c80e6f1ea4273a5836c5588821d56 = new global::Windows.UI.Xaml.Controls.TextBox();
TextBox_283c80e6f1ea4273a5836c5588821d56.Text = @"2018-10-10";
TextBox_283c80e6f1ea4273a5836c5588821d56.FontSize = (global::System.Double)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::System.Double), @"16");
TextBox_283c80e6f1ea4273a5836c5588821d56.Padding = (global::Windows.UI.Xaml.Thickness)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::Windows.UI.Xaml.Thickness), @"1");
TextBox_283c80e6f1ea4273a5836c5588821d56.VerticalAlignment = global::Windows.UI.Xaml.VerticalAlignment.Center;
TextBox_283c80e6f1ea4273a5836c5588821d56.Height = (global::System.Double)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::System.Double), @"25");

Grid_1d6ff471a8bd4e888b72f0842b84ea08.Children.Add(TextBox_283c80e6f1ea4273a5836c5588821d56);


var Grid_ef92feb8d9094f828547ec654878c603 = new global::Windows.UI.Xaml.Controls.Grid();
global::Windows.UI.Xaml.Controls.Grid.SetColumn(Grid_ef92feb8d9094f828547ec654878c603,(global::System.Int32)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::System.Int32), @"2"));
var Button_73b5ef62f51743c59f0d36683eac399a = new global::Windows.UI.Xaml.Controls.Button();
Button_73b5ef62f51743c59f0d36683eac399a.Content = (global::System.Object)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::System.Object), @"검색");
Button_73b5ef62f51743c59f0d36683eac399a.Foreground = (global::Windows.UI.Xaml.Media.Brush)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::Windows.UI.Xaml.Media.Brush), @"#FF00DEFF");
Button_73b5ef62f51743c59f0d36683eac399a.FontSize = (global::System.Double)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::System.Double), @"16");
var NullExtension_b829abcad62c4f1786d7b1b8c2d761dc = new global::System.Windows.Markup.NullExtension();

Button_73b5ef62f51743c59f0d36683eac399a.Background = null;


Grid_ef92feb8d9094f828547ec654878c603.Children.Add(Button_73b5ef62f51743c59f0d36683eac399a);


Grid_0a1ec54534234f4697ce24d6582c180b.Children.Add(Grid_1d6ff471a8bd4e888b72f0842b84ea08);
Grid_0a1ec54534234f4697ce24d6582c180b.Children.Add(Grid_ef92feb8d9094f828547ec654878c603);


var Grid_d0c767e3786a40b2a79ed0dd1480ca7b = new global::Windows.UI.Xaml.Controls.Grid();
global::Windows.UI.Xaml.Controls.Grid.SetRow(Grid_d0c767e3786a40b2a79ed0dd1480ca7b,(global::System.Int32)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::System.Int32), @"3"));
var ScrollViewer_66ade7eb4a4041b0951a550f438838f2 = new global::Windows.UI.Xaml.Controls.ScrollViewer();
ScrollViewer_66ade7eb4a4041b0951a550f438838f2.Margin = (global::Windows.UI.Xaml.Thickness)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::Windows.UI.Xaml.Thickness), @"20,0");
ScrollViewer_66ade7eb4a4041b0951a550f438838f2.VerticalScrollBarVisibility = global::Windows.UI.Xaml.Controls.ScrollBarVisibility.Auto;
var DataGrid_992b99bfbcca4e588d53cb07b71ac436 = new global::Windows.UI.Xaml.Controls.DataGrid();
this.RegisterName("m_dgMain", DataGrid_992b99bfbcca4e588d53cb07b71ac436);
DataGrid_992b99bfbcca4e588d53cb07b71ac436.Name = "m_dgMain";
DataGrid_992b99bfbcca4e588d53cb07b71ac436.Margin = (global::Windows.UI.Xaml.Thickness)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::Windows.UI.Xaml.Thickness), @"0");
DataGrid_992b99bfbcca4e588d53cb07b71ac436.AutoGenerateColumns = (global::System.Boolean)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::System.Boolean), @"False");
var DataGridTemplateColumn_bd1dffc886f449abae0597eed568a4b8 = new global::Windows.UI.Xaml.Controls.DataGridTemplateColumn();
DataGridTemplateColumn_bd1dffc886f449abae0597eed568a4b8.Header = (global::System.Object)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::System.Object), @"");
DataGridTemplateColumn_bd1dffc886f449abae0597eed568a4b8.Width = (global::Windows.UI.Xaml.Controls.DataGridLength)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::Windows.UI.Xaml.Controls.DataGridLength), @"360");
var DataTemplate_0bbd7e9575f44273a188bd123328cafd = new global::Windows.UI.Xaml.DataTemplate();
DataTemplate_0bbd7e9575f44273a188bd123328cafd.SetMethodToInstantiateFrameworkTemplate(this.Instantiate_DataTemplate_0bbd7e9575f44273a188bd123328cafd);

DataGridTemplateColumn_bd1dffc886f449abae0597eed568a4b8.HeaderTemplate = DataTemplate_0bbd7e9575f44273a188bd123328cafd;

var DataTemplate_dfd07f09463a4ea895a27a50dda7c3ab = new global::Windows.UI.Xaml.DataTemplate();
DataTemplate_dfd07f09463a4ea895a27a50dda7c3ab.SetMethodToInstantiateFrameworkTemplate(this.Instantiate_DataTemplate_dfd07f09463a4ea895a27a50dda7c3ab);

DataGridTemplateColumn_bd1dffc886f449abae0597eed568a4b8.CellTemplate = DataTemplate_dfd07f09463a4ea895a27a50dda7c3ab;


DataGrid_992b99bfbcca4e588d53cb07b71ac436.Columns.Add(DataGridTemplateColumn_bd1dffc886f449abae0597eed568a4b8);

var NullExtension_3f7e9a62554e427b9abd29c6ff1ea089 = new global::System.Windows.Markup.NullExtension();

DataGrid_992b99bfbcca4e588d53cb07b71ac436.Background = null;


ScrollViewer_66ade7eb4a4041b0951a550f438838f2.Content = DataGrid_992b99bfbcca4e588d53cb07b71ac436;


Grid_d0c767e3786a40b2a79ed0dd1480ca7b.Children.Add(ScrollViewer_66ade7eb4a4041b0951a550f438838f2);


Grid_e66439015ea7461f957e729a009ab8db.Children.Add(Grid_0a1ec54534234f4697ce24d6582c180b);
Grid_e66439015ea7461f957e729a009ab8db.Children.Add(Grid_d0c767e3786a40b2a79ed0dd1480ca7b);


Grid_e42f975fbd3845e0b4a4e8862136cc71.Children.Add(Grid_e66439015ea7461f957e729a009ab8db);


this.Content = Grid_e42f975fbd3845e0b4a4e8862136cc71;



m_dgMain = DataGrid_992b99bfbcca4e588d53cb07b71ac436;
LayoutRoot = Grid_e42f975fbd3845e0b4a4e8862136cc71;


    
        }



        private global::Windows.UI.Xaml.TemplateInstance Instantiate_DataTemplate_0bbd7e9575f44273a188bd123328cafd(global::Windows.UI.Xaml.FrameworkElement templateOwner)
        {
var templateInstance_afad08775bb4418188d24b3675609361 = new global::Windows.UI.Xaml.TemplateInstance();
templateInstance_afad08775bb4418188d24b3675609361.TemplateOwner = templateOwner;
var Grid_ac360909be814e64931fca475c71b3cb = new global::Windows.UI.Xaml.Controls.Grid();
Grid_ac360909be814e64931fca475c71b3cb.VerticalAlignment = global::Windows.UI.Xaml.VerticalAlignment.Center;
var TextBlock_d63b6b7c991945019c40e7d68794524c = new global::Windows.UI.Xaml.Controls.TextBlock();
TextBlock_d63b6b7c991945019c40e7d68794524c.Foreground = (global::Windows.UI.Xaml.Media.Brush)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::Windows.UI.Xaml.Media.Brush), @"White");
TextBlock_d63b6b7c991945019c40e7d68794524c.FontSize = (global::System.Double)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::System.Double), @"16");
TextBlock_d63b6b7c991945019c40e7d68794524c.Padding = (global::Windows.UI.Xaml.Thickness)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::Windows.UI.Xaml.Thickness), @"2,1,1,1");
TextBlock_d63b6b7c991945019c40e7d68794524c.Text = @"날짜";
TextBlock_d63b6b7c991945019c40e7d68794524c.VerticalAlignment = global::Windows.UI.Xaml.VerticalAlignment.Center;

Grid_ac360909be814e64931fca475c71b3cb.Children.Add(TextBlock_d63b6b7c991945019c40e7d68794524c);





templateInstance_afad08775bb4418188d24b3675609361.TemplateContent = Grid_ac360909be814e64931fca475c71b3cb;
return templateInstance_afad08775bb4418188d24b3675609361;
        }



        private global::Windows.UI.Xaml.TemplateInstance Instantiate_DataTemplate_dfd07f09463a4ea895a27a50dda7c3ab(global::Windows.UI.Xaml.FrameworkElement templateOwner)
        {
var templateInstance_538e10e5b1484a4487039bca5326f354 = new global::Windows.UI.Xaml.TemplateInstance();
templateInstance_538e10e5b1484a4487039bca5326f354.TemplateOwner = templateOwner;
var Grid_e088e763014c47d193d5e067e79412e2 = new global::Windows.UI.Xaml.Controls.Grid();
Grid_e088e763014c47d193d5e067e79412e2.Height = (global::System.Double)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::System.Double), @"24");
Grid_e088e763014c47d193d5e067e79412e2.VerticalAlignment = global::Windows.UI.Xaml.VerticalAlignment.Center;
var TextBlock_f23812e215764a97a1522c5410aa087b = new global::Windows.UI.Xaml.Controls.TextBlock();
TextBlock_f23812e215764a97a1522c5410aa087b.FontSize = (global::System.Double)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::System.Double), @"16");
TextBlock_f23812e215764a97a1522c5410aa087b.Padding = (global::Windows.UI.Xaml.Thickness)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::Windows.UI.Xaml.Thickness), @"2,1,1,1");
TextBlock_f23812e215764a97a1522c5410aa087b.Margin = (global::Windows.UI.Xaml.Thickness)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::Windows.UI.Xaml.Thickness), @"0");
TextBlock_f23812e215764a97a1522c5410aa087b.VerticalAlignment = global::Windows.UI.Xaml.VerticalAlignment.Center;
var Binding_79daa4f68cd441a4b57d268a2c48bb86 = new global::Windows.UI.Xaml.Data.Binding();
Binding_79daa4f68cd441a4b57d268a2c48bb86.Path = (global::Windows.UI.Xaml.PropertyPath)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::Windows.UI.Xaml.PropertyPath), @"RecDate");



Grid_e088e763014c47d193d5e067e79412e2.Children.Add(TextBlock_f23812e215764a97a1522c5410aa087b);



TextBlock_f23812e215764a97a1522c5410aa087b.SetBinding(global::Windows.UI.Xaml.Controls.TextBlock.TextProperty, Binding_79daa4f68cd441a4b57d268a2c48bb86);

templateInstance_538e10e5b1484a4487039bca5326f354.TemplateContent = Grid_e088e763014c47d193d5e067e79412e2;
return templateInstance_538e10e5b1484a4487039bca5326f354;
        }


}


}