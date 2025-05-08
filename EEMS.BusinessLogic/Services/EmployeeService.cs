using EEMS.BusinessLogic.Interfaces;
using EEMS.DataAccess;
using EEMS.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace EEMS.BusinessLogic.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IDbContextFactory<EEMSDbContext> _contextFactory;

    public EmployeeService(IDbContextFactory<EEMSDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task<IEnumerable<Employee>> GetAsync()
    {
        await using var context = _contextFactory.CreateDbContext();
        return await context.Employees
            .Include(a => a.Absences)
            .Include(c => c.Department)
            .ToListAsync();
    }

    public async Task<Employee> GetFirstEmployeeAsync()
    {
        await using var context = _contextFactory.CreateDbContext();
        return await context.Employees
            .Include(a => a.Absences)
            .Include(c => c.Department)
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Employee>> GetEmployeesByDepartmentId(int departmentId)
    {
        await using var context = _contextFactory.CreateDbContext();
        return await context.Employees
            .Include(a => a.Absences)
            .Include(c => c.Department)
            .Where(e => e.DepartmentId == departmentId)
            .ToListAsync();
    }

    public async Task<Employee> GetAsync(int id)
    {
        await using var context = _contextFactory.CreateDbContext();
        return await context.Employees
            .Include(a => a.Absences)
            .Include(c => c.Department)
            .FirstAsync(e => e.Id == id);
    }

    public async Task<int> AddAsync(Employee employee)
    {
        await using var context = _contextFactory.CreateDbContext();
        var added = context.Employees.Add(employee);
        await context.SaveChangesAsync();

        return added.Entity.Id;
    }

    public async Task UpdateAsync(Employee employee)
    {
        await using var context = _contextFactory.CreateDbContext();
        context.Employees.Update(employee);
        await context.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        await using var context = _contextFactory.CreateDbContext();
        var emp = await GetAsync(id);
        if (emp != null)
        {
            context.Employees.Remove(emp);
            await context.SaveChangesAsync();
            return true;
        }
        return false;
    }
}
