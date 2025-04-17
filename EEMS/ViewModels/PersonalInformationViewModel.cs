using EEMS.BusinessLogic.Interfaces;
using EEMS.DataAccess.Models;
using EEMS.UI.MVVM;
using EEMS.Utilities.Enums;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Windows.Input;

namespace EEMS.UI.ViewModels;

public class PersonalInformationViewModel : ViewModelBase
{
    private readonly IEmployeeManagementService _employeeManagementService;

    private string _firstName;

    public string FirstName
    {
        get { return _firstName; }
        set
        {
            _firstName = value;
            OnPropertyChanged();
            ValidateProperty(nameof(FirstName));
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
            ValidateProperty(nameof(LastName));
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
            ValidateProperty(nameof(Phone));
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
            ValidateProperty(nameof(Address));
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
            ValidateProperty(nameof(Email));
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
            ValidateProperty(nameof(BirthLocation));
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
            ValidateProperty(nameof(Residence));
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
            ValidateProperty(nameof(SelectedFamilySituation));
        }
    }

    private string _selectedGender;

    public string SelectedGender
    {
        get { return _selectedGender; }
        set
        {
            if(_selectedGender != value)
            {
                _selectedGender = value;
                OnPropertyChanged();
                ValidateProperty(nameof(SelectedGender));
            }
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
            ValidateProperty(nameof(SelectedDate));
        }
    }

    public PersonalInformationViewModel()
    {
        FamilySituation = new ObservableCollection<string>() { "Married", "Single" };
        SelectedFamilySituation = "Select an option";
    }

    public PersonalInformationViewModel(IEmployeeManagementService employeeManagementService, Employee employee)
    {
        _employeeManagementService = employeeManagementService;
        FirstName = employee.FirstName;
        LastName = employee.LastName;
        Phone = employee.Phone.ToString();
        Email = employee.Email;
        Address = employee.Address;
        BirthLocation = employee.BirthLocation;
        Residence = employee.Residence;
        SelectedFamilySituation = employee.FamilySituation;
        SelectedDate = employee.DateOfBirth.Date;
        //SelectedGender = employee.Gender;
    }

    public void ValidateAllProperties()
    {
        ValidateProperty(nameof(FirstName));
        ValidateProperty(nameof(LastName));
        ValidateProperty(nameof(Email));
        ValidateProperty(nameof(Phone));
        ValidateProperty(nameof(Residence));
        ValidateProperty(nameof(BirthLocation));
        ValidateProperty(nameof(Address));
        ValidateProperty(nameof(SelectedFamilySituation));
        ValidateProperty(nameof(SelectedGender));
        ValidateProperty(nameof(SelectedDate));
    }

    public bool AreRequiredFieldsFilled()
    {
        // Check if all are valid
        return !string.IsNullOrWhiteSpace(FirstName) &&
               !string.IsNullOrWhiteSpace(LastName) &&
               !string.IsNullOrWhiteSpace(Email) &&
               !string.IsNullOrWhiteSpace(Phone) &&
               !string.IsNullOrWhiteSpace(BirthLocation) &&
               !string.IsNullOrWhiteSpace(Residence) &&
               !string.IsNullOrWhiteSpace(Address) &&
               SelectedFamilySituation != null &&
               !string.IsNullOrWhiteSpace(SelectedGender) &&
               SelectedDate.HasValue;
    }


    // Override the validation method
    protected override void ValidateProperty(string propertyName)
    {
        // Clear existing errors for this property
        RemoveError(propertyName);

        switch (propertyName)
        {
            case nameof(FirstName):
                if (string.IsNullOrWhiteSpace(FirstName))
                    AddError(propertyName, "First Name is required.");
                else if (FirstName.Length < 3)
                    AddError(propertyName, "First Name must be at least 3 characters.");
                break;

            case nameof(LastName):
                if (string.IsNullOrWhiteSpace(LastName))
                    AddError(propertyName, "Last Name is required.");
                else if (LastName.Length < 3)
                    AddError(propertyName, "Last Name must be at least 3 characters.");
                break;

            case nameof(Phone):
                if (string.IsNullOrWhiteSpace(Phone))
                    AddError(propertyName, "Phone is required.");
                else if(!IsValidPhone(Phone))
                    AddError(propertyName, "Please add a valid Phone number.");
                else if (Phone.Length < 8)
                    AddError(propertyName, "Phone must be at least 8 numbers.");
                break;

            case nameof(Address):
                if (string.IsNullOrWhiteSpace(Address))
                    AddError(propertyName, "Address is required.");
                else if (Address.Length < 3)
                    AddError(propertyName, "Address must be at least 3 characters.");
                break;

            case nameof(BirthLocation):
                if (string.IsNullOrWhiteSpace(BirthLocation))
                    AddError(propertyName, "Birth Location is required.");
                else if (BirthLocation.Length < 3)
                    AddError(propertyName, "Birth Location must be at least 3 characters.");
                break;

            case nameof(Residence):
                if (string.IsNullOrWhiteSpace(Residence))
                    AddError(propertyName, "Residence is required.");
                else if (Residence.Length < 3)
                    AddError(propertyName, "Residence must be at least 3 characters.");
                break;

            case nameof(Email):
                if (string.IsNullOrWhiteSpace(Email))
                    AddError(propertyName, "Email is required.");
                else if (!IsValidEmail(Email))
                    AddError(propertyName, "Please enter a valid email address.");
                break;

            case nameof(SelectedFamilySituation):
                if (string.IsNullOrWhiteSpace(SelectedFamilySituation?.ToString()))
                    AddError(propertyName, "Selected Family Situation is required.");
                break;

            case nameof(SelectedGender):
                if (string.IsNullOrWhiteSpace(SelectedGender.ToString()))
                    AddError(propertyName, "Selected Gender is required.");
                break;

            case nameof(SelectedDate):
                if (isValidDate(SelectedDate.Value))
                    AddError(propertyName, "Please enter a valid date.");
                break;
        }

        // Notify that CanExecute may have changed
        CommandManager.InvalidateRequerySuggested();
    }

    // Helper method to validate email format
    private bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }

    private bool IsValidPhone(string number)
    {
        try
        {
            var isConverted = int.TryParse(number, out int trueNumber);
            return isConverted;
        }
        catch
        {
            return false;
        }
    }

    private bool isValidDate(DateTime date)
    {
        try
        {
            return DateTime.Now.Year == date.Year;
        }
        catch
        {
            return false;
        }
    }
}
