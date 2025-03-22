using EEMS.BusinessLogic.Interfaces;
using EEMS.DataAccess;
using EEMS.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace EEMS.BusinessLogic.Services;

public class JobNatureService : IJobNatureService
{
    private readonly EEMSDbContext _context;

    public JobNatureService(EEMSDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<JobNature>> GetAsync()
    {
        return await _context.JobNatures.ToListAsync();
    }

    public async Task<JobNature> GetAsync(int id)
    {
        return await _context.JobNatures.FindAsync(id);
    }

    public async Task<int> GetJobNatureIdByNameAsync(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentException("Name cannot be null or empty.", nameof(name));

        var jobNatureId = await _context.JobNatures
                                .Where(j => j.Name == name)
                                .Select(i => i.Id)
                                .FirstOrDefaultAsync();
        
        if (jobNatureId == 0)
            throw new Exception($"Job Nature with name '{name}' not found");

        return jobNatureId;
    }

    public async Task<int> AddAsync(JobNature jobNature)
    {
        var added = _context.JobNatures.Add(jobNature);
        await _context.SaveChangesAsync();

        return added.Entity.Id;
    }

    public async Task UpdateAsync(JobNature jobNature)
    {
        _context.JobNatures.Update(jobNature);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var jonNature = await GetAsync(id);
        if (jonNature != null)
        {
            _context.JobNatures.Remove(jonNature);
            await _context.SaveChangesAsync();
        }
    }
}
