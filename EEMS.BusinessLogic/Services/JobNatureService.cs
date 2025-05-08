using EEMS.BusinessLogic.Interfaces;
using EEMS.DataAccess;
using EEMS.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace EEMS.BusinessLogic.Services;

public class JobNatureService : IJobNatureService
{
    private readonly IDbContextFactory<EEMSDbContext> _contextFactory;

    public JobNatureService(IDbContextFactory<EEMSDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task<IEnumerable<JobNature>> GetAsync()
    {
        await using var context = _contextFactory.CreateDbContext();
        return await context.JobNatures.ToListAsync();
    }

    public async Task<JobNature> GetAsync(int id)
    {
        await using var context = _contextFactory.CreateDbContext();
        return await context.JobNatures.FindAsync(id);
    }

    public async Task<int> GetJobNatureIdByNameAsync(string name)
    {
        await using var context = _contextFactory.CreateDbContext();
        if (string.IsNullOrEmpty(name))
            throw new ArgumentException("Name cannot be null or empty.", nameof(name));

        var jobNatureId = await context.JobNatures
                                .Where(j => j.Name == name)
                                .Select(i => i.Id)
                                .FirstOrDefaultAsync();
        
        if (jobNatureId == 0)
            throw new Exception($"Job Nature with name '{name}' not found");

        return jobNatureId;
    }

    public async Task<int> AddAsync(JobNature jobNature)
    {
        await using var context = _contextFactory.CreateDbContext();
        var added = context.JobNatures.Add(jobNature);
        await context.SaveChangesAsync();

        return added.Entity.Id;
    }

    public async Task UpdateAsync(JobNature jobNature)
    {
        await using var context = _contextFactory.CreateDbContext();
        context.JobNatures.Update(jobNature);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await using var context = _contextFactory.CreateDbContext();
        var jonNature = await GetAsync(id);
        if (jonNature != null)
        {
            context.JobNatures.Remove(jonNature);
            await context.SaveChangesAsync();
        }
    }
}
