using EEMS.DataAccess.Models;

namespace EEMS.BusinessLogic.Interfaces
{
    public interface IEmployeeService
    {
        Task AddEmployeeAsync(Employee employee);
        Task DeleteEmployeeAsync(int id);
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task<List<Employee>> GetEmployeesAsync();
        Task UpdateEmployeeAsync(Employee employee);
    }
}