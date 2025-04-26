using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EEMS.BusinessLogic.Interfaces;
using EEMS.DataAccess.Models;
using EEMS.UI.Views.Shared;
using EEMS.UI.Views.Shared.MessageBoxes;
using EEMS.Utilities.Enums;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace EEMS.UI.ViewModels;

public partial class AddAndEditWindowViewModel : ObservableValidator
{
	private readonly IEmployeeManagementService _employeeManagementService;

    [ObservableProperty] [Required(ErrorMessage ="First name cannot be empty")] private string _firstName;
    [ObservableProperty] [Required(ErrorMessage = "Last name cannot be empty")] private string _lastName;
    [ObservableProperty] [MinLength(10, ErrorMessage = "Provide a valid number")] [RegularExpression(@"^\d+$", ErrorMessage = "Phone number must contain digits only")][Required(ErrorMessage = "Phone cannot be empty")] private string _phone;
    [ObservableProperty] [Required(ErrorMessage = "Address cannot be empty")] private string _address;
    [ObservableProperty] [Required(ErrorMessage = "Gender cannot be empty")] private Gender _selectedGender;
    [ObservableProperty] [Required(ErrorMessage = "Email cannot be empty")] private string _email;
    [ObservableProperty] [Required(ErrorMessage = "Birth date cannot be empty")] private DateTime _selectedBirthDate;
    [ObservableProperty] [Required(ErrorMessage = "Birth location cannot be empty")] private string _birthLocation;
    [ObservableProperty] [Required(ErrorMessage = "Family situation cannot be empty")] private FamilySituation _selectedFamilySituation;
    [ObservableProperty] [Required(ErrorMessage = "Residence cannot be empty")] private string _residence;
    [ObservableProperty] [Required(ErrorMessage = "Job title cannot be empty")] private string _jobTitle;
    [ObservableProperty] [Required(ErrorMessage = "Essention training cannot be empty")] private string _essentialTraining;
    [ObservableProperty] [Required(ErrorMessage = "Other training cannot be empty")] private string _otherTraining;
    [ObservableProperty] [Required(ErrorMessage = "Spoken language cannot be empty")] private string _spokenLanguages;
    [ObservableProperty] [Required(ErrorMessage = "Experience cannot be empty")] private int _experience;
    [ObservableProperty] [Required(ErrorMessage = "Department cannot be empty")] private Department _selectedDepartment;
    [ObservableProperty] [Required(ErrorMessage = "Job Nature cannot be empty")] private JobNature _selectedJobNature;
    [ObservableProperty] [Required(ErrorMessage = "recruitment date cannot be empty")] private DateTime _selectedRecruitmentDate;
    [ObservableProperty] [Required(ErrorMessage = "Status cannot be empty")] private Status _selectedStatus;
    [ObservableProperty] private string _buttonName = "Save";
    public ObservableCollection<Department> DepartmentItems { get; } = new();
    public ObservableCollection<JobNature> JobNatureItems { get; } = new();
    public ObservableCollection<FamilySituation> FamilySituationItems { get; } = new();
    public Window? Window { get; set; }
    public Action UpdateEmployeeDataGrid { get; set; }

    partial void OnFirstNameChanged(string value)
    {
        ValidateProperty(value, nameof(FirstName));
    }
    partial void OnLastNameChanged(string value)
    {
        ValidateProperty(value, nameof(LastName));
    }
    partial void OnPhoneChanged(string value)
    {
        ValidateProperty(value, nameof(Address));
    }
    partial void OnSelectedGenderChanged(Gender value)
    {
        ValidateProperty(value, nameof(SelectedGender));
    }
    partial void OnEmailChanged(string value)
    {
        ValidateProperty(value, nameof(Email));
    }
    partial void OnSelectedBirthDateChanged(DateTime value)
    {
        ValidateProperty(value, nameof(SelectedBirthDate));
    }
    partial void OnBirthLocationChanged(string value)
    {
        ValidateProperty(value, nameof(BirthLocation));
    }
    partial void OnSelectedFamilySituationChanged(FamilySituation value)
    {
        ValidateProperty(value, nameof(SelectedFamilySituation));
    }
    partial void OnResidenceChanged(string value)
    {
        ValidateProperty(value, nameof(Residence));
    }
    partial void OnSelectedJobNatureChanged(JobNature value)
    {
        ValidateProperty(value, nameof(SelectedJobNature));
    }
    partial void OnEssentialTrainingChanged(string value)
    {
        ValidateProperty(value, nameof(EssentialTraining));
    }
    partial void OnOtherTrainingChanged(string value)
    {
        ValidateProperty(value, nameof(OtherTraining));
    }
    partial void OnSpokenLanguagesChanged(string value)
    {
        ValidateProperty(value, nameof(SpokenLanguages));
    }
    partial void OnExperienceChanged(int value)
    {
        ValidateProperty(value, nameof(Experience));
    }
    partial void OnSelectedDepartmentChanged(Department value)
    {
        ValidateProperty(value, nameof(SelectedDepartment));
    }
    partial void OnSelectedRecruitmentDateChanged(DateTime value)
    {
        ValidateProperty(value, nameof(SelectedRecruitmentDate));
    }
    partial void OnSelectedStatusChanged(Status value)
    {
        ValidateProperty(value, nameof(SelectedStatus));
    }

    public AddAndEditWindowViewModel( IEmployeeManagementService employeeManagementService)
	{
        ButtonName = "Save";    
        _employeeManagementService = employeeManagementService;
        SelectedBirthDate = DateTime.Today;
        SelectedRecruitmentDate = DateTime.Today;
        LoadFamilySituation();
        _ = LoadDepartmentsAsync();
        _ = LoadJobNatureAsync();
    }

    public AddAndEditWindowViewModel(IEmployeeManagementService employeeManagementService,Employee employee)
    {
        ButtonName = "Update";
        _employeeManagementService = employeeManagementService;
        LoadFamilySituation();
        _ = LoadDepartmentsAsync();
        _ = LoadJobNatureAsync();
        LoadEmployeeDetail(employee);
    }

    private void LoadEmployeeDetail(Employee employee)
    {
        FirstName = employee.FirstName;
        LastName = employee.LastName;
        Phone = employee.Phone;
        Address = employee.Address;
        SelectedGender = (Gender)employee.FamilySituation;
        Email = employee.Email;
        SelectedBirthDate = employee.DateOfBirth;
        BirthLocation = employee.BirthLocation;
        SelectedFamilySituation = employee.FamilySituation;
        Residence = employee.Residence;

        JobTitle = employee.JobTitle;
        EssentialTraining = employee.EssentialTraining ?? "";
        OtherTraining = employee.Training;
        SpokenLanguages = employee.LanguagesSpoken ?? "";
        Experience = (int)employee.Experience;
        SelectedDepartment = DepartmentItems.FirstOrDefault(d => d.Id == employee.Department?.Id);
        SelectedJobNature = JobNatureItems.FirstOrDefault(n => n.Id == employee.JobNature?.Id);
        SelectedRecruitmentDate = employee.RecruitmentDate;
        SelectedStatus = employee.IsActive;
    }

    private void LoadFamilySituation()
    {
        foreach (var item in Enum.GetValues(typeof(FamilySituation)).Cast<FamilySituation>())
        {
            FamilySituationItems.Add(item);
        }
    }

    private async Task LoadJobNatureAsync()
    {
        var jobNatures = await _employeeManagementService.JobNatureService.GetAsync();
        foreach (var jobNature in jobNatures)
        {
            JobNatureItems.Add(jobNature);
        }
    }

    private async Task<IEnumerable<Department>> LoadDepartmentsAsync()
    {
        var departments = await _employeeManagementService.DepartmentService.GetAsync();

        foreach (var department in departments)
        {
            DepartmentItems.Add(department);
        }
        return departments;
    }


    [RelayCommand]
    private async void SaveEmployee()
    {
        if (HasErrors) return;

        var newEmployee = new Employee()
        {
            FirstName = FirstName,
            LastName = LastName,
            Phone = Phone,
            Address = Address,
            Gender = SelectedGender,
            Email = Email,
            DateOfBirth = SelectedBirthDate,
            BirthLocation = BirthLocation,
            FamilySituation = SelectedFamilySituation,
            Residence = Residence,

            JobTitle = JobTitle,
            EssentialTraining = EssentialTraining,
            Training = OtherTraining,
            LanguagesSpoken = SpokenLanguages,
            Experience = Experience,
            DepartmentId = SelectedDepartment.Id,
            JobNatureId = SelectedJobNature?.Id,
            RecruitmentDate = SelectedRecruitmentDate,
            IsActive = SelectedStatus
        };

        var employeeId = await _employeeManagementService.EmployeeService.AddAsync(newEmployee);
        if (employeeId < 1)
        {
            await DialogService.ShowSingleButtonMessageBoxAsync(
                "Error adding employee. Please try again.",
                "Error",
                "OK");
            return;
        }
        await DialogService.ShowSingleButtonMessageBoxAsync(
            $"Employee added successfully.",
            "Success",
            "OK");

        UpdateEmployeeDataGrid?.Invoke();
        Window?.Close();
    }

}
