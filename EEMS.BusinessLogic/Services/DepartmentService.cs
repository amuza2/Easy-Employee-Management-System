using EEMS.BusinessLogic.Interfaces;
using EEMS.DataAccess;
using EEMS.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace EEMS.BusinessLogic.Services;

public class DepartmentService : IDepartmentService
{
    private readonly IDbContextFactory<EEMSDbContext> _contextFactory;

    public DepartmentService(IDbContextFactory<EEMSDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task<IEnumerable<Department>> GetAsync()
    {
        await using var context = _contextFactory.CreateDbContext();
        return await context.Departments.ToListAsync();
    }

    public async Task<Department> GetAsync(int id)
    {
        await using var context = _contextFactory.CreateDbContext();
        return await context.Departments.FindAsync(id);
    }

    public async Task<int> GetDepartmentIdByNameAsync(string name)
    {
        await using var context = _contextFactory.CreateDbContext();
        if (string.IsNullOrEmpty(name))
            throw new ArgumentException("Name cannot be null or empty.", nameof(name));

        var departmentId = await context.Departments
                                        .Where(d => d.Name == name)
                                        .Select(i => i.Id)
                                        .FirstOrDefaultAsync();

        if (departmentId == 0)
            throw new KeyNotFoundException($"Department with name '{name}' not found.");

        return departmentId;
    }

    public async Task<int> AddAsync(Department department)
    {
        await using var context = _contextFactory.CreateDbContext();
        var added = context.Departments.Add(department);
        await context.SaveChangesAsync();

        return added.Entity.Id;
    }

    public async Task UpdateAsync(Department department)
    {
        await using var context = _contextFactory.CreateDbContext();
        context.Departments.Update(department);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await using var context = _contextFactory.CreateDbContext();
        var dep = await GetAsync(id);
        if (dep != null)
        {
            context.Departments.Remove(dep);
            await context.SaveChangesAsync();
        }
    }
}
