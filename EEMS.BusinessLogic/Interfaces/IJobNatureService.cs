using EEMS.DataAccess.Models;

namespace EEMS.BusinessLogic.Interfaces
{
    public interface IJobNatureService
    {
        Task<int> AddAsync(JobNature jobNature);
        Task DeleteAsync(int id);
        Task<IEnumerable<JobNature>> GetAsync();
        Task<JobNature> GetAsync(int id);
        Task<int> GetJobNatureIdByNameAsync(string name);
        Task UpdateAsync(JobNature jobNature);
    }
}