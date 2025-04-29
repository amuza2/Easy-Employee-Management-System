using EEMS.Utilities.Enums;
using System.ComponentModel.DataAnnotations;

namespace EEMS.DataAccess.Models;

public class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; }//
    public string LastName { get; set; }//
    [Phone]
    public string Phone { get; set; }//
    public string JobTitle { get; set; }
    [EmailAddress]
    public string Email { get; set; }//
    public string Training { get; set; }///
    public DateTime DateOfBirth { get; set; }//
    public string BirthLocation { get; set; }//
    public string Address { get; set; }//
    public FamilySituation FamilySituation { get; set; }//
    public DateTime RecruitmentDate { get; set; }///
    public Gender Gender { get; set; }//
    public string? EssentialTraining { get; set; }///
    public string? LanguagesSpoken { get; set; }///
    public int? Experience { get; set; }///
    public string Residence { get; set; }//
    public Status IsActive { get; set; }
    public bool IsArchived { get; set; }

    public int? DepartmentId { get; set; }
    public virtual Department Department { get; set; }

    public JobNatureEnum JobNatureItem { get; set; }


    //public int? LeaveId { get; set; }
    //public virtual Leave Leave { get; set; }


    public virtual ICollection<Absence> Absences { get; set; } = new List<Absence>();
    //public virtual ICollection<Vacation> Vacations { get; set; } = new List<Vacation>();
    //public virtual ICollection<EmployeeDrivingLicense> EmployeeDrivingLicenses { get; set; } = new List<EmployeeDrivingLicense>();
    //public virtual ICollection<EmployeeTraining> EmployeesTraining { get; set; } = new List<EmployeeTraining>();
    //public virtual ICollection<Diploma> Diplomas { get; set; } = new List<Diploma>();
    //public virtual ICollection<Sanction> Sanctions { get; set; } = new List<Sanction>();

}
