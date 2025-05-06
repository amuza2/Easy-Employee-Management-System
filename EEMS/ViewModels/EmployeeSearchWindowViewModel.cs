using CommunityToolkit.Mvvm.ComponentModel;
using EEMS.BusinessLogic.Interfaces;
using EEMS.DataAccess.Models;
using EEMS.Utilities.Enums;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;

namespace EEMS.UI.ViewModels;

public partial class EmployeeSearchWindowViewModel : ObservableObject
{
    private IEmployeeManagementService _employeeManagementService;
    [ObservableProperty] private Employee? _selectedEmployee;
    [ObservableProperty] private string _searchEmployee;
    [ObservableProperty] private JobNatureEnum _selectedJobNatureItem;
    [ObservableProperty] private Department _selectedDepartment;
    [ObservableProperty] private ObservableCollection<Employee> _employees;
    public ICollectionView FilteredEmployees { get; }
    [ObservableProperty] private ObservableCollection<JobNatureEnum> _jobNatureItems;
    [ObservableProperty] private ObservableCollection<Department> _departments;

    public EmployeeSearchWindowViewModel(IEmployeeManagementService employeeManagementService)
    {
        _employeeManagementService = employeeManagementService;
        _employees = new ObservableCollection<Employee>();
        FilteredEmployees = CollectionViewSource.GetDefaultView(Employees);
        FilteredEmployees.Filter = FilterEmployee;
        _departments = new ObservableCollection<Department>();
        _jobNatureItems = new ObservableCollection<JobNatureEnum>();
        _ = LoadAllEmployeeToDataGrid();
        LoadJobNatureItemsToCombobox();
        _ = LoadDepartmentsToCombobox();
    }

    // handle search Employee controls
    private bool FilterEmployee(object obj)
    {
        if (obj is not Employee emp) return false;
        bool matchesSearch = string.IsNullOrEmpty(SearchEmployee) ||
            emp.FirstName.Contains(SearchEmployee, StringComparison.OrdinalIgnoreCase) ||
            emp.LastName.Contains(SearchEmployee, StringComparison.OrdinalIgnoreCase);

        bool matchesDepartment = SelectedDepartment == null || SelectedDepartment.Id == 0 ||
            emp.DepartmentId == SelectedDepartment.Id;

        bool matchesJobnature = SelectedJobNatureItem == JobNatureEnum.All ||
            emp.JobNatureItem == SelectedJobNatureItem;

        return matchesSearch && matchesDepartment && matchesJobnature;
    }

    partial void OnSelectedJobNatureItemChanged(JobNatureEnum value)
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

    private void LoadJobNatureItemsToCombobox()
    {
        foreach (var item in Enum.GetValues(typeof(JobNatureEnum)).Cast<JobNatureEnum>())
        {
            JobNatureItems.Add(item);
        }
    }

    private async Task LoadAllEmployeeToDataGrid()
    {
        var employees = await _employeeManagementService.EmployeeService.GetAsync();
        foreach (var employee in employees)
        {
            _employees.Add(employee);
        }
    }



}
