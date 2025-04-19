//using EEMS.BusinessLogic.Interfaces;
//using EEMS.DataAccess;
//using EEMS.DataAccess.Models;
//using Microsoft.EntityFrameworkCore;

//namespace EEMS.BusinessLogic.Services
//{
//    public class DrivingLicenseTypeService : IDrivingLicenseTypeService
//    {
//        private readonly EEMSDbContext _context;

//        public DrivingLicenseTypeService(EEMSDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<IEnumerable<DrivingLicenseType>> GetAsync()
//        {
//            return await _context.DrivingLicenseTypes.ToListAsync();
//        }

//        public async Task<DrivingLicenseType> GetAsync(int id)
//        {
//            return await _context.DrivingLicenseTypes.FindAsync(id);
//        }

//        public async Task<int> AddAsync(DrivingLicenseType drivingLicenseType)
//        {
//            var added = _context.DrivingLicenseTypes.Add(drivingLicenseType);
//            await _context.SaveChangesAsync();

//            return added.Entity.Id;
//        }

//        public async Task UpdateAsync(DrivingLicenseType drivingLicenseType)
//        {
//            _context.DrivingLicenseTypes.Update(drivingLicenseType);
//            await _context.SaveChangesAsync();
//        }

//        public async Task DeleteAsync(int id)
//        {
//            var dlt = await GetAsync(id);
//            if (dlt != null)
//            {
//                _context.DrivingLicenseTypes.Remove(dlt);
//                await _context.SaveChangesAsync();
//            }
//        }
//    }
//}
