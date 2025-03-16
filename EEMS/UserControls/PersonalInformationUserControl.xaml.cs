using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace EEMS.UI.UserControls
{
    /// <summary>
    /// Interaction logic for PersonalInformationUserControl.xaml
    /// </summary>
    public partial class PersonalInformationUserControl : UserControl
    {
        public PersonalInformationUserControl()
        {
            InitializeComponent();
        }

        public ObservableCollection<string> FamilySituation
        {
            get { return (ObservableCollection<string>)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Items.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register("FamilySituation", typeof(ObservableCollection<string>), typeof(PersonalInformationUserControl), new PropertyMetadata(new ObservableCollection<string>()));


        public DateTime? SelectedDate
        {
            get { return (DateTime?)GetValue(SelectedDateProperty); }
            set { SetValue(SelectedDateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedDate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedDateProperty =
            DependencyProperty.Register("SelectedDate", typeof(DateTime?), typeof(PersonalInformationUserControl), new PropertyMetadata(null));



        public string SelectedItem
        {
            get { return (string)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedItem.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register("SelectedItem", typeof(string), typeof(PersonalInformationUserControl), new PropertyMetadata(string.Empty));



        public object SelectedGender
        {
            get { return (object)GetValue(SelectedGenderProperty); }
            set { SetValue(SelectedGenderProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedGender.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedGenderProperty =
            DependencyProperty.Register("SelectedGender", typeof(object), typeof(RadioButtonGroupUserControl), new PropertyMetadata(null));




    }
}
