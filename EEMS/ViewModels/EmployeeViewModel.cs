using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EEMS.BusinessLogic.Interfaces;
using EEMS.UI.Enums;
using EEMS.UI.ViewModels;
using EEMS.UI.Views.Absences;
using EEMS.UI.Views.Shared;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace EEMS.UI.Views.Employees;

public partial class EmployeeViewModel : ObservableObject
{
    private readonly IEmployeeManagementService _employeeManagementService;
    public ObservableCollection<DataAccess.Models.Employee> Employees { get; set; }

    [ObservableProperty]
    private DataAccess.Models.Employee _selectedEmployee;

    [ObservableProperty] private string _selectedTab = "All";

    [ObservableProperty] private bool _isEditing;
    
    public bool IsNotEditing => !IsEditing;

    [RelayCommand(CanExecute = nameof(CanPerformUserAction))]
    private void ViewEmployee(object obj)
    {
        if (SelectedEmployee != null)
        {
            var employeeDetails = new ViewEmployeeDetailsViewModel(SelectedEmployee, _employeeManagementService);
            var viewEmployeeDetailsWindow = new ViewEmployeeDetails(employeeDetails);
            viewEmployeeDetailsWindow.ShowDialog();
            SelectedEmployee = null;
        }
    }

    [RelayCommand]
    private void SelectTab(string tabName)
    {
        //Debug.WriteLine($"Selected tab: {tabName}");
        SelectedTab = tabName;
    }


    private bool CanPerformUserAction(object obj)
    {
        return SelectedEmployee != null && !IsEditing;
    }

    partial void OnIsEditingChanged(bool value)
    {
        OnPropertyChanged(nameof(IsNotEditing));
        ViewEmployeeCommand.NotifyCanExecuteChanged();
    }

    partial void OnSelectedEmployeeChanged(DataAccess.Models.Employee value)
    {
        ViewEmployeeCommand.NotifyCanExecuteChanged();
    }


    public EmployeeViewModel(IEmployeeManagementService employeeManagementService)
    {
        _employeeManagementService = employeeManagementService;
        Employees = new ObservableCollection<DataAccess.Models.Employee>();
        IsEditing = false;
        SelectedTab = "All";
        LoadDataForTab("All");
    }

    partial void OnSelectedTabChanged(string value)
    {
        LoadDataForTab(value);
    }

    private async void LoadDataForTab(string tab)
    {
        if (tab == "All")
        {
            GetAllEmployees();
        }
        else if (tab == "Absence")
        {
            GetAllAbsence();
        }
    }

    [RelayCommand]
    private void AddEmployee()
    {
        var viewModel = new AddAndEditWindowViewModel(new PersonalInformationViewModel(),
                                                      new JobInformationViewModel(_employeeManagementService),
                                                      _employeeManagementService);

        viewModel.UpdateGridWindowData = GetAllEmployees;

        var AddAndEditWindow = new AddAndEditWindow(viewModel);
        AddAndEditWindow.ShowDialog();
    }

    [RelayCommand]
    private void EditEmployee()
    {
        if (SelectedEmployee != null)
        {
            var viewModel = new AddAndEditWindowViewModel(new PersonalInformationViewModel(_employeeManagementService, SelectedEmployee),
                                                          new JobInformationViewModel(_employeeManagementService, SelectedEmployee),
                                                          _employeeManagementService);
            //viewModel.UpdateGridWindowData = LoadEmployees;
            var addAndEditWindow = new AddAndEditWindow(viewModel);
            addAndEditWindow.ShowDialog();
        }
    }

    [RelayCommand]
    private async void DeleteEmployee()
    {
        if (SelectedEmployee != null)
        {
            var result = await DialogService.ShowTwoButtonMessageBoxAsync(
            $"Are you sure you want to delete {SelectedEmployee.FirstName} {SelectedEmployee.LastName}?",
            "Delete Employee",
            "Delete", "Cancel");
            if (result == CustomMessageBoxResult.Confirmed)
            {
                var success = await _employeeManagementService.EmployeeService.DeleteAsync(SelectedEmployee.Id);
                if (success)
                {
                    Employees.Remove(SelectedEmployee);
                    SelectedEmployee = null;
                }
                else
                {
                    await DialogService.ShowSingleButtonMessageBoxAsync("Failed to delete the employee.", "Error", "Ok");
                }
            }
            else
            {
                return;
            }
            await DialogService.ShowSingleButtonMessageBoxAsync(
                $"Employee {SelectedEmployee.FirstName} {SelectedEmployee.LastName} has been deleted successfully.",
                "Success",
                "OK");
        }
    }

    [RelayCommand]
    private void PrintEmployee()
    {
        if (SelectedEmployee != null)
        {
            var printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                var document = new FlowDocument();
                var paragraph = new Paragraph(new Run($"First name: {SelectedEmployee.FirstName}\nLast name: {SelectedEmployee.LastName}"));
                document.Blocks.Add(paragraph);

                var paginator = ((IDocumentPaginatorSource)document).DocumentPaginator;
                printDialog.PrintDocument(paginator, "Employee Details");
            }
        }
    }

    private async void GetAllEmployees()
    {
        Employees.Clear();
        var employees = await _employeeManagementService.EmployeeService.GetAsync();
        foreach (var employee in employees)
        {
            Employees.Add(employee);
        }

    }

    [RelayCommand]
    private void EmployeeAbsence()
    {
        if (SelectedEmployee != null)
        {
            var employeeAbsenceViewModel = new EmployeeAbsenceViewModel(SelectedEmployee, _employeeManagementService);
            var employeeAbsenceWindow = new AbsenceWindow(employeeAbsenceViewModel);
            employeeAbsenceWindow.ShowDialog();
        }
    }

    [RelayCommand]
    private async void GetAllAbsence()
    {
        Employees.Clear();
        var absences = await _employeeManagementService.AbsenceService.GetAsync();
        foreach (var employee in absences)
        {
            Employees.Add(employee.Employee);
        }

    }


}
