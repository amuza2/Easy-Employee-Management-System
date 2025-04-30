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

namespace EEMS.UI.Views.Employees;

public partial class EmployeeViewModel : ObservableObject
{
    private readonly IEmployeeManagementService _employeeManagementService;
    private IDocumentBuilderFactory _factory;
    private readonly PrintService _printService;

    public ObservableCollection<Employee> Employees { get; set; }
    public ObservableCollection<Department> Departments { get; set; }
    public ObservableCollection<JobNatureEnum> JobNatureItems { get; set; }

    [ObservableProperty] private Employee _selectedEmployee;
    [ObservableProperty] private string _selectedTab = "All";
    //[ObservableProperty] private bool _isEditing;
    [ObservableProperty] private Department _selectedDepartment;
    [ObservableProperty] private string _searchEmployee;
    [ObservableProperty] private JobNatureEnum _selectedJobNature;

    private List<Employee> _filteredEmployees = new List<Employee>();

    //public bool IsNotEditing => !IsEditing;

    [RelayCommand]
    private void SelectTab(string tabName)
    {
        //Debug.WriteLine($"Selected tab: {tabName}");
        SelectedTab = tabName;
    }

    private bool CanPerformUserAction(object obj)
    {
        return SelectedEmployee != null;
    }

    //partial void OnIsEditingChanged(bool value)
    //{
    //    OnPropertyChanged(nameof(IsNotEditing));
    //    ViewEmployeeCommand.NotifyCanExecuteChanged();
    //}

    // Part of Edit Employee
    partial void OnSelectedEmployeeChanged(Employee value)
    {
        ViewEmployeeCommand.NotifyCanExecuteChanged();
    }

    // Search Employee textbox
    partial void OnSearchEmployeeChanged(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            GetEmployeesByDepartmentId(SelectedDepartment.Id);
        }
        else
        {
            _filteredEmployees = Employees
                .Where(e => e.FirstName.Contains(value, StringComparison.OrdinalIgnoreCase) ||
                            e.LastName.Contains(value, StringComparison.OrdinalIgnoreCase))
                .ToList();

            Employees.Clear();

            foreach (var emp in _filteredEmployees)
            {
                Employees.Add(emp);
            }
        }
    }

    public EmployeeViewModel(IEmployeeManagementService employeeManagementService, IDocumentBuilderFactory documentBuilderFactory, PrintService printService)
    {
        _factory = documentBuilderFactory;
        _printService = printService;
        _employeeManagementService = employeeManagementService;
        Employees = new ObservableCollection<Employee>();
        Departments = new ObservableCollection<Department>();
        JobNatureItems = new ObservableCollection<JobNatureEnum>();
        _ = LoadDepartmentsToCombobox();
        LoadJobNatureItems();
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

    partial void OnSelectedDepartmentChanged(Department value)
    {
        if(value == null) return;

        if (value.Id == 0)
        {
            _ = GetAllEmployees();
        }
        else
        {
            GetEmployeesByDepartmentId(value.Id);
        }
    }

    private async void GetEmployeesByDepartmentId(int departmentId)
    {
        Employees.Clear();
        if(departmentId == 0)
        {
            _= GetAllEmployees();
        }
        else
        {
            var employees = await _employeeManagementService.EmployeeService.GetEmployeesByDepartmentId(departmentId);
            foreach (var employee in employees)
            {
                Employees.Add(employee);
            }
        }
    }

    partial void OnSelectedTabChanged(string value)
    {
        LoadDataForTab(value);
    }

    private void LoadDataForTab(string tab)
    {
        if (tab == "All")
        {
           _ = GetAllEmployees();
        }
        //else if (tab == "Absence")
        //{
        //   GetAllAbsence();
        //}
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

    [RelayCommand]
    private void PrintEmployee()
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

    [RelayCommand]
    private void EmployeeAbsence()
    {
        if (SelectedEmployee != null)
        {
            var employeeAbsenceViewModel = new AbsenceWindowViewModel(SelectedEmployee, _employeeManagementService);
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
