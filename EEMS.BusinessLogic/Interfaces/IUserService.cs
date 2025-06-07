using EEMS.BusinessLogic.DTOs;
using EEMS.Models.Models;

namespace EEMS.BusinessLogic.Interfaces;

public interface IUserService
{
    Task<User> GetByIdAsync(int id);
    Task<UserDto> GetByUsernameAsync(string username);
    Task<User> GetByEmailAsync(string email);
    Task<bool> ExistsByUsernameAsync(string username);
    Task<bool> ExistsByEmailAsync(string email);
    Task<int> AddAsync(User user);
    Task UpdateAsync(User user);
    Task DeleteAsync(int id);
}
