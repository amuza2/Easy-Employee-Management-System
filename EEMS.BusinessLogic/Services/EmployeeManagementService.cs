using EEMS.BusinessLogic.Interfaces;
using EEMS.DataAccess.Models;

namespace EEMS.BusinessLogic.Services;

public class EmployeeManagementService : IEmployeeManagementService
{
    public IDepartmentService DepartmentService { get; }
    public IJobNatureService JobNatureService { get; }
    public IEmployeeService EmployeeService { get; }
    public IAbsenceService AbsenceService { get; }

    public EmployeeManagementService(IDepartmentService departmentService,
                                     IJobNatureService jobNatureService,
                                     IEmployeeService employeeService,
                                     IAbsenceService absenceService)
    {
        DepartmentService = departmentService;
        JobNatureService = jobNatureService;
        EmployeeService = employeeService;
        AbsenceService = absenceService;
    }

    //public async Task<int> GetDepartmentIdByName(string deparmtentName)
    //{
    //    return await _departmentService.GetDepartmentIdByNameAsync(deparmtentName);
    //}
    //public Task<Department> GetAsync(int id)
    //{
    //    return _departmentService.GetAsync(id);
    //}

    //public async Task<int> GetJobNatureByName(string jobNatureName)
    //{
    //    return await _jobNatureService.GetJobNatureIdByNameAsync(jobNatureName);
    //}

    //public async Task<IEnumerable<Department>> GetDepartmentsAsync()
    //{
    //    return await _departmentService.GetAsync();
    //}

    //public async Task<IEnumerable<JobNature>> GetJobNaturesAsync()
    //{
    //    return await _jobNatureService.GetAsync();
    //}

    //public async Task<int> AddEmployeeAsync(Employee employee)
    //{
    //    return await _employeeService.AddAsync(employee);
    //}

    //public async Task<IEnumerable<Employee>> GetAsync()
    //{
    //    return await _employeeService.GetAsync();
    //}

    //public async Task<bool> DeleteEmployeeByIdAsync(int id)
    //{
    //    return await _employeeService.DeleteAsync(id);
    //}
}
