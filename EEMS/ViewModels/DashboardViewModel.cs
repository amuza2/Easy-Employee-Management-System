using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using EEMS.BusinessLogic.Interfaces;
using EEMS.DataAccess.Models;
using EEMS.UI.Views.Dashboard;
using EEMS.UI.Views.Shared;
using EEMS.UI.Views.Shared.DocumentPrinting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEMS.UI.ViewModels;

public partial class DashboardViewModel : ObservableRecipient
{
    private readonly IEmployeeManagementService _employeeManagementService;
    [ObservableProperty] private Employee? _selectedEmployee;
    
    public DashboardViewModel(IEmployeeManagementService employeeManagementService, IDocumentBuilderFactory documentBuilderFactory, PrintService printService)
    {
        IsActive = true;
        WeakReferenceMessenger.Default.Register<EmployeeSelectedMessage>(this, (r,m) =>
        {
            if (m.Value != null)
            {
                SelectedEmployee = m.Value;
            }
        });
        _employeeManagementService = employeeManagementService;
    }

    [RelayCommand]
    private void ShowEmployeeSearchWindow()
    {
        var employeeSearchWindowViewModel = new EmployeeSearchWindowViewModel(_employeeManagementService);
        var employeeSearchWindow = new EmployeeSearchWindow(employeeSearchWindowViewModel);
        var result = employeeSearchWindow.ShowDialog();
    }

    public int YearsOfService
    {
        get
        {
            if (SelectedEmployee == null)
                return 0;
            
            var startDate = SelectedEmployee.RecruitmentDate;
            var endDate = DateTime.Now;
            var yearsOfService = endDate.Year - startDate.Year;
            if (endDate < startDate.AddYears(yearsOfService))
            {
                yearsOfService--;
            }
            return yearsOfService;
        }
    }
    public int TotalAbsences
    {
        get
        {
            if (SelectedEmployee == null)
                return 0;

            return SelectedEmployee.Absences.Count;
        }
    }

    partial void OnSelectedEmployeeChanged(Employee? oldValue, Employee? newValue)
    {
        OnPropertyChanged(nameof(YearsOfService));
        OnPropertyChanged(nameof(TotalAbsences));
    }
}
