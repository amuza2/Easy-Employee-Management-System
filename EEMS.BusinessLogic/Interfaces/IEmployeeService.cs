using EEMS.DataAccess.Models;

namespace EEMS.BusinessLogic.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAsync();
        Task<Employee> GetAsync(int id);
        Task<int> AddAsync(Employee employee);
        Task DeleteAsync(int id);
        Task UpdateAsync(Employee employee);
    }
}