// <CSHTML5><XamlHash>3A92BEE3FEF0776E5CD81C2209BA7380</XamlHash><PassNumber>2</PassNumber><CompilationDate>2019-06-12 오후 4:48:50</CompilationDate></CSHTML5>



public static class ǀǀTmsserverǀǀComponentǀǀWndnameǀǀXamlǀǀFactory
{
    public static object Instantiate()
    {
        global::System.Type type = typeof(TMSServer.wndName);
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



partial class wndName : global::Windows.UI.Xaml.Controls.ChildWindow
{

#pragma warning disable 169, 649, 0628 // Prevents warning CS0169 ('field ... is never used'), CS0649 ('field ... is never assigned to, and will always have its default value null'), and CS0628 ('member : new protected member declared in sealed class')
protected global::Windows.UI.Xaml.Controls.TextBox m_tbxName;
protected global::TMSServer.ucButton m_ucBtnOK;
protected global::TMSServer.ucButton m_ucBtnCancel;


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
                ((global::Windows.UI.Xaml.UIElement)(object)this).XamlSourcePath = @"TMSServer\wndName.xaml";
            }
#pragma warning restore 0184



this.Height = (global::System.Double)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::System.Double), @"225");
this.Width = (global::System.Double)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::System.Double), @"450");
this.Background = (global::Windows.UI.Xaml.Media.Brush)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::Windows.UI.Xaml.Media.Brush), @"White");
this.Title = (global::System.Object)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::System.Object), @"");
var Grid_bdbb3ceca57845f7b065b464873d3565 = new global::Windows.UI.Xaml.Controls.Grid();
var StackPanel_54bc050085c841ecb83ddd2445122cac = new global::Windows.UI.Xaml.Controls.StackPanel();
StackPanel_54bc050085c841ecb83ddd2445122cac.Margin = (global::Windows.UI.Xaml.Thickness)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::Windows.UI.Xaml.Thickness), @"0,26,0,134");
StackPanel_54bc050085c841ecb83ddd2445122cac.Orientation = global::Windows.UI.Xaml.Controls.Orientation.Horizontal;
StackPanel_54bc050085c841ecb83ddd2445122cac.HorizontalAlignment = global::Windows.UI.Xaml.HorizontalAlignment.Center;
var TextBox_9d36f5f7665748cb9738882027c16dde = new global::Windows.UI.Xaml.Controls.TextBox();
TextBox_9d36f5f7665748cb9738882027c16dde.HorizontalAlignment = global::Windows.UI.Xaml.HorizontalAlignment.Left;
TextBox_9d36f5f7665748cb9738882027c16dde.Margin = (global::Windows.UI.Xaml.Thickness)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::Windows.UI.Xaml.Thickness), @"0");
TextBox_9d36f5f7665748cb9738882027c16dde.TextWrapping = global::Windows.UI.Xaml.TextWrapping.Wrap;
TextBox_9d36f5f7665748cb9738882027c16dde.Text = @"이름";
TextBox_9d36f5f7665748cb9738882027c16dde.Width = (global::System.Double)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::System.Double), @"47");
TextBox_9d36f5f7665748cb9738882027c16dde.FontSize = (global::System.Double)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::System.Double), @"17");
TextBox_9d36f5f7665748cb9738882027c16dde.BorderThickness = (global::Windows.UI.Xaml.Thickness)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::Windows.UI.Xaml.Thickness), @"0");
TextBox_9d36f5f7665748cb9738882027c16dde.IsHitTestVisible = (global::System.Boolean)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::System.Boolean), @"False");
TextBox_9d36f5f7665748cb9738882027c16dde.Padding = (global::Windows.UI.Xaml.Thickness)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::Windows.UI.Xaml.Thickness), @"1,5,1,1");
var NullExtension_eea3c984b2484602a7e15a3562a9c53a = new global::System.Windows.Markup.NullExtension();

TextBox_9d36f5f7665748cb9738882027c16dde.Background = null;

var NullExtension_49b3cccb9f094966823f999a92db6457 = new global::System.Windows.Markup.NullExtension();

TextBox_9d36f5f7665748cb9738882027c16dde.BorderBrush = null;


var TextBox_fb0475a341d24dc0bb2b57beed760d1e = new global::Windows.UI.Xaml.Controls.TextBox();
this.RegisterName("m_tbxName", TextBox_fb0475a341d24dc0bb2b57beed760d1e);
TextBox_fb0475a341d24dc0bb2b57beed760d1e.Name = "m_tbxName";
TextBox_fb0475a341d24dc0bb2b57beed760d1e.TextWrapping = global::Windows.UI.Xaml.TextWrapping.Wrap;
TextBox_fb0475a341d24dc0bb2b57beed760d1e.FontSize = (global::System.Double)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::System.Double), @"17");
TextBox_fb0475a341d24dc0bb2b57beed760d1e.Text = @"";
TextBox_fb0475a341d24dc0bb2b57beed760d1e.Padding = (global::Windows.UI.Xaml.Thickness)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::Windows.UI.Xaml.Thickness), @"1,5,1,1");
TextBox_fb0475a341d24dc0bb2b57beed760d1e.Width = (global::System.Double)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::System.Double), @"221");

StackPanel_54bc050085c841ecb83ddd2445122cac.Children.Add(TextBox_9d36f5f7665748cb9738882027c16dde);
StackPanel_54bc050085c841ecb83ddd2445122cac.Children.Add(TextBox_fb0475a341d24dc0bb2b57beed760d1e);


var StackPanel_e85274b1796e4fbf942cc5935353b237 = new global::Windows.UI.Xaml.Controls.StackPanel();
StackPanel_e85274b1796e4fbf942cc5935353b237.Margin = (global::Windows.UI.Xaml.Thickness)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::Windows.UI.Xaml.Thickness), @"0,83,0,82");
StackPanel_e85274b1796e4fbf942cc5935353b237.Orientation = global::Windows.UI.Xaml.Controls.Orientation.Horizontal;
StackPanel_e85274b1796e4fbf942cc5935353b237.HorizontalAlignment = global::Windows.UI.Xaml.HorizontalAlignment.Center;
var Border_6d4850a27d504fbe91d0b45a5887524c = new global::Windows.UI.Xaml.Controls.Border();
Border_6d4850a27d504fbe91d0b45a5887524c.CornerRadius = (global::Windows.UI.Xaml.CornerRadius)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::Windows.UI.Xaml.CornerRadius), @"15");
Border_6d4850a27d504fbe91d0b45a5887524c.HorizontalAlignment = global::Windows.UI.Xaml.HorizontalAlignment.Left;
Border_6d4850a27d504fbe91d0b45a5887524c.Width = (global::System.Double)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::System.Double), @"100");
Border_6d4850a27d504fbe91d0b45a5887524c.Margin = (global::Windows.UI.Xaml.Thickness)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::Windows.UI.Xaml.Thickness), @"0,0,68,0");
var LinearGradientBrush_ed33c691141b40ed9e4353dcd6b92e69 = new global::Windows.UI.Xaml.Media.LinearGradientBrush();
LinearGradientBrush_ed33c691141b40ed9e4353dcd6b92e69.EndPoint = (global::Windows.Foundation.Point)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::Windows.Foundation.Point), @"0.5,1");
LinearGradientBrush_ed33c691141b40ed9e4353dcd6b92e69.StartPoint = (global::Windows.Foundation.Point)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::Windows.Foundation.Point), @"0.5,0");
var GradientStop_1a664c7b2df743c28d5fdc6357b9018f = new global::Windows.UI.Xaml.Media.GradientStop();
GradientStop_1a664c7b2df743c28d5fdc6357b9018f.Color = (global::Windows.UI.Color)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::Windows.UI.Color), @"#FF306F94");
GradientStop_1a664c7b2df743c28d5fdc6357b9018f.Offset = (global::System.Double)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::System.Double), @"0");

var GradientStop_3df3bf1b55fa41d1833cd3cd4ece3b31 = new global::Windows.UI.Xaml.Media.GradientStop();
GradientStop_3df3bf1b55fa41d1833cd3cd4ece3b31.Color = (global::Windows.UI.Color)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::Windows.UI.Color), @"#FF6DAABC");
GradientStop_3df3bf1b55fa41d1833cd3cd4ece3b31.Offset = (global::System.Double)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::System.Double), @"1");

LinearGradientBrush_ed33c691141b40ed9e4353dcd6b92e69.GradientStops.Add(GradientStop_1a664c7b2df743c28d5fdc6357b9018f);
LinearGradientBrush_ed33c691141b40ed9e4353dcd6b92e69.GradientStops.Add(GradientStop_3df3bf1b55fa41d1833cd3cd4ece3b31);


Border_6d4850a27d504fbe91d0b45a5887524c.Background = LinearGradientBrush_ed33c691141b40ed9e4353dcd6b92e69;

var ucButton_6e2b561e6ef1455f8a5a25bb4280d71e = new global::TMSServer.ucButton();
this.RegisterName("m_ucBtnOK", ucButton_6e2b561e6ef1455f8a5a25bb4280d71e);
ucButton_6e2b561e6ef1455f8a5a25bb4280d71e.Name = "m_ucBtnOK";
ucButton_6e2b561e6ef1455f8a5a25bb4280d71e.TextHorizentalAllignment = @"Center";
ucButton_6e2b561e6ef1455f8a5a25bb4280d71e.TextVerticalAllignment = @"Center";
ucButton_6e2b561e6ef1455f8a5a25bb4280d71e.TextMargin = @"0,0,0,0";
ucButton_6e2b561e6ef1455f8a5a25bb4280d71e.Text = @"확 인";
ucButton_6e2b561e6ef1455f8a5a25bb4280d71e.TextSize = @"17";

Border_6d4850a27d504fbe91d0b45a5887524c.Child = ucButton_6e2b561e6ef1455f8a5a25bb4280d71e;


var Border_37774b2aabd349189405a146183166d1 = new global::Windows.UI.Xaml.Controls.Border();
Border_37774b2aabd349189405a146183166d1.CornerRadius = (global::Windows.UI.Xaml.CornerRadius)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::Windows.UI.Xaml.CornerRadius), @"15");
Border_37774b2aabd349189405a146183166d1.HorizontalAlignment = global::Windows.UI.Xaml.HorizontalAlignment.Left;
Border_37774b2aabd349189405a146183166d1.Width = (global::System.Double)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::System.Double), @"100");
var LinearGradientBrush_8933d732c402487f96b4f57d03279ec0 = new global::Windows.UI.Xaml.Media.LinearGradientBrush();
LinearGradientBrush_8933d732c402487f96b4f57d03279ec0.EndPoint = (global::Windows.Foundation.Point)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::Windows.Foundation.Point), @"0.5,1");
LinearGradientBrush_8933d732c402487f96b4f57d03279ec0.StartPoint = (global::Windows.Foundation.Point)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::Windows.Foundation.Point), @"0.5,0");
var GradientStop_6dce153184dd41f9a39cc0b5381ad0a3 = new global::Windows.UI.Xaml.Media.GradientStop();
GradientStop_6dce153184dd41f9a39cc0b5381ad0a3.Color = (global::Windows.UI.Color)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::Windows.UI.Color), @"#FF306F94");
GradientStop_6dce153184dd41f9a39cc0b5381ad0a3.Offset = (global::System.Double)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::System.Double), @"0.016");

var GradientStop_18c17100fa9c402cb4c36aa2ea9eb102 = new global::Windows.UI.Xaml.Media.GradientStop();
GradientStop_18c17100fa9c402cb4c36aa2ea9eb102.Color = (global::Windows.UI.Color)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::Windows.UI.Color), @"#FF6DAABC");
GradientStop_18c17100fa9c402cb4c36aa2ea9eb102.Offset = (global::System.Double)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::System.Double), @"1");

LinearGradientBrush_8933d732c402487f96b4f57d03279ec0.GradientStops.Add(GradientStop_6dce153184dd41f9a39cc0b5381ad0a3);
LinearGradientBrush_8933d732c402487f96b4f57d03279ec0.GradientStops.Add(GradientStop_18c17100fa9c402cb4c36aa2ea9eb102);


Border_37774b2aabd349189405a146183166d1.Background = LinearGradientBrush_8933d732c402487f96b4f57d03279ec0;

var ucButton_98912b5d97d74daba96f752c91a0fd6c = new global::TMSServer.ucButton();
this.RegisterName("m_ucBtnCancel", ucButton_98912b5d97d74daba96f752c91a0fd6c);
ucButton_98912b5d97d74daba96f752c91a0fd6c.Name = "m_ucBtnCancel";
ucButton_98912b5d97d74daba96f752c91a0fd6c.TextHorizentalAllignment = @"Center";
ucButton_98912b5d97d74daba96f752c91a0fd6c.TextVerticalAllignment = @"Center";
ucButton_98912b5d97d74daba96f752c91a0fd6c.TextMargin = @"0,0,0,0";
ucButton_98912b5d97d74daba96f752c91a0fd6c.Text = @"취 소";
ucButton_98912b5d97d74daba96f752c91a0fd6c.TextSize = @"17";

Border_37774b2aabd349189405a146183166d1.Child = ucButton_98912b5d97d74daba96f752c91a0fd6c;


StackPanel_e85274b1796e4fbf942cc5935353b237.Children.Add(Border_6d4850a27d504fbe91d0b45a5887524c);
StackPanel_e85274b1796e4fbf942cc5935353b237.Children.Add(Border_37774b2aabd349189405a146183166d1);


var TextBox_f2ca1f7a87f74d9bbf6368e53856664b = new global::Windows.UI.Xaml.Controls.TextBox();
TextBox_f2ca1f7a87f74d9bbf6368e53856664b.HorizontalAlignment = global::Windows.UI.Xaml.HorizontalAlignment.Center;
TextBox_f2ca1f7a87f74d9bbf6368e53856664b.Height = (global::System.Double)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::System.Double), @"26");
TextBox_f2ca1f7a87f74d9bbf6368e53856664b.Margin = (global::Windows.UI.Xaml.Thickness)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::Windows.UI.Xaml.Thickness), @"0,140,0,0");
TextBox_f2ca1f7a87f74d9bbf6368e53856664b.TextWrapping = global::Windows.UI.Xaml.TextWrapping.Wrap;
TextBox_f2ca1f7a87f74d9bbf6368e53856664b.Text = @"※ 센서에서도 해당 이름에 대한 데이터를 전송해야 합니다.";
TextBox_f2ca1f7a87f74d9bbf6368e53856664b.VerticalAlignment = global::Windows.UI.Xaml.VerticalAlignment.Top;
TextBox_f2ca1f7a87f74d9bbf6368e53856664b.BorderThickness = (global::Windows.UI.Xaml.Thickness)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::Windows.UI.Xaml.Thickness), @"0");
TextBox_f2ca1f7a87f74d9bbf6368e53856664b.IsHitTestVisible = (global::System.Boolean)global::DotNetForHtml5.Core.TypeFromStringConverters.ConvertFromInvariantString(typeof(global::System.Boolean), @"False");
var NullExtension_c42209380afc4022a214b50d5505c379 = new global::System.Windows.Markup.NullExtension();

TextBox_f2ca1f7a87f74d9bbf6368e53856664b.Background = null;

var NullExtension_520c87c004444405a0c3fe7ec2b52f15 = new global::System.Windows.Markup.NullExtension();

TextBox_f2ca1f7a87f74d9bbf6368e53856664b.BorderBrush = null;


Grid_bdbb3ceca57845f7b065b464873d3565.Children.Add(StackPanel_54bc050085c841ecb83ddd2445122cac);
Grid_bdbb3ceca57845f7b065b464873d3565.Children.Add(StackPanel_e85274b1796e4fbf942cc5935353b237);
Grid_bdbb3ceca57845f7b065b464873d3565.Children.Add(TextBox_f2ca1f7a87f74d9bbf6368e53856664b);


this.Content = Grid_bdbb3ceca57845f7b065b464873d3565;



m_tbxName = TextBox_fb0475a341d24dc0bb2b57beed760d1e;
m_ucBtnOK = ucButton_6e2b561e6ef1455f8a5a25bb4280d71e;
m_ucBtnCancel = ucButton_98912b5d97d74daba96f752c91a0fd6c;


    
        }


}


}