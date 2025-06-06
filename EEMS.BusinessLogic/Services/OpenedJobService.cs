﻿using EEMS.BusinessLogic.Interfaces;
using EEMS.DataAccess;
using EEMS.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace EEMS.BusinessLogic.Services;

public class OpenedJobService : IOpenedJobService
{
    private readonly IDbContextFactory<EEMSDbContext> _contextFactory;
    public OpenedJobService(IDbContextFactory<EEMSDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task<int> AddAsync(OpenedJob opendJob)
    {
        await using var context = _contextFactory.CreateDbContext();
        var added = context.Openedjobs.Add(opendJob);
        await context.SaveChangesAsync();

        return added.Entity.Id;
    }

    public async Task DeleteAsync(int id)
    {
        await using var context = _contextFactory.CreateDbContext();
        var openedJob = await GetAsync(id);
        if (openedJob != null)
        {
            context.Openedjobs.Remove(openedJob);
            await context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<OpenedJob>> GetAsync()
    {
        await using var context = _contextFactory.CreateDbContext();
        return await context.Openedjobs.ToListAsync();
    }

    public async Task<OpenedJob> GetAsync(int id)
    {
        await using var context = _contextFactory.CreateDbContext();
        return await context.Openedjobs.FindAsync(id);
    }

    public async Task UpdateAsync(OpenedJob opendJob)
    {
        await using var context = _contextFactory.CreateDbContext();
        context.Openedjobs.Update(opendJob);
        await context.SaveChangesAsync();
    }
}
