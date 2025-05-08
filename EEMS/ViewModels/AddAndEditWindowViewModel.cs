using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EEMS.BusinessLogic.Interfaces;
using EEMS.DataAccess.Models;
using EEMS.UI.Views.Shared;
using EEMS.UI.Views.Shared.MessageBoxes;
using EEMS.Utilities.Enums;
using System.Collections.ObjectModel;
using System.Windows;

namespace EEMS.UI.ViewModels;

public partial class AddAndEditWindowViewModel : ObservableValidator
{
	private readonly IEmployeeManagementService _employeeManagementService;
    [ObservableProperty] private Employee? _employee;
    [ObservableProperty] private string _buttonName = "Save";
    private bool _isEditMode = false;

    public ObservableCollection<Department> DepartmentItems { get; } = new();
    public ObservableCollection<JobNatureEnum> JobNatureItems { get; } = new();
    public ObservableCollection<FamilySituation> FamilySituationItems { get; } = new();
    public Window? Window { get; set; }
    public Action UpdateEmployeeDataGrid { get; set; }

    public AddAndEditWindowViewModel( IEmployeeManagementService employeeManagementService, Employee? employee = null)
	{
        _isEditMode = false;
        _employee = new Employee();
        ButtonName = "Save";    
        _employeeManagementService = employeeManagementService;
        Employee.DateOfBirth = DateTime.Today;
        Employee.RecruitmentDate = DateTime.Today;
        LoadFamilySituation();
        _ = LoadDepartmentsAsync();
        LoadJobNature();
        if(employee != null)
        {
            _isEditMode = true;
            ButtonName = "Update";
            LoadEmployeeDetail(employee);
        }
    }

    private void LoadEmployeeDetail(Employee employee)
    {
        Employee = employee;
    }

    private void LoadFamilySituation()
    {
        foreach (var item in Enum.GetValues(typeof(FamilySituation)).Cast<FamilySituation>())
        {
            FamilySituationItems.Add(item);
        }
    }

    private void LoadJobNature()
    {
        foreach (var item in Enum.GetValues(typeof(JobNatureEnum)).Cast<JobNatureEnum>())
        {
            JobNatureItems.Add(item);
        }
    }

    private async Task<IEnumerable<Department>> LoadDepartmentsAsync()
    {
        var departments = await _employeeManagementService.DepartmentService.GetAsync();

        foreach (var department in departments)
        {
            DepartmentItems.Add(department);
        }
        return departments;
    }


    [RelayCommand]
    private async Task SaveEmployee()
    {
        if (HasErrors) return;
        ValidateAllProperties();

        if (_isEditMode)
        {
            await UpdateEmployee();
        }
        else
        {
            await AddEmployee();
        }
        UpdateEmployeeDataGrid?.Invoke();
        Window?.Close();
    }

    private async Task UpdateEmployee()
    {
        await _employeeManagementService.EmployeeService.UpdateAsync(Employee);

        await DialogService.ShowSingleButtonMessageBoxAsync(
            $"Employee Updated Successfully.",
            "Success",
            "OK");
    }

    private async Task AddEmployee()
    {
        var employeeId = await _employeeManagementService.EmployeeService.AddAsync(Employee);
        if (employeeId < 1)
        {
            await DialogService.ShowSingleButtonMessageBoxAsync(
                "Error adding employee. Please try again.",
                "Error",
                "OK");
            return;
        }
        await DialogService.ShowSingleButtonMessageBoxAsync(
            $"Employee added successfully.",
            "Success",
            "OK");
        
    }
}
