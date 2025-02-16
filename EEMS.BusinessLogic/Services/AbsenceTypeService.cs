using EEMS.BusinessLogic.Interfaces;
using EEMS.DataAccess;
using EEMS.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace EEMS.BusinessLogic.Services
{
    public class AbsenceTypeService : IAbsenceTypeService
    {
        private readonly EEMSDbContext _context;

        public AbsenceTypeService(EEMSDbContext context)
        {
            _context = context;
        }
        public async Task<List<AbsenceType>> GetAbsenceTypesAsync()
        {
            return await _context.AbsenceTypes.AsNoTracking().ToListAsync();
        }
        public async Task<AbsenceType> GetAbsenceByIdAsync(int id)
        {
            return await _context.AbsenceTypes.FindAsync(id);
        }
        public async Task AddAbsenceTypeAsync(AbsenceType absenceType)
        {
            _context.AbsenceTypes.Add(absenceType);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAbsenceTypeAsync(AbsenceType absenceType)
        {
            _context.AbsenceTypes.Update(absenceType);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAbsenceTypeAsync(int id)
        {
            var absenceType = await GetAbsenceByIdAsync(id);
            if (absenceType != null)
            {
                _context.Remove(absenceType);
                await _context.SaveChangesAsync();
            }
        }
    }
}
