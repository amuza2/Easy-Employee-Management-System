using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EEMS.BusinessLogic.Interfaces;
using EEMS.Models.Models;
using EEMS.UI.Views.Absences;
using System.Collections.ObjectModel;

namespace EEMS.UI.ViewModels;

public partial class AbsencePageViewModel : ObservableObject
{
    private readonly IEmployeeManagementService _employeeManagementService;
    public ObservableCollection<Absence> Absences { get; set; }

    [ObservableProperty] private Absence _selectedAbsence;
    [ObservableProperty] private string _shownDate = DateTime.Today.ToString("dd/MM/yyyy");
    [ObservableProperty] private DateTime _selectedDate;

    [RelayCommand]
    private void ViewAbsence()
    {
        if (SelectedAbsence != null)
        {
            var employeeDetails = new ViewAbsenceDetailsViewModel(SelectedAbsence, _employeeManagementService);
            var viewEmployeeDetailsWindow = new ViewAbsenceDetails(employeeDetails);
            viewEmployeeDetailsWindow.ShowDialog();
            SelectedAbsence = null;
        }
    }

    [RelayCommand]
    private void EditAbsence(object obj)
    {
        if(SelectedAbsence != null)
        {
            var absenceDetails = new AbsenceWindowViewModel(SelectedAbsence, _employeeManagementService, true);
            var viewEmployeeDetailsWindow = new AbsenceWindow(absenceDetails);
            viewEmployeeDetailsWindow.ShowDialog();
            SelectedAbsence = null;
        }
    }

    public AbsencePageViewModel(IEmployeeManagementService employeeManagementService)
    {
        _employeeManagementService = employeeManagementService;
        Absences = new ObservableCollection<Absence>();
        _ = LoadAbsences();

    }

    private async Task LoadAbsences()
    {
        var absences = await _employeeManagementService.AbsenceService.GetAsync();
        if (absences != null)
        {
            foreach (var absence in absences)
            {
                Absences.Add(absence);
            }
        }
    }

    partial void OnSelectedDateChanged(DateTime value)
    {
        ShownDate = value.ToString("dd/MM/yyyy");
        _ = LoadDataGridWithSelectedDate(value);
    }

    private async Task LoadDataGridWithSelectedDate(DateTime date)
    {
        var absences = await _employeeManagementService.AbsenceService.GetAsync();
        if (absences != null)
        {
            Absences.Clear();
            foreach (var absence in absences)
            {
                if (absence.Date.Date == date.Date)
                {
                    Absences.Add(absence);
                }
            }
        }
    }
        
}
