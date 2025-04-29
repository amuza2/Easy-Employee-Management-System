using EEMS.BusinessLogic.Interfaces;
using EEMS.DataAccess;
using EEMS.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace EEMS.BusinessLogic.Services;

public class CondidateService : ICondidateService
{
    private readonly IDbContextFactory<EEMSDbContext> _contextFactory;
    public CondidateService(IDbContextFactory<EEMSDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }
    public async Task<int> AddAsync(Condidate condidate)
    {
        await using var context = _contextFactory.CreateDbContext();
        var added = context.Condidates.Add(condidate);
        await context.SaveChangesAsync();

        return added.Entity.Id;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        await using var context = _contextFactory.CreateDbContext();
        var condidate = await GetAsync(id);
        if (condidate != null)
        {
            context.Condidates.Remove(condidate);
            await context.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public async Task<IEnumerable<Condidate>> GetAsync()
    {
        await using var context = _contextFactory.CreateDbContext();
        return await context.Condidates
            .Include(c => c.OpenedJob)
            .ToListAsync();
    }

    public async Task<Condidate> GetAsync(int id)
    {
        await using var context = _contextFactory.CreateDbContext();
        return await context.Condidates
            .Include(c => c.OpenedJob)
            .FirstAsync(e => e.Id == id);
    }

    public async Task UpdateAsync(Condidate condidate)
    {
        await using var context = _contextFactory.CreateDbContext();
        context.Condidates.Update(condidate);
        await context.SaveChangesAsync();
    }
}