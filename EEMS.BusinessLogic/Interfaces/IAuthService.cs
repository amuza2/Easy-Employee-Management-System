using EEMS.BusinessLogic.DTOs;
using EEMS.BusinessLogic.Models;

namespace EEMS.BusinessLogic.Interfaces;

public interface IAuthService
{
    Task<AuthResult> LoginAsync(LoginDto loginDto);
    Task<AuthResult> RegisterAsync(RegisterDto registerDto);
    Task LogoutAsync();
    Task<UserDto> GetCurrentUserAsync();
}
