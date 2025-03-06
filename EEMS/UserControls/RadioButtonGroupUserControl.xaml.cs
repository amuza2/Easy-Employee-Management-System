using System.Windows;
using System.Windows.Controls;

namespace EEMS.UI.UserControls
{
    /// <summary>
    /// Interaction logic for RadioButtonGroupUserControl.xaml
    /// </summary>
    public partial class RadioButtonGroupUserControl : UserControl
    {
        public RadioButtonGroupUserControl()
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
            DependencyProperty.Register("Caption", typeof(string), typeof(RadioButtonGroupUserControl), new PropertyMetadata(string.Empty));



        public bool IsMaleSelected
        {
            get { return (bool)GetValue(IsMaleSelectedProperty); }
            set { SetValue(IsMaleSelectedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsMaleSelected.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsMaleSelectedProperty =
            DependencyProperty.Register("IsMaleSelected", typeof(bool), typeof(RadioButtonGroupUserControl), new PropertyMetadata(false));



        public bool IsFemaleSelected
        {
            get { return (bool)GetValue(IsFemaleSelectedProperty); }
            set { SetValue(IsFemaleSelectedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsFemaleSelected.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsFemaleSelectedProperty =
            DependencyProperty.Register("IsFemaleSelected", typeof(bool), typeof(RadioButtonGroupUserControl), new PropertyMetadata(false));


        public bool ShowHint
        {
            get { return (bool)GetValue(ShowHintProperty); }
            set { SetValue(ShowHintProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ShowHint.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ShowHintProperty =
            DependencyProperty.Register("ShowHint", typeof(bool), typeof(RadioButtonGroupUserControl), new PropertyMetadata(true));


        public string Hint
        {
            get { return (string)GetValue(HintProperty); }
            set { SetValue(HintProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Hint.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HintProperty =
            DependencyProperty.Register("Hint", typeof(string), typeof(RadioButtonGroupUserControl), new PropertyMetadata(string.Empty));




    }
}
