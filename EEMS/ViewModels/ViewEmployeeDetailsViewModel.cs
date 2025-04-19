using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EEMS.BusinessLogic.Interfaces;
using EEMS.DataAccess.Models;
using System.Windows.Controls;
using System.Windows.Documents;

namespace EEMS.UI.ViewModels;
                                                   
public partial class ViewEmployeeDetailsViewModel : ObservableObject
{
    private Employee _employee;
    [ObservableProperty] private string _firstName;
    [ObservableProperty] private string _lastName;
    [ObservableProperty] private string _phone;
    [ObservableProperty] private string _email;
    [ObservableProperty] private string _jobTitle;
    [ObservableProperty] private string _department;
    [ObservableProperty] private string _jobNature;
    [ObservableProperty] private string _address;
    [ObservableProperty] private DateTime _dateOfBirth;
    [ObservableProperty] private string _birthLocation;
    [ObservableProperty] private string _residence;
    [ObservableProperty] private string _familySituation;
    [ObservableProperty] private string _gender;
    [ObservableProperty] private DateTime _recruitmentDate;
    [ObservableProperty] private string _essentialTraining;
    [ObservableProperty] private string _training;
    [ObservableProperty] private string _languagesSpoken;
    [ObservableProperty] private int _experience;
    [ObservableProperty] private string _isActive;

    private readonly IEmployeeManagementService _employeeManagementService;

    public ViewEmployeeDetailsViewModel(Employee employee, IEmployeeManagementService employeeManagementService)
    {
        _employee = employee;
        _employeeManagementService = employeeManagementService;

        FirstName = employee.FirstName;
        LastName = employee.LastName;
        Phone = employee.Phone.ToString();
        Email = employee.Email;
        JobTitle = employee.JobTitle;
        Department = "IT";
        JobNature = "Full-time";
        Address = employee.Address;
        DateOfBirth = employee.DateOfBirth.Date;
        BirthLocation = employee.BirthLocation;
        Residence = employee.Residence;
        FamilySituation = employee.FamilySituation;
        Gender = employee.Gender == 0 ? "Female" : "Male";
        RecruitmentDate = employee.RecruitmentDate.Date;
        EssentialTraining = employee.EssentialTraining;
        Training = employee.Training;
        LanguagesSpoken = employee.LanguagesSpoken;
        Experience = employee.Experience ?? 0;
        IsActive = employee.IsActive ? "Active" : "Inactive";
    }

    [RelayCommand]
    private void PrintEmployeeDetail()
    {
        var printDialog = new PrintDialog();
        if (printDialog.ShowDialog() == true)
        {
            var document = new FlowDocument();
            var paragraph = new Paragraph(new Run($"First name: {FirstName}\nLast name: {LastName}"));
            document.Blocks.Add(paragraph);

            var paginator = ((IDocumentPaginatorSource)document).DocumentPaginator;
            printDialog.PrintDocument(paginator, "Employee Details");
        }
    }

    //private Task<string> GetDepartmentName(int id)
    //{
    //    var departmentName =  _employeeManagementService.GetAsync(id);
    //    return departmentName;
    //}




}
