using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EEMS.BusinessLogic.Interfaces;
using EEMS.DataAccess.Models;
using EEMS.UI.Views.Shared;
using EEMS.UI.Views.Shared.MessageBoxes;
using System.Windows;

namespace EEMS.UI.ViewModels;

public partial class AbsenceWindowViewModel : ObservableObject
{
    private readonly IEmployeeManagementService _employeeManagementService;
    private readonly Employee _employee;
    private readonly Absence _absence;

    [ObservableProperty] private bool _isEdit = false;
    [ObservableProperty] private string _firstName;
    [ObservableProperty] private string _lastName;
    [ObservableProperty] private DateTime _selectedDate;
    [ObservableProperty] private bool? _selectedJustification;
    [ObservableProperty] private string _justificationDetail;

    public AbsenceWindowViewModel(Absence absence, IEmployeeManagementService employeeManagementService, bool isEdit)
    {
        _absence = absence;
        IsEdit = true;
        _employeeManagementService = employeeManagementService;
        FirstName = _absence.Employee.FirstName;
        LastName = _absence.Employee.LastName;
        SelectedDate = _absence.Date.Date;
        SelectedJustification = _absence.HasJustification;
        JustificationDetail = _absence.Note;
    }

    public AbsenceWindowViewModel(Employee employee, IEmployeeManagementService employeeManagementService)
    {
        IsEdit = false;
        _employee = employee;
        _employeeManagementService = employeeManagementService;
        FirstName = _employee.FirstName;
        LastName = _employee.LastName;
        SelectedDate = DateTime.Today.Date;
        SelectedJustification = true;
    }

    [RelayCommand]
    private async Task SaveAbsence(Window window)
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

        if(IsEdit)
        {
            _absence.Date = SelectedDate;
            _absence.HasJustification = SelectedJustification.Value;
            _absence.Note = JustificationDetail;
            await _employeeManagementService.AbsenceService.UpdateAsync(_absence);

            await DialogService.ShowSingleButtonMessageBoxAsync(
                    "Absence successfully updated.",
                    "Success",
                    "OK");
        }
        else
        {
            var absence = new Absence
            {
                EmployeeId = _employee.Id,
                Date = SelectedDate.Date,
                HasJustification = SelectedJustification == true,
                Note = JustificationDetail
            };
            if (absence.Note == null) absence.Note = string.Empty;
            await _employeeManagementService.AbsenceService.AddAsync(absence);

            await DialogService.ShowSingleButtonMessageBoxAsync(
                "Absence successfully added.",
                "Success",
                "OK");  
        }

        window?.Close();
    }
}