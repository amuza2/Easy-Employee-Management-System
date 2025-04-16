using EEMS.BusinessLogic.Interfaces;
using EEMS.DataAccess.Models;

namespace EEMS.BusinessLogic.Services;

public class EmployeeManagementService : IEmployeeManagementService
{
    private readonly IDepartmentService _departmentService;
    private readonly IJobNatureService _jobNatureService;
    private readonly IEmployeeService _employeeService;

    public EmployeeManagementService(IDepartmentService departmentService,
                                     IJobNatureService jobNatureService,
                                     IEmployeeService employeeService)
    {
        _departmentService = departmentService;
        _jobNatureService = jobNatureService;
        _employeeService = employeeService;
    }

    public async Task<int> GetDepartmentIdByName(string deparmtentName)
    {
        return await _departmentService.GetDepartmentIdByNameAsync(deparmtentName);
    }
    public Task<Department> GetAsync(int id)
    {
        return _departmentService.GetAsync(id);
    }

    public async Task<int> GetJobNatureByName(string jobNatureName)
    {
        return await _jobNatureService.GetJobNatureIdByNameAsync(jobNatureName);
    }

    public async Task<IEnumerable<Department>> GetDepartmentsAsync()
    {
        return await _departmentService.GetAsync();
    }

    public async Task<IEnumerable<JobNature>> GetJobNaturesAsync()
    {
        return await _jobNatureService.GetAsync();
    }

    public async Task<int> AddEmployeeAsync(Employee employee)
    {
        return await _employeeService.AddAsync(employee);
    }

    public async Task<IEnumerable<Employee>> GetAsync()
    {
        return await _employeeService.GetAsync();
    }
}
