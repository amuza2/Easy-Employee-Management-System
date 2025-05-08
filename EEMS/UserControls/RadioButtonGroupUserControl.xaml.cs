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


        public string Option1Text
        {
            get { return (string)GetValue(Option1TextProperty); }
            set { SetValue(Option1TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Option1Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Option1TextProperty =
            DependencyProperty.Register("Option1Text", typeof(string), typeof(RadioButtonGroupUserControl), new PropertyMetadata("Option 1"));


        public string Option2Text
        {
            get { return (string)GetValue(Option2TextProperty); }
            set { SetValue(Option2TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Option2Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Option2TextProperty =
            DependencyProperty.Register("Option2Text", typeof(string), typeof(RadioButtonGroupUserControl), new PropertyMetadata("Option 2"));




        public bool IsOption1Selected
        {
            get { return (bool)GetValue(IsOption1SelectedProperty); }
            set { SetValue(IsOption1SelectedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsOption1Selected.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsOption1SelectedProperty =
            DependencyProperty.Register("IsOption1Selected", typeof(bool), typeof(RadioButtonGroupUserControl), new PropertyMetadata(false, OnIsOption1SelectedChanged));

        private static void OnIsOption1SelectedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as RadioButtonGroupUserControl;
            if (control != null && (bool)e.NewValue)
            {
                control.SelectedValue = control.Option1Text;
            }
        }

        public bool IsOption2Selected
        {
            get { return (bool)GetValue(IsOption2SelectedProperty); }
            set { SetValue(IsOption2SelectedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsOption2Selected.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsOption2SelectedProperty =
            DependencyProperty.Register("IsOption2Selected", typeof(bool), typeof(RadioButtonGroupUserControl), new PropertyMetadata(false, OnIsOption2SelectedChanged));

        private static void OnIsOption2SelectedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as RadioButtonGroupUserControl;
            if (control != null && (bool)e.NewValue)
            {
                control.SelectedValue = control.Option2Text;
            }
        }

        public object SelectedValue
        {
            get { return (object)GetValue(SelectedValueProperty); }
            set { SetValue(SelectedValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedValueProperty =
            DependencyProperty.Register("SelectedValue", typeof(object), typeof(RadioButtonGroupUserControl), new PropertyMetadata(null));




    }
}
