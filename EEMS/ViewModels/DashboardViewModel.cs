using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using EEMS.BusinessLogic.Interfaces;
using EEMS.Models.Models;
using EEMS.UI.Views.Absences;
using EEMS.UI.Views.Dashboard;
using EEMS.UI.Views.Employees;
using EEMS.UI.Views.Shared;
using EEMS.UI.Views.Shared.DocumentPrinting;
using EEMS.Utilities.Enums;

namespace EEMS.UI.ViewModels;

public partial class DashboardViewModel : ObservableRecipient
{
    private readonly IEmployeeManagementService _employeeManagementService;
    private IDocumentBuilderFactory _factory;
    private readonly PrintService _printService;
    [ObservableProperty] private Employee? _selectedEmployee;
    
    public DashboardViewModel(IEmployeeManagementService employeeManagementService, IDocumentBuilderFactory documentBuilderFactory, PrintService printService)
    {
        _factory = documentBuilderFactory;
        _printService = printService;
        IsActive = true;
        WeakReferenceMessenger.Default.Register<EmployeeSelectedMessage>(this, (r,m) =>
        {
            if (m.Value != null)
            {
                SelectedEmployee = m.Value;
            }
        });
        _employeeManagementService = employeeManagementService;
        _ = LoadingAnEmployeeToDashboard();
    }

    private async Task LoadingAnEmployeeToDashboard()
    {
        SelectedEmployee = await _employeeManagementService.EmployeeService.GetFirstEmployeeAsync();
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

    [RelayCommand]
    private void ViewEmployeeDetails(object obj)
    {
        if (SelectedEmployee != null)
        {
            var employeeDetails = new ViewEmployeeDetailsViewModel(SelectedEmployee);
            var viewEmployeeDetailsWindow = new ViewEmployeeDetails(employeeDetails);
            viewEmployeeDetailsWindow.ShowDialog();
        }
    }

    [RelayCommand]
    private void GenerateReport(object obj)
    {
        if (SelectedEmployee != null)
        {
            var builder = _factory.Create(DocumentType.WorkCertificate, SelectedEmployee);
            _printService.PreviewDocument(builder);
        }
    }

    [RelayCommand]
    private void AddAbsence(object obj)
    {
        if (SelectedEmployee != null)
        {
            var employeeAbsenceViewModel = new AbsenceWindowViewModel(SelectedEmployee, _employeeManagementService);
            var employeeAbsenceWindow = new AbsenceWindow(employeeAbsenceViewModel);
            employeeAbsenceWindow.ShowDialog();
        }
    }

    [RelayCommand]
    private void EditEmployee(object obj)
    {
        if (SelectedEmployee != null)
        {
            //viewModel.UpdateGridWindowData = LoadEmployees;
            var viewModel = new AddAndEditWindowViewModel(_employeeManagementService, SelectedEmployee);
            var addAndEditWindow = new AddAndEditWindow(viewModel);
            addAndEditWindow.ShowDialog();
        }
    }
}
