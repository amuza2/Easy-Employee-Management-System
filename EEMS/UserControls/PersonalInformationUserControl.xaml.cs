using EEMS.UI.ViewModels;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace EEMS.UI.UserControls;

/// <summary>
/// Interaction logic for PersonalInformationUserControl.xaml
/// </summary>
public partial class PersonalInformationUserControl : UserControl
{
    public PersonalInformationUserControl(PersonalInformationViewModel personalInformationViewModel)
    {
        DataContext = personalInformationViewModel;
    }
    public PersonalInformationUserControl()
    {
        InitializeComponent();
        
    }
}
