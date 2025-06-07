using EEMS.Utilities.Enums;
using System.ComponentModel.DataAnnotations;

namespace EEMS.Models.Models;

public class Condidate
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [Phone]
    public string Phone { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    public string Training { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string BirthLocation { get; set; }
    public string Address { get; set; }
    public FamilySituation FamilySituation { get; set; }
    public DateTime InterviewDate { get; set; }
    public Gender Gender { get; set; }
    public string? EssentialTraining { get; set; }
    public string? LanguagesSpoken { get; set; }
    public int? Experience { get; set; }
    public string Residence { get; set; }
    public bool IsArchived { get; set; }
    public DrivingLicense HasDrivingLicense { get; set; }
    public bool KnowMicrosoftOfficeSoftware { get; set; }
    public string? FatherFullName { get; set; }
    public string? MotherFullName { get; set; }
    public string? FatherJob { get; set; }
    public string? MotherJob { get; set; }
    public BloodGroup BloodGroup { get; set; }
    public int? NumberOfBrothersAndSisters { get; set; }
    public string? HusbandFullname { get; set; }
    public string? HusbandJob { get; set; }
    public string BankAccountNumber { get; set; }
    public string SocialSecurityNumber { get; set; }
    public string NationalCardNumber { get; set; }
    public DateTime NationalCardNumberReleaseDate { get; set; }
    public bool? ClearedFromNationalService { get; set; }
    public DateTime? NationalServiceDateSuspendedFrom { get; set; }
    public DateTime? NationalServiceDateSuspendedTo { get; set; }
    public bool? NationalServiceSuitableNotIncorporated { get; set; }

    public int? OpenedJobId { get; set; }
    public virtual OpenedJob OpenedJob { get; set; }

    public JobNatureEnum JobNatureItem { get; set; }
}
