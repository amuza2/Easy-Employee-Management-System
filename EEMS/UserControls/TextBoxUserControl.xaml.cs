using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace EEMS.UI.UserControls;

/// <summary>
/// Interaction logic for TextBoxUserControl.xaml
/// </summary>
public partial class TextBoxUserControl : UserControl
{
    public TextBoxUserControl()
    {
        InitializeComponent();
    }

    public string Hint
    {
        get { return (string)GetValue(HintProperty); }
        set { SetValue(HintProperty, value); }
    }

    // Using a DependencyProperty as the backing store for Hint.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty HintProperty =
        DependencyProperty.Register("Hint", typeof(string), typeof(TextBoxUserControl));

    public string Caption
    {
        get { return (string)GetValue(CaptionProperty); }
        set { SetValue(CaptionProperty, value); }
    }

    // Using a DependencyProperty as the backing store for Caption.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty CaptionProperty =
        DependencyProperty.Register("Caption", typeof(string), typeof(TextBoxUserControl));



    public string Text
    {
        get { return (string)GetValue(TextProperty); }
        set { SetValue(TextProperty, value); }
    }

    // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty TextProperty =
        DependencyProperty.Register("Text", typeof(string), typeof(TextBoxUserControl), new PropertyMetadata(string.Empty));
}
