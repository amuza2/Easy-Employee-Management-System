using EEMS.BusinessLogic.DTOs;
using EEMS.BusinessLogic.Interfaces;
using EEMS.BusinessLogic.Models;

namespace EEMS.BusinessLogic.Services;

public class AuthService : IAuthService
{

    public Task<UserDto> GetCurrentUserAsync()
    {
        throw new NotImplementedException();
    }

    public Task<AuthResult> LoginAsync(LoginDto loginDto)
    {
        throw new NotImplementedException();
    }

    public Task LogoutAsync()
    {
        throw new NotImplementedException();
    }

    public Task<AuthResult> RegisterAsync(RegisterDto registerDto)
    {
        throw new NotImplementedException();
    }
}
