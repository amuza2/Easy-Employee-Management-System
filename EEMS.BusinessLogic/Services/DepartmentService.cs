using EEMS.BusinessLogic.Interfaces;
using EEMS.DataAccess;
using EEMS.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace EEMS.BusinessLogic.Services;

public class DepartmentService : IDepartmentService
{
    private readonly EEMSDbContext _context;

    public DepartmentService(EEMSDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Department>> GetAsync()
    {
        return await _context.Departments.ToListAsync();
    }

    public async Task<Department> GetAsync(int id)
    {
        return await _context.Departments.FindAsync(id);
    }

    public async Task<int> GetDepartmentIdByNameAsync(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentException("Name cannot be null or empty.", nameof(name));

        var departmentId = await _context.Departments
                                        .Where(d => d.Name == name)
                                        .Select(i => i.Id)
                                        .FirstOrDefaultAsync();

        if (departmentId == 0)
            throw new KeyNotFoundException($"Department with name '{name}' not found.");

        return departmentId;
    }

    public async Task<int> AddAsync(Department department)
    {
        var added = _context.Departments.Add(department);
        await _context.SaveChangesAsync();

        return added.Entity.Id;
    }

    public async Task UpdateAsync(Department department)
    {
        _context.Departments.Update(department);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var dep = await GetAsync(id);
        if (dep != null)
        {
            _context.Departments.Remove(dep);
            await _context.SaveChangesAsync();
        }
    }
}
