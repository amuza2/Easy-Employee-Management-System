using System.Windows;
using System.Windows.Controls;

namespace EEMS.UI.UserControls
{
    /// <summary>
    /// Interaction logic for SearchTextBoxControl.xaml
    /// </summary>
    public partial class SearchTextBoxControl : UserControl
    {
        // Using a DependencyProperty as the backing store for PlaceHolderText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PlaceholderTextProperty =
            DependencyProperty.Register("PlaceHolderText", typeof(string), typeof(SearchTextBoxControl), new PropertyMetadata("Search here..."));
        
        public string PlaceholderText
        {
            get { return (string)GetValue(PlaceholderTextProperty); }
            set { SetValue(PlaceholderTextProperty, value); }
        }


        public SearchTextBoxControl()
        {
            InitializeComponent();
        }
    }
}
