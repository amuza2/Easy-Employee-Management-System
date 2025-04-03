using EEMS.BusinessLogic.Interfaces;
using EEMS.UI.MVVM;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Windows;
using System.Windows.Input;

namespace EEMS.UI.ViewModels;

public class JobInformationViewModel : ViewModelBase
{
    private readonly IEmployeeManagementService _employeeManagementService;
    private string _jobTitle;
    public string JobTitle
    {
        get { return _jobTitle; }
        set 
        { 
            _jobTitle = value;
            OnPropertyChanged();
            ValidateProperty(nameof(JobTitle));
        }
    }

    private string _essentialTraining;

    public string EssentialTraining
    {
        get { return _essentialTraining; }
        set 
        { 
            _essentialTraining = value; 
            OnPropertyChanged();
            ValidateProperty(nameof(EssentialTraining));
        }
    }

    private string _spokenLanguages;

    public string SpokenLanguages
    {
        get { return _spokenLanguages; }
        set 
        { 
            _spokenLanguages = value; 
            OnPropertyChanged();
            ValidateProperty(nameof(SpokenLanguages));
        }
    }

    private int _experience;

    public int Experience
    {
        get { return _experience; }
        set 
        { 
            _experience = value;
            OnPropertyChanged();
            ValidateProperty(nameof(Experience));
        }
    }

    private DateTime? _selectedDate;

    public DateTime? SelectedDate
    {
        get { return _selectedDate; }
        set 
        { 
            _selectedDate = value;
            OnPropertyChanged();
            ValidateProperty(nameof(SelectedDate));
        }
    }

    private ObservableCollection<string> _departmentItems;

    public ObservableCollection<string> DepartmentItems
    {
        get { return _departmentItems; }
        set { _departmentItems = value; OnPropertyChanged(); }
    }

    private string _selectedDeparment;

    public string SelectedDeparment
    {
        get { return _selectedDeparment; }
        set 
        { _selectedDeparment = value;
            OnPropertyChanged();
            ValidateProperty(nameof(SelectedDeparment));
        }
    }

    private ObservableCollection<string> _jobNatureItems;

    public ObservableCollection<string> JobNatureItems
    {
        get { return _jobNatureItems; }
        set { _jobNatureItems = value; OnPropertyChanged(); }
    }

    private string _selectedJobNature;

    public string SelectedJobNature
    {
        get { return _selectedJobNature; }
        set 
        { 
            _selectedJobNature = value; 
            OnPropertyChanged();
            ValidateProperty(nameof(SelectedJobNature));
        }
    }

    private string _selectedStatus;

    public string SelectedStatus
    {
        get { return _selectedStatus; }
        set 
        { 
            _selectedStatus = value; 
            OnPropertyChanged();
            ValidateProperty(nameof(SelectedStatus));
        }
    }

    private string _otherTraining;

    public string OtherTraining
    {
        get { return _otherTraining; }
        set 
        { _otherTraining = value; 
            OnPropertyChanged();
            ValidateProperty(nameof(OtherTraining));
        }
    }

    public JobInformationViewModel(IEmployeeManagementService employeeManagementService)
    {
        _employeeManagementService = employeeManagementService;
        DepartmentItems = new ObservableCollection<string>();
        JobNatureItems = new ObservableCollection<string>();

        _ = GetValuesToFillControls(); 
        SelectedDate = DateTime.Now.Date;
    }

    private async Task GetValuesToFillControls()
    {
        await SetDepartmentNamesToControl();
        await SetJobNatureNamesToControl();
    }

    private async Task SetJobNatureNamesToControl()
    {
        try
        {   
            var jobNatureNames = await _employeeManagementService.GetJobNaturesAsync();
            foreach (var item in jobNatureNames)
            {
                JobNatureItems.Add(item.Name);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}");
        }
    }

    private async Task SetDepartmentNamesToControl()
    {
        try
        {
            var departments = await _employeeManagementService.GetDepartmentsAsync();
            foreach (var item in departments)
            {
                DepartmentItems.Add(item.Name);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}");
        }
        
    }

    public void ValidateAllProperties()
    {
        ValidateProperty(nameof(JobTitle));
        ValidateProperty(nameof(EssentialTraining));
        ValidateProperty(nameof(SpokenLanguages));
        ValidateProperty(nameof(Experience));
        ValidateProperty(nameof(SelectedDeparment));
        ValidateProperty(nameof(SelectedJobNature));
        ValidateProperty(nameof(SelectedStatus));
        ValidateProperty(nameof(OtherTraining));
        ValidateProperty(nameof(SelectedDate));
    }

    public bool AreRequiredFieldsFilled()
    {
        // Check if all are valid
        return !string.IsNullOrWhiteSpace(JobTitle) &&
               !string.IsNullOrWhiteSpace(EssentialTraining) &&
               !string.IsNullOrWhiteSpace(SpokenLanguages) &&
               Experience >= 0 &&
               !string.IsNullOrWhiteSpace(SelectedDeparment) &&
               !string.IsNullOrWhiteSpace(SelectedJobNature) &&
               !string.IsNullOrWhiteSpace(SelectedStatus) &&
               !string.IsNullOrWhiteSpace(OtherTraining) &&
               SelectedDate.HasValue;
    }

    // Override the validation method
    protected override void ValidateProperty(string propertyName)
    {
        // Clear existing errors for this property
        RemoveError(propertyName);

        switch (propertyName)
        {
            case nameof(JobTitle):
                if (string.IsNullOrWhiteSpace(JobTitle))
                    AddError(propertyName, "Job Title is required.");
                else if (JobTitle.Length < 3)
                    AddError(propertyName, "Job Title must be at least 3 characters.");
                break;

            case nameof(EssentialTraining):
                if (string.IsNullOrWhiteSpace(EssentialTraining))
                    AddError(propertyName, "Essential Training is required.");
                else if (EssentialTraining.Length < 3)
                    AddError(propertyName, "Essential Training must be at least 3 characters.");
                break;

            case nameof(SpokenLanguages):
                if (string.IsNullOrWhiteSpace(SpokenLanguages))
                    AddError(propertyName, "Spoken Languages is required.");
                else if (SpokenLanguages.Length < 3)
                    AddError(propertyName, "Spoken Languages must be at least 3 characters.");
                break;

            case nameof(Experience):
                if (Experience < 0)
                    AddError(propertyName, "Experience can't be negative.");
                else if (Experience > 70)
                    AddError(propertyName, "Experience can't be that high.");
                break;

            case nameof(SelectedDeparment):
                if (string.IsNullOrWhiteSpace(SelectedDeparment))
                    AddError(propertyName, "Selected Deparment is required.");
                break;

            case nameof(SelectedJobNature):
                if (string.IsNullOrWhiteSpace(SelectedJobNature))
                    AddError(propertyName, "Selected Job Nature is required.");
                break;

            case nameof(SelectedStatus):
                if (string.IsNullOrWhiteSpace(SelectedStatus))
                    AddError(propertyName, "Selected Status is required.");
                break;

            case nameof(OtherTraining):
                if (string.IsNullOrWhiteSpace(OtherTraining))
                    AddError(propertyName, "Other Training is required.");
                else if (OtherTraining.Length < 3)
                    AddError(propertyName, "Other Training must be at least 3 characters.");
                break;

            case nameof(SelectedDate):
                if (!SelectedDate.HasValue)
                    AddError(propertyName, "Please enter a valid date.");
                break;
        }

        // Notify that CanExecute may have changed
        CommandManager.InvalidateRequerySuggested();
    }
}
