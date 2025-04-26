using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EEMS.DataAccess.Models;
using EEMS.UI.Views.Shared.DocumentPrinting;
using EEMS.Utilities.Enums;

namespace EEMS.UI.ViewModels;

public partial class CondidateDetailsViewViewModel : ObservableObject
{
    private Condidate _condidate;
    private readonly IDocumentBuilderFactory _factory;
    private readonly PrintService _printService;

    [ObservableProperty] private string _firstName;
    [ObservableProperty] private string _lastName;
    [ObservableProperty] private string _phone;
    [ObservableProperty] private string _email;
    [ObservableProperty] private string _training;
    [ObservableProperty] private DateTime _dateOfBirth;
    [ObservableProperty] private string _birthLocation;
    [ObservableProperty] private string _address;
    [ObservableProperty] private FamilySituation _familySituation;
    [ObservableProperty] private DateTime _interviewDate;
    [ObservableProperty] private Gender _gender;
    [ObservableProperty] private string _essentialTraining;
    [ObservableProperty] private string _languagesSpoken;
    [ObservableProperty] private int _experience;
    [ObservableProperty] private string _residence;
    [ObservableProperty] private bool _isArchived;
    [ObservableProperty] private DrivingLicense _hasDrivingLicence;
    [ObservableProperty] private bool _knowMicrosoftOfficeSoftware;
    [ObservableProperty] private string _fatherFullName;
    [ObservableProperty] private string _motherFullName;
    [ObservableProperty] private string _fatherJob;
    [ObservableProperty] private string _motherJob;
    [ObservableProperty] private BloodGroup _bloodGroup;
    [ObservableProperty] private int _numberOfBrothersAndSisters;
    [ObservableProperty] private string _husbandFullName;
    [ObservableProperty] private string _husbandJob;
    [ObservableProperty] private string _bankAccountNumber;
    [ObservableProperty] private string _socialSecurityNumber;
    [ObservableProperty] private string _nationalCardNumber;
    [ObservableProperty] private DateTime _nationalCardNumberReleaseDate;
    [ObservableProperty] private bool? _clearedFromNationalService;
    [ObservableProperty] private DateTime? _nationalServiceDateSuspendedFrom;
    [ObservableProperty] private DateTime? _nationalServiceDateSuspendedTo;
    [ObservableProperty] private bool? _nationalServiceSuitableNotIncorporated;
    [ObservableProperty] private string _openedJobName;
    [ObservableProperty] private string _jobNatureName;

    public CondidateDetailsViewViewModel(Condidate condidate, IDocumentBuilderFactory factory, PrintService printService)
    {
        _condidate = condidate;
        _factory = factory;
        _printService = printService;

        FirstName = _condidate.FirstName;
        LastName = _condidate.LastName;
        Phone = _condidate.Phone;
        Email = _condidate.Email;
        Training = _condidate.Training;
        DateOfBirth = _condidate.DateOfBirth.Date;
        BirthLocation = _condidate.BirthLocation;
        Address = _condidate.Address;
        FamilySituation = _condidate.FamilySituation;
        InterviewDate = _condidate.InterviewDate.Date;
        Gender = _condidate.Gender;
        EssentialTraining = _condidate.EssentialTraining ?? string.Empty;
        LanguagesSpoken = _condidate.LanguagesSpoken ?? string.Empty;
        Experience = _condidate.Experience ?? 0;
        Residence = _condidate.Residence;
        IsArchived = _condidate.IsArchived;
        HasDrivingLicence = _condidate.HasDrivingLicence;
        KnowMicrosoftOfficeSoftware = _condidate.KnowMicrosoftOfficeSoftware;
        FatherFullName = _condidate.FatherFullName ?? string.Empty;
        MotherFullName = _condidate.MotherFullName ?? string.Empty;
        FatherJob = _condidate.FatherJob ?? string.Empty;
        MotherJob = _condidate.MotherJob ?? string.Empty;
        BloodGroup = _condidate.BloodGroup;
        NumberOfBrothersAndSisters = _condidate.NumberOfBrothersAndSisters ?? 0;
        HusbandFullName = _condidate.HusbandFullname ?? string.Empty;
        HusbandJob = _condidate.HusbandJob ?? string.Empty;
        BankAccountNumber = _condidate.BankAccountNumber;
        SocialSecurityNumber = _condidate.SocialSecurityNumber;
        NationalCardNumber = _condidate.NationalCardNumber;
        NationalCardNumberReleaseDate = _condidate.NationalCardNumberReleaseDate.Date;
        ClearedFromNationalService = _condidate.ClearedFromNationalService;
        NationalServiceDateSuspendedFrom = _condidate.NationalServiceDateSuspendedFrom;
        NationalServiceDateSuspendedTo = _condidate.NationalServiceDateSuspendedTo;
        NationalServiceSuitableNotIncorporated = _condidate.NationalServiceSuitableNotIncorporated;
        OpenedJobName = _condidate.OpenedJob?.Name ?? string.Empty;
        JobNatureName = _condidate.JobNature?.Name ?? string.Empty;
    }

    [RelayCommand]
    private void PrintCandidateDetail()
    {
        var builder = _factory.Create(DocumentType.CondidateDetails, _condidate);
        _printService.Print(builder);
    }

}
