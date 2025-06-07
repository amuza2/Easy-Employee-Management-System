using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EEMS.BusinessLogic.Interfaces;
using EEMS.Models.Models;
using EEMS.UI.Views.Shared.MessageBoxes;
using EEMS.Utilities.Enums;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Windows;

namespace EEMS.UI.ViewModels;

public partial class AddAndEditCondidateViewModel : ObservableValidator
{
    private Condidate _condidate;
    private readonly ICondidateManagementService _condidateManagementService;

    // Personal Information
    [ObservableProperty][Required(ErrorMessage = "First name cannot be empty")] private string _firstName;
    [ObservableProperty][Required(ErrorMessage = "Last name cannot be empty")] private string _lastName;
    [ObservableProperty][Required(ErrorMessage = "Phone cannot be empty")] private string _phone;
    [ObservableProperty][Required(ErrorMessage = "Address cannot be empty")] private string _address;
    [ObservableProperty] private Gender _selectedGender;
    [ObservableProperty][Required(ErrorMessage = "Residence cannot be empty")] private string _residence;
    [ObservableProperty][Required(ErrorMessage = "Email cannot be empty")] private string _email;
    [ObservableProperty][Required(ErrorMessage = "Date of birth cannot be empty")] private DateTime? _dateOfBirth;
    [ObservableProperty][Required(ErrorMessage = "Birth location cannot be empty")] private string _birthLocation;
    [ObservableProperty] private FamilySituation _selectedFamilySituation;
    [ObservableProperty] private BloodGroup _selectedBloodGroup;
    [ObservableProperty] private DrivingLicense _hasDrvinglicense;
    [ObservableProperty] private bool _knowMicrosoftOfficeSoftware;

    // Family Information
    [ObservableProperty] private string _fatherFullName;
    [ObservableProperty] private string _fatherJob;
    [ObservableProperty] private int _numberOfBrothersAndSisters;
    [ObservableProperty] private string _motherFullName;
    [ObservableProperty] private string _motherJob;
    [ObservableProperty] private string _husbandFullname;
    [ObservableProperty] private string _husbandJob;

    // Document Information
    [ObservableProperty] private string _bankAccountNumber;
    [ObservableProperty] private string _socialSecurityNumber;
    [ObservableProperty] private string _nationalCardNumber;
    [ObservableProperty] private DateTime? _nationalCardNumberReleaseDate;

    // National Service
    [ObservableProperty] private bool _clearedFromNationalService;
    [ObservableProperty] private bool _nationalServiceSuitableNotIncorporated;
    [ObservableProperty] private DateTime? _nationalServiceDateSuspendedFrom;
    [ObservableProperty] private DateTime? _nationalServiceDateSuspendedTo;

    // Job Information
    [ObservableProperty] private DateTime? _interviewDate;
    [ObservableProperty] private string _essentialTraining;
    [ObservableProperty] private string _training;
    [ObservableProperty] private string _languagesSpoken;
    [ObservableProperty] private int _experience;
    [ObservableProperty] private JobNatureEnum _selectedJobNature;
    [ObservableProperty] private OpenedJob _selectedOpenedJob;

    // Collection Properties
    [ObservableProperty] private ObservableCollection<FamilySituation> _familySituationItems = new();
    [ObservableProperty] private ObservableCollection<BloodGroup> _bloodGroupItems = new();
    [ObservableProperty] private ObservableCollection<JobNatureEnum> _jobNatureItems = new();
    [ObservableProperty] private ObservableCollection<OpenedJob> _openedJobItems = new();

    // Button and UI-related properties
    [ObservableProperty] private string _buttonName;

    // Close addAndEditCondidateWindow when save button is clicked
    public Window? Window { get; set; }
    // Update the Condidate data grid when a new condidate is added or updated
    public Action UpdateEmployeeDataGrid { get; set; }

    public AddAndEditCondidateViewModel(ICondidateManagementService condidateManagementService)
    {
        _condidateManagementService = condidateManagementService;
        ButtonName = "Save Condidate";
        LoadFamilySituation();
        LoadBloodGroup();
        LoadJobNature();
        _ = LoadOpenedJob();
        DateOfBirth = DateTime.Today;
        NationalCardNumberReleaseDate = DateTime.Today;
        InterviewDate = DateTime.Today;
        NationalServiceDateSuspendedFrom = DateTime.Today;
        NationalServiceDateSuspendedTo = DateTime.Today;
    }

    // Load family situation items to combobox
    private void LoadFamilySituation()
    {
        foreach (var item in Enum.GetValues(typeof(FamilySituation)).Cast<FamilySituation>())
        {
            FamilySituationItems.Add(item);
        }
    }

    // Load blood group items to combobox
    private void LoadBloodGroup()
    {
        foreach (var item in Enum.GetValues(typeof(BloodGroup)).Cast<BloodGroup>())
        {
            BloodGroupItems.Add(item);
        }
    }

    // Load job nature items to combobox
    private void LoadJobNature()
    {
        foreach (var item in Enum.GetValues(typeof(JobNatureEnum)).Cast<JobNatureEnum>())
        {
            JobNatureItems.Add(item);
        }
    }

    // Load opened job items to combobox
    private async Task LoadOpenedJob()
    {
        // Assuming you have a method to get opened jobs from the database
        var openedJobs = await _condidateManagementService.OpenedJobService.GetAsync();
        foreach (var job in openedJobs)
        {
            OpenedJobItems.Add(job);
        }
    }

    // Save or Update candidate 
    [RelayCommand]
    private async void SaveCandidate()
    {
        ValidateAllProperties();

        // check any validation errors
        if (HasErrors)
        {
            await DialogService.ShowSingleButtonMessageBoxAsync(
                "Please correct the validation errors before saving.",
                "Validation Error",
                "OK");
            return;
        }


        var newCondidate = new Condidate()
        {
            // Personal Information
            FirstName = FirstName,
            LastName = LastName,
            Phone = Phone,
            Address = Address,
            Gender = SelectedGender,
            Residence = Residence,
            Email = Email,
            DateOfBirth = DateOfBirth.GetValueOrDefault(),
            BirthLocation = BirthLocation,
            FamilySituation = SelectedFamilySituation,
            BloodGroup = SelectedBloodGroup,
            HasDrivingLicense = HasDrvinglicense,
            KnowMicrosoftOfficeSoftware = KnowMicrosoftOfficeSoftware,

            // Family Information
            FatherFullName = FatherFullName,
            FatherJob = FatherJob,
            NumberOfBrothersAndSisters = NumberOfBrothersAndSisters,
            MotherFullName = MotherFullName,
            MotherJob = MotherJob,
            HusbandFullname = HusbandFullname,
            HusbandJob = HusbandJob,

            // Document Information
            BankAccountNumber = BankAccountNumber,
            SocialSecurityNumber = SocialSecurityNumber,
            NationalCardNumber = NationalCardNumber,
            NationalCardNumberReleaseDate = (DateTime)NationalCardNumberReleaseDate,

            // National Service
            ClearedFromNationalService = ClearedFromNationalService,
            NationalServiceSuitableNotIncorporated = NationalServiceSuitableNotIncorporated,
            NationalServiceDateSuspendedFrom = NationalServiceDateSuspendedFrom,
            NationalServiceDateSuspendedTo = NationalServiceDateSuspendedTo,

            // Job Information
            InterviewDate = (DateTime)InterviewDate,
            EssentialTraining = EssentialTraining,
            Training = Training,
            LanguagesSpoken = LanguagesSpoken,
            Experience = Experience,
            JobNatureItem = SelectedJobNature,
            OpenedJobId = SelectedOpenedJob?.Id
        };

        int condidateId;

        if(_condidate == null)
        {
            condidateId = await _condidateManagementService.CondidateService.AddAsync(newCondidate);
            if (condidateId < 1)
            {
                await DialogService.ShowSingleButtonMessageBoxAsync(
                    "Error adding condidate. Please try again.",
                    "Error",
                    "OK");
                return;
            }
            await DialogService.ShowSingleButtonMessageBoxAsync(
                $"Condidate added successfully.",
                "Success",
                "OK");
        }
        else
        {
            // update condidate
        }

        // close the window
        Window?.Close();
        // update the data grid
        UpdateEmployeeDataGrid?.Invoke();
    }
}
