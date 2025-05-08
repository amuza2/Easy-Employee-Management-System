using EEMS.BusinessLogic.Interfaces;
using EEMS.DataAccess;
using EEMS.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace EEMS.BusinessLogic.Services;

public class AbsenceService : IAbsenceService
{
    private readonly IDbContextFactory<EEMSDbContext> _contextFactory;

    public AbsenceService(IDbContextFactory<EEMSDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task<IEnumerable<Absence>> GetAsync()
    {
        await using var context = _contextFactory.CreateDbContext();
        return await context.Absences
            .Include(a => a.Employee)
            .ToListAsync();
    }

    public async Task<IEnumerable<Absence>> GetAbsencesByDate(DateTime date)
    {
        await using var context = _contextFactory.CreateDbContext();
        return await context.Absences
            .Include(e => e.Employee)
            .Where(a => a.Date == date)
            .ToListAsync();
    }

    public async Task<Absence> GetAsync(int id)
    {
        await using var context = _contextFactory.CreateDbContext();
        return await context.Absences
            .Include(e => e.Employee)
            .FirstAsync(a => a.Id == id);
    }

    public async Task<int> AddAsync(Absence absence)
    {
        await using var context = _contextFactory.CreateDbContext();
        var added = context.Absences.Add(absence);
        await context.SaveChangesAsync();

        return added.Entity.Id;
    }

    public async Task UpdateAsync(Absence absence)
    {
        await using var context = _contextFactory.CreateDbContext();
        context.Absences.Update(absence);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await using var context = _contextFactory.CreateDbContext();
        var abs = await GetAsync(id);
        if (abs != null)
        {
            context.Absences.Remove(abs);
            await context.SaveChangesAsync();
        }
    }
}
