using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EEMS.BusinessLogic.Interfaces;
using EEMS.DataAccess.Models;
using EEMS.UI.Enums;
using EEMS.UI.ViewModels;
using EEMS.UI.Views.Absences;
using EEMS.UI.Views.Shared;
using EEMS.UI.Views.Shared.DocumentPrinting;
using EEMS.UI.Views.Shared.MessageBoxes;
using EEMS.Utilities.Enums;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;

namespace EEMS.UI.Views.Employees;

public partial class EmployeeViewModel : ObservableObject
{
    private readonly IEmployeeManagementService _employeeManagementService;
    private IDocumentBuilderFactory _factory;
    private readonly PrintService _printService;

    public ObservableCollection<Employee> Employees { get; set; }
    public ICollectionView FilteredEmployees { get; }
    public ObservableCollection<Department> Departments { get; set; }
    public ObservableCollection<JobNatureEnum> JobNatureItems { get; set; }

    [ObservableProperty] private Employee? _selectedEmployee;
    [ObservableProperty] private Department _selectedDepartment;
    [ObservableProperty] private string _searchEmployee;
    [ObservableProperty] private JobNatureEnum _selectedJobNature;

    

    private bool CanPerformUserAction(object obj)
    {
        return SelectedEmployee != null;
    }

    //  raise the CanExecuteChanged event manually when SelectedEmployee changes, so the UI can re-evaluate which buttons should be enabled.
    partial void OnSelectedEmployeeChanged(Employee? value)
    {
        ViewEmployeeCommand.NotifyCanExecuteChanged();
        EditEmployeeCommand.NotifyCanExecuteChanged();
        DeleteEmployeeCommand.NotifyCanExecuteChanged();
        PrintEmployeeCommand.NotifyCanExecuteChanged();
        EmployeeAbsenceCommand.NotifyCanExecuteChanged();
    }

    public EmployeeViewModel(IEmployeeManagementService employeeManagementService, IDocumentBuilderFactory documentBuilderFactory, PrintService printService)
    {
        _factory = documentBuilderFactory;
        _printService = printService;
        _employeeManagementService = employeeManagementService;
        Employees = new ObservableCollection<Employee>();
        FilteredEmployees = CollectionViewSource.GetDefaultView(Employees);
        FilteredEmployees.Filter = FilterEmployee;
        Departments = new ObservableCollection<Department>();
        JobNatureItems = new ObservableCollection<JobNatureEnum>();
        _ = LoadDepartmentsToCombobox();
        LoadJobNatureItems();
        _ = GetAllEmployees();
    }
    // handle search Employee controls
    private bool FilterEmployee(object obj)
    {
        if(obj is not Employee emp) return false;
        bool matchesSearch = string.IsNullOrEmpty(SearchEmployee) ||
            emp.FirstName.Contains(SearchEmployee, StringComparison.OrdinalIgnoreCase) ||
            emp.LastName.Contains(SearchEmployee, StringComparison.OrdinalIgnoreCase);

        bool matchesDepartment = SelectedDepartment == null || SelectedDepartment.Id == 0 ||
            emp.DepartmentId == SelectedDepartment.Id;

        bool matchesJobnature = SelectedJobNature == JobNatureEnum.All ||
            emp.JobNatureItem == SelectedJobNature;

        return matchesSearch && matchesDepartment && matchesJobnature;
    }

    partial void OnSelectedJobNatureChanged(JobNatureEnum value)
    {
        FilteredEmployees.Refresh();
    }
    partial void OnSelectedDepartmentChanged(Department value)
    {
        FilteredEmployees.Refresh();
    }
    partial void OnSearchEmployeeChanged(string value)
    {
        FilteredEmployees.Refresh();
    }

    private async Task LoadDepartmentsToCombobox()
    {
        Departments.Clear();
        Department allDepartment = new Department { Id = 0, Name = "All" };
        Departments.Add(allDepartment);
        var departments = await _employeeManagementService.DepartmentService.GetAsync();

        if (departments != null)
        {
            foreach (var department in departments)
            {
                Departments.Add(department);
            }
        }

        SelectedDepartment = allDepartment;
    }

    private void LoadJobNatureItems()
    {
        foreach (var item in Enum.GetValues(typeof(JobNatureEnum)).Cast<JobNatureEnum>())
        {
            JobNatureItems.Add(item);
        }
    }

    [RelayCommand]
    private void AddEmployee()
    {
        var viewModel = new AddAndEditWindowViewModel(_employeeManagementService);
        
        // update data grid when employee is added or updated
        viewModel.UpdateEmployeeDataGrid = async () => { await GetAllEmployees(); };
        
        var AddAndEditWindow = new AddAndEditWindow(viewModel);
        AddAndEditWindow.ShowDialog();
    }

    [RelayCommand(CanExecute = nameof(CanPerformUserAction))]
    private void ViewEmployee(object obj)
    {
        if (SelectedEmployee != null)
        {
            var employeeDetails = new ViewEmployeeDetailsViewModel(SelectedEmployee);
            var viewEmployeeDetailsWindow = new ViewEmployeeDetails(employeeDetails);
            viewEmployeeDetailsWindow.ShowDialog();
            SelectedEmployee = null;
        }
    }

    [RelayCommand(CanExecute = nameof(CanPerformUserAction))]
    private void EditEmployee(object obj)
    {
        if (SelectedEmployee != null)
        {
            //viewModel.UpdateGridWindowData = LoadEmployees;
            var viewModel = new AddAndEditWindowViewModel(_employeeManagementService, SelectedEmployee);
            var addAndEditWindow = new AddAndEditWindow(viewModel);
            addAndEditWindow.ShowDialog();
            SelectedEmployee = null;
        }
    }

    [RelayCommand(CanExecute = nameof(CanPerformUserAction))]
    private async void DeleteEmployee(object obj)
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
                $"Employee {SelectedEmployee?.FirstName} {SelectedEmployee?.LastName} has been deleted successfully.",
                "Success",
                "OK");
        }
    }

    [RelayCommand(CanExecute = nameof(CanPerformUserAction))]
    private void PrintEmployee(object obj)
    {
        var builder = _factory.Create(DocumentType.WorkCertificate, SelectedEmployee);
        //_printService.Print(builder);
        _printService.PreviewDocument(builder);
    }

    private async Task GetAllEmployees()
    {
        Employees.Clear();
        var employees = await _employeeManagementService.EmployeeService.GetAsync();
        foreach (var employee in employees)
        {
            Employees.Add(employee);
        }
    }

    [RelayCommand(CanExecute = nameof(CanPerformUserAction))]
    private void EmployeeAbsence(object obj)
    {
        if (SelectedEmployee != null)
        {
            var employeeAbsenceViewModel = new AbsenceWindowViewModel(SelectedEmployee, _employeeManagementService);
            var employeeAbsenceWindow = new AbsenceWindow(employeeAbsenceViewModel);
            employeeAbsenceWindow.ShowDialog();
        }
    }
}