using System.Windows;
using System.Windows.Controls;

namespace EEMS.UI.UserControls;

/// <summary>
/// Interaction logic for NumericUpDownUserControl.xaml
/// </summary>
public partial class NumericUpDownUserControl : UserControl
{
    public NumericUpDownUserControl()
    {
        InitializeComponent();
    }

    public string Caption
    {
        get { return (string)GetValue(CaptionProperty); }
        set { SetValue(CaptionProperty, value); }
    }

    // Using a DependencyProperty as the backing store for Caption.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty CaptionProperty =
        DependencyProperty.Register("Caption", typeof(string), typeof(NumericUpDownUserControl), new PropertyMetadata(string.Empty));


    public int Value
    {
        get { return (int)GetValue(ValueProperty); }
        set { SetValue(ValueProperty, value); }
    }

    // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty ValueProperty =
        DependencyProperty.Register("Value", typeof(int), typeof(NumericUpDownUserControl), new PropertyMetadata(0));
}
