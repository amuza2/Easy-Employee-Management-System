using EEMS.BusinessLogic.DTOs;
using EEMS.BusinessLogic.Interfaces;
using EEMS.Models.Models;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;

namespace EEMS.BusinessLogic.Services;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;
    private readonly IUserService _userService;

    public TokenService(IConfiguration configuration, IUserService userService)
    {
        _configuration = configuration;
        _userService = userService;
    }

    public string GenerateRefreshToken()
    {
        throw new NotImplementedException();
    }

    public string GenerateToken(User user)
    {
        throw new NotImplementedException();
    }

    public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
    {
        throw new NotImplementedException();
    }

    public Task<TokenDto> RefreshTokenAsync(string token, string refreshToken)
    {
        throw new NotImplementedException();
    }

    public bool ValidateToken(string token, out ClaimsPrincipal claimsPrincipal)
    {
        throw new NotImplementedException();
    }
}
