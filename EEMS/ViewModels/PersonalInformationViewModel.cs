using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EEMS.UI.ViewModels;

public class PersonalInformationViewModel : INotifyPropertyChanged
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

    private object _selectedItem;

    public object SelectedItem
    {
        get { return _selectedItem; }
        set
        {
            _selectedItem = value;
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
        SelectedItem = "Select an option";
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    private void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
