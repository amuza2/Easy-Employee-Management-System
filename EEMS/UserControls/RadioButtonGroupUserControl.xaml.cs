using EEMS.UI.Enums;
using EEMS.Utilities.Enums;
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



        public Gender SelectedGender
        {
            get { return (Gender)GetValue(SelectedGenderProperty); }
            set { SetValue(SelectedGenderProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedGender.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedGenderProperty =
            DependencyProperty.Register("SelectedGender", typeof(Gender), typeof(RadioButtonGroupUserControl), new PropertyMetadata(0));


        public string Selected1Text
        {
            get { return (string)GetValue(Selected1TextProperty); }
            set { SetValue(Selected1TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Selected1Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Selected1TextProperty =
            DependencyProperty.Register("Selected1Text", typeof(string), typeof(RadioButtonGroupUserControl), new PropertyMetadata(string.Empty));


        public string Selected2Text
        {
            get { return (string)GetValue(Selected2TextProperty); }
            set { SetValue(Selected2TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Selected2Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Selected2TextProperty =
            DependencyProperty.Register("Selected2Text", typeof(string), typeof(RadioButtonGroupUserControl), new PropertyMetadata(string.Empty));




    }
}
