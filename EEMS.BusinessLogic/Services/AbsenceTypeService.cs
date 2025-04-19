//using EEMS.BusinessLogic.Interfaces;
//using EEMS.DataAccess;
//using EEMS.DataAccess.Models;
//using Microsoft.EntityFrameworkCore;

//namespace EEMS.BusinessLogic.Services
//{
//    public class AbsenceTypeService : IAbsenceTypeService
//    {
//        private readonly EEMSDbContext _context;

//        public AbsenceTypeService(EEMSDbContext context)
//        {
//            _context = context;
//        }
//        public async Task<IEnumerable<AbsenceType>> GetAsync()
//        {
//            return await _context.AbsenceTypes.AsNoTracking().ToListAsync();
//        }
//        public async Task<AbsenceType> GetAsync(int id)
//        {
//            return await _context.AbsenceTypes.FindAsync(id);
//        }
//        public async Task<int> AddAsync(AbsenceType absenceType)
//        {
//            var added = _context.AbsenceTypes.Add(absenceType);
//            await _context.SaveChangesAsync();

//            return added.Entity.Id;
//        }
//        public async Task UpdateAsync(AbsenceType absenceType)
//        {
//            _context.AbsenceTypes.Update(absenceType);
//            await _context.SaveChangesAsync();
//        }
//        public async Task DeleteAsync(int id)
//        {
//            var absenceType = await GetAsync(id);
//            if (absenceType != null)
//            {
//                _context.Remove(absenceType);
//                await _context.SaveChangesAsync();
//            }
//        }
//    }
//}
