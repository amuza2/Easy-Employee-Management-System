using EEMS.BusinessLogic.DTOs;
using EEMS.BusinessLogic.Interfaces;
using EEMS.DataAccess;
using EEMS.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace EEMS.BusinessLogic.Services;

public class UserService : IUserService
{
    private readonly IDbContextFactory<EEMSDbContext> _contextFactory;

    public UserService(IDbContextFactory<EEMSDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task<int> AddAsync(User user)
    {
        await using var context = _contextFactory.CreateDbContext();
        var userAdded = await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
        return userAdded.Entity.Id;
    }

    public async Task DeleteAsync(int id)
    {
        await using var context = _contextFactory.CreateDbContext();
        var user = await GetByIdAsync(id);
        if(user == null) throw new ArgumentNullException(nameof(user), "User not found");
        
        context.Users.Remove(user);
        await context.SaveChangesAsync();
    }

    public async Task<bool> ExistsByEmailAsync(string email)
    {
        await using var context = _contextFactory.CreateDbContext();
        return context.Users.Any(u => u.Email.ToLower() == email.ToLower());
    }

    public async Task<bool> ExistsByUsernameAsync(string username)
    {
        await using var context = _contextFactory.CreateDbContext();
        return context.Users.Any(u => u.Username.ToLower() == username.ToLower());
    }

    public async Task<User> GetByEmailAsync(string email)
    {
        await using var context = _contextFactory.CreateDbContext();
        return await context.Users.FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());
    }

    public async Task<User> GetByIdAsync(int id)
    {
        await using var context = _contextFactory.CreateDbContext();
        return await context.Users.FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<UserDto> GetByUsernameAsync(string username)
    {
        await using var context = _contextFactory.CreateDbContext();
        return await context.Users
            .Select(u => new UserDto
            {
                Id = u.Id,
                Username = u.Username,
                Email = u.Email
            })
            .FirstOrDefaultAsync(u => u.Username.ToLower() == username.ToLower());
            
    }

    public async Task UpdateAsync(User user)
    {
        await using var context = _contextFactory.CreateDbContext();
        context.Users.Update(user);
        await context.SaveChangesAsync();
    }
}
