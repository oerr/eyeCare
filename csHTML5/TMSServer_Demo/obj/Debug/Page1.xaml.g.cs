// <CSHTML5><XamlHash>833430F212AD1900DBF48ECF77597E59</XamlHash><PassNumber>2</PassNumber><CompilationDate>2018-12-31 오전 10:55:19</CompilationDate></CSHTML5>



public static class ǀǀTmsserverǀǀComponentǀǀPage1ǀǀXamlǀǀFactory
{
    public static object Instantiate()
    {
        global::System.Type type = typeof(TMSServer.Page1);
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



partial class Page1 : global::Windows.UI.Xaml.Controls.Page
{

#pragma warning disable 169, 649, 0628 // Prevents warning CS0169 ('field ... is never used'), CS0649 ('field ... is never assigned to, and will always have its default value null'), and CS0628 ('member : new protected member declared in sealed class')
protected global::Windows.UI.Xaml.Controls.Grid m_Container;


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
                ((global::Windows.UI.Xaml.UIElement)(object)this).XamlSourcePath = @"TMSServer\Page1.xaml";
            }
#pragma warning restore 0184



var Grid_948bde3600644ae3aacbeb82f179ae66 = new global::Windows.UI.Xaml.Controls.Grid();
var ScrollViewer_0debcaf6b21541bcb34d74616f4c0da2 = new global::Windows.UI.Xaml.Controls.ScrollViewer();
ScrollViewer_0debcaf6b21541bcb34d74616f4c0da2.VerticalScrollBarVisibility = global::Windows.UI.Xaml.Controls.ScrollBarVisibility.Auto;
var Grid_959e8f76fa7c43e2a6a3b95d6384bbfa = new global::Windows.UI.Xaml.Controls.Grid();
this.RegisterName("m_Container", Grid_959e8f76fa7c43e2a6a3b95d6384bbfa);
Grid_959e8f76fa7c43e2a6a3b95d6384bbfa.Name = "m_Container";

ScrollViewer_0debcaf6b21541bcb34d74616f4c0da2.Content = Grid_959e8f76fa7c43e2a6a3b95d6384bbfa;


Grid_948bde3600644ae3aacbeb82f179ae66.Children.Add(ScrollViewer_0debcaf6b21541bcb34d74616f4c0da2);


this.Content = Grid_948bde3600644ae3aacbeb82f179ae66;



m_Container = Grid_959e8f76fa7c43e2a6a3b95d6384bbfa;


    
        }


}


}
