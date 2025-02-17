using EEMS.DataAccess.Models;

namespace EEMS.BusinessLogic.Interfaces
{
    public interface IAbsenceService
    {
        Task<int> AddAsync(Absence absence);
        Task DeleteAsync(int id);
        Task<IEnumerable<Absence>> GetAsync();
        Task<Absence> GetAsync(int id);
        Task UpdateAsync(Absence absence);
    }
}