using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EEMS.BusinessLogic.DTOs;
using EEMS.BusinessLogic.Interfaces;
using EEMS.BusinessLogic.Services;
using EEMS.UI.MVVM;
using EEMS.UI.ViewModels;
using EEMS.UI.Views.Shared;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace EEMS.UI.Views.Employees;

public partial class EmployeeViewModel : ObservableObject
{
    private readonly IEmployeeManagementService _employeeManagementService;
    public ObservableCollection<DataAccess.Models.Employee> Employees { get; set; }

    //[NotifyCanExecuteChangedFor(nameof(ViewEmployeeCommand))]
    [ObservableProperty]
    private DataAccess.Models.Employee _selectedEmployee;

    [ObservableProperty]
    private bool _isEditing;
    
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
        LoadEmployees();
    }

    [RelayCommand]
    private void GetAllEmployee()
    {
        LoadEmployees();
    }

    [RelayCommand]
    private void AddEmployee()
    {
        var viewModel = new AddAndEditWindowViewModel(new PersonalInformationViewModel(),
                                                      new JobInformationViewModel(_employeeManagementService),
                                                      _employeeManagementService);

        viewModel.UpdateGridWindowData = LoadEmployees;

        var AddAndEditWindow = new AddAndEditWindow(viewModel);
        AddAndEditWindow.ShowDialog();
    }

    [RelayCommand]
    private async void DeleteEmployee()
    {
        if (SelectedEmployee != null)
        {
            var result = MessageBox.Show($"Are you sure you want to delete {SelectedEmployee.FirstName} {SelectedEmployee.LastName}?", "Delete Employee", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                var success = await _employeeManagementService.DeleteEmployeeByIdAsync(SelectedEmployee.Id);
                if(success)
                {
                    Employees.Remove(SelectedEmployee);
                    SelectedEmployee = null;
                }
                else
                {
                    MessageBox.Show("Failed to delete the employee.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
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

    private async void LoadEmployees()
    {
        Employees.Clear();
        var employees = await _employeeManagementService.GetAsync();
        foreach (var employee in employees)
        {
            Employees.Add(employee);
        }

    }

    
}
