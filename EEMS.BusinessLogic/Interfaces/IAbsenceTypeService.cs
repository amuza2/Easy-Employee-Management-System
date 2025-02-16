using EEMS.DataAccess.Models;

namespace EEMS.BusinessLogic.Interfaces
{
    public interface IAbsenceTypeService
    {
        Task AddAbsenceTypeAsync(AbsenceType absenceType);
        Task DeleteAbsenceTypeAsync(int id);
        Task<AbsenceType> GetAbsenceByIdAsync(int id);
        Task<List<AbsenceType>> GetAbsenceTypesAsync();
        Task UpdateAbsenceTypeAsync(AbsenceType absenceType);
    }
}