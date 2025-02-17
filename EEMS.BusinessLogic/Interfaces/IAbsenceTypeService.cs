using EEMS.DataAccess.Models;

namespace EEMS.BusinessLogic.Interfaces
{
    public interface IAbsenceTypeService
    {
        Task<int> AddAsync(AbsenceType absenceType);
        Task DeleteAsync(int id);
        Task<AbsenceType> GetAsync(int id);
        Task<IEnumerable<AbsenceType>> GetAsync();
        Task UpdateAsync(AbsenceType absenceType);
    }
}