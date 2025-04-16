using EEMS.DataAccess.Models;

namespace EEMS.BusinessLogic.Interfaces;

public interface IEmployeeManagementService
{
    Task<int> GetDepartmentIdByName(string deparmtentName);
    Task<Department> GetAsync(int id);
    Task<int> GetJobNatureByName(string jobNatureName);
    Task<IEnumerable<Department>> GetDepartmentsAsync();
    Task<IEnumerable<JobNature>> GetJobNaturesAsync();
    Task<int> AddEmployeeAsync(Employee employee);
    Task<IEnumerable<Employee>> GetAsync();
}