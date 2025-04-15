using CommunityToolkit.Mvvm.ComponentModel;
using EEMS.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEMS.UI.ViewModels;

public partial class ViewEmployeeDetailsViewModel : ObservableObject
{
    private Employee _employee;
    [ObservableProperty]
    private string _firstName;
    [ObservableProperty]
    private string _lastName;
    [ObservableProperty]
    private string _phone;
    [ObservableProperty]
    private string _email;
    [ObservableProperty]
    private string _jobTitle;
    [ObservableProperty]
    private string _department;
    [ObservableProperty]
    private string _jobNature;
    [ObservableProperty]
    private string _address;
    [ObservableProperty]
    private DateTime _dateOfBirth;
    [ObservableProperty]
    private string _birthLocation;
    [ObservableProperty]
    private string _residence;
    [ObservableProperty]
    private string _familySituation;
    [ObservableProperty]
    private int _gender;
    [ObservableProperty]
    private DateTime _recruitmentDate;
    [ObservableProperty]
    private string _essentialTraining;
    [ObservableProperty]
    private string _training;
    [ObservableProperty]
    private string _languagesSpoken;
    [ObservableProperty]
    private int _experience;
    [ObservableProperty]
    private bool _isActive;




    public ViewEmployeeDetailsViewModel(Employee employee)
    {
        _employee = employee;

        FirstName = employee.FirstName;
        LastName = employee.LastName;
        Phone = employee.Phone.ToString();
        Email = employee.Email;
        JobTitle = employee.JobTitle;
        //Department = employee.Department;
        //JobNature = employee.JobNature;
        Address = employee.Address;
        DateOfBirth = employee.DateOfBirth;
        BirthLocation = employee.BirthLocation;
        Residence = employee.Residence;
        FamilySituation = employee.FamilySituation;
        Gender = employee.Gender;
        RecruitmentDate = employee.RecruitmentDate;
        EssentialTraining = employee.EssentialTraining;
        Training = employee.Training;
        LanguagesSpoken = employee.LanguagesSpoken;
        Experience = employee.Experience ?? 0;
        IsActive = employee.IsActive;
    }

    




}
