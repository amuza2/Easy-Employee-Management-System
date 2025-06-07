using EEMS.Models.Models;

namespace EEMS.BusinessLogic.Interfaces
{
    public interface IDepartmentService
    {
        Task<int> AddAsync(Department department);
        Task DeleteAsync(int id);
        Task<IEnumerable<Department>> GetAsync();
        Task<Department> GetAsync(int id);
        Task<int> GetDepartmentIdByNameAsync(string name);
        Task UpdateAsync(Department department);
    }
}