using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EEMS.BusinessLogic.Interfaces;
using EEMS.UI.Views.Absences;
using System.Collections.ObjectModel;

namespace EEMS.UI.ViewModels;

public partial class AbsencePageViewModel : ObservableObject
{
    private readonly IEmployeeManagementService _employeeManagementService;
    public ObservableCollection<DataAccess.Models.Absence> Absences { get; set; }

    [ObservableProperty]
    private DataAccess.Models.Absence _selectedAbsence;

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
        Absences = new ObservableCollection<DataAccess.Models.Absence>();
        LoadAbsences();
    }

    private async void LoadAbsences()
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
}
