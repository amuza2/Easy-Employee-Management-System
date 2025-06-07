using EEMS.BusinessLogic.DTOs;
using EEMS.Models.Models;
using System.Security.Claims;

namespace EEMS.BusinessLogic.Interfaces;

public interface ITokenService
{
    string GenerateToken(User user);
    bool ValidateToken(string token, out ClaimsPrincipal claimsPrincipal);
    ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    string GenerateRefreshToken();
    Task<TokenDto> RefreshTokenAsync(string token, string refreshToken);
}
