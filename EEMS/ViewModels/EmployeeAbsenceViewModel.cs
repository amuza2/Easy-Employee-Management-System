using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EEMS.BusinessLogic.Interfaces;
using EEMS.DataAccess.Models;
using EEMS.UI.Views.Shared;

namespace EEMS.UI.ViewModels;

public partial class EmployeeAbsenceViewModel : ObservableObject
{
    private readonly IEmployeeManagementService _employeeManagementService;
    private readonly Employee _employee;

    [ObservableProperty] private string _firstName;
    [ObservableProperty] private string _lastName;

    public EmployeeAbsenceViewModel(Employee employee, IEmployeeManagementService employeeManagementService)
    {
        _employee = employee;
        _employeeManagementService = employeeManagementService;

        FirstName = _employee.FirstName;
        LastName = _employee.LastName;
        SelectedDate = DateTime.Today.Date;
        SelectedJustification = true;
    }

    [ObservableProperty] private DateTime _selectedDate;
    [ObservableProperty] private bool? _selectedJustification;
    [ObservableProperty] private string _justificationDetail;

    [RelayCommand]
    private async Task AddAbsence()
    {
        if (SelectedDate == null)
        {
            await DialogService.ShowSingleButtonMessageBoxAsync(
                "Please select a date for the absence.",
                "Missing Information",
                "OK");
            return;
        }

        if (SelectedJustification == null)
        {
            await DialogService.ShowSingleButtonMessageBoxAsync(
                "Please select whether the absence is justified or not.",
                "Missing Justification",
                "OK");
            return;

        }

    var absence = new Absence
        {
            EmployeeId = _employee.Id,
            Date = SelectedDate.Date,
            HasJustification = SelectedJustification == true,
            Note = JustificationDetail
        };
        if(absence.Note == null) absence.Note = string.Empty;

        await _employeeManagementService.AbsenceService.AddAsync(absence);

        await DialogService.ShowSingleButtonMessageBoxAsync(
            "Absence successfully added.",
            "Success",
            "OK");
    }


}