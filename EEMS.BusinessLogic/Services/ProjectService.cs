using EEMS.BusinessLogic.Interfaces;
using EEMS.DataAccess;
using EEMS.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace EEMS.BusinessLogic.Services
{
    public class ProjectService : IProjectService
    {
        private readonly EEMSDbContext _context;

        public ProjectService(EEMSDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Project>> GetAsync()
        {
            return await _context.Projects.ToListAsync();
        }

        public async Task<Project> GetAsync(int id)
        {
            return await _context.Projects.FindAsync(id);
        }

        public async Task<int> AddAsync(Project project)
        {
            var added = _context.Projects.Add(project);
            await _context.SaveChangesAsync();

            return added.Entity.Id;
        }

        public async Task UpdateAsync(Project project)
        {
            _context.Projects.Update(project);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var project = await GetAsync(id);
            if (project != null)
            {
                _context.Projects.Remove(project);
                await _context.SaveChangesAsync();
            }
        }
    }
}
