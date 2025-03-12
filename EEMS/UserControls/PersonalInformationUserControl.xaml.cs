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

        public IEnumerable<string> FamilySituation
        {
            get { return (IEnumerable<string>)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Items.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register("FamilySituation", typeof(IEnumerable<string>), typeof(PersonalInformationUserControl), new PropertyMetadata(new List<string>()));


        public DateTime? SelectedDate
        {
            get { return (DateTime?)GetValue(SelectedDateProperty); }
            set { SetValue(SelectedDateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedDate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedDateProperty =
            DependencyProperty.Register("SelectedDate", typeof(DateTime?), typeof(PersonalInformationUserControl), new PropertyMetadata(null));




        public bool IsFemaleSelected
        {
            get { return (bool)GetValue(IsFemaleSelectedProperty); }
            set { SetValue(IsFemaleSelectedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsFemaleSelected.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsFemaleSelectedProperty =
            DependencyProperty.Register("IsFemaleSelected", typeof(bool), typeof(PersonalInformationUserControl), new PropertyMetadata(false));



        public bool IsMaleSelected
        {
            get { return (bool)GetValue(IsMaleSelectedProperty); }
            set { SetValue(IsMaleSelectedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsMaleSelected.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsMaleSelectedProperty =
            DependencyProperty.Register("IsMaleSelected", typeof(bool), typeof(PersonalInformationUserControl), new PropertyMetadata(false));

    }
}
