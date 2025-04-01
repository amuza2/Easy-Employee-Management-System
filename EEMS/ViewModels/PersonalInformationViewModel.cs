using EEMS.UI.MVVM;
using System.Collections.ObjectModel;

namespace EEMS.UI.ViewModels;

public class PersonalInformationViewModel : ViewModelBase
{
    private string _firstName;

    public string FirstName
    {
        get { return _firstName; }
        set
        {
            _firstName = value;
            OnPropertyChanged();
        }
    }

    private string _lastName;

    public string LastName
    {
        get { return _lastName; }
        set
        {
            _lastName = value;
            OnPropertyChanged();
        }
    }

    private string _phone;

    public string Phone
    {
        get { return _phone; }
        set
        {
            _phone = value;
            OnPropertyChanged();
        }
    }

    private string _address;

    public string Address
    {
        get { return _address; }
        set
        {
            _address = value;
            OnPropertyChanged();
        }
    }

    private string _email;

    public string Email
    {
        get { return _email; }
        set
        {
            _email = value;
            OnPropertyChanged();
        }
    }

    private string _birthLocation;

    public string BirthLocation
    {
        get { return _birthLocation; }
        set
        {
            _birthLocation = value;
            OnPropertyChanged();
        }
    }

    private string _residence;

    public string Residence
    {
        get { return _residence; }
        set
        {
            _residence = value;
            OnPropertyChanged();
        }
    }


    private ObservableCollection<string> _familySituation;

    public ObservableCollection<string> FamilySituation
    {
        get { return _familySituation; }
        set
        {
            _familySituation = value;
            OnPropertyChanged();
        }
    }

    private object _selectedFamilySituation;

    public object SelectedFamilySituation
    {
        get { return _selectedFamilySituation; }
        set
        {
            _selectedFamilySituation = value;
            OnPropertyChanged();
        }
    }

    private string _SelectedGender;

    public string SelectedGender
    {
        get { return _SelectedGender; }
        set
        {
            _SelectedGender = value;
            OnPropertyChanged();
        }
    }


    private DateTime? _selectDate;

    public DateTime? SelectedDate
    {
        get { return _selectDate; }
        set
        {
            _selectDate = value;
            OnPropertyChanged(nameof(SelectedDate));
        }
    }

    public PersonalInformationViewModel()
    {
        FamilySituation = new ObservableCollection<string>() { "Married", "Single" };
        SelectedFamilySituation = "Select an option";
        SelectedDate = DateTime.Now.Date;
    }
}
