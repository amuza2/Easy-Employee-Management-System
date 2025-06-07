using EEMS.Models.Models;
namespace EEMS.BusinessLogic.Interfaces;

public interface IEmployeeService
{
    Task<IEnumerable<Employee>> GetAsync();
    Task<Employee> GetAsync(int id);
    Task<Employee> GetFirstEmployeeAsync();
    Task<int> AddAsync(Employee employee);
    Task<bool> DeleteAsync(int id);
    Task UpdateAsync(Employee employee);

    Task<IEnumerable<Employee>> GetEmployeesByDepartmentId(int departmentId);
}