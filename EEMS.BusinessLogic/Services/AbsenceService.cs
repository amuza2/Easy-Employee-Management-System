using EEMS.BusinessLogic.Interfaces;
using EEMS.DataAccess;
using EEMS.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace EEMS.BusinessLogic.Services
{
    public class AbsenceService : IAbsenceService
    {
        private readonly EEMSDbContext _context;

        public AbsenceService(EEMSDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Absence>> GetAsync()
        {
            return await _context.Absences.ToListAsync();
        }

        public async Task<Absence> GetAsync(int id)
        {
            return await _context.Absences.FindAsync(id);
        }

        public async Task<int> AddAsync(Absence absence)
        {
            var added = _context.Absences.Add(absence);
            await _context.SaveChangesAsync();

            return added.Entity.Id;
        }

        public async Task UpdateAsync(Absence absence)
        {
            _context.Absences.Update(absence);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var abs = await GetAsync(id);
            if (abs != null)
            {
                _context.Absences.Remove(abs);
                await _context.SaveChangesAsync();
            }
        }
    }
}
