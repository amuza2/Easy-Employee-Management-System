using EEMS.DataAccess.Models;

namespace EEMS.BusinessLogic.Interfaces
{
    public interface IDepartmentService
    {
        Task<int> AddAsync(Department department);
        Task DeleteAsync(int id);
        Task<IEnumerable<Department>> GetAsync();
        Task<Department> GetAsync(int id);
        Task UpdateAsync(Department department);
    }
}