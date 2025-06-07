using EEMS.BusinessLogic.DTOs;

namespace EEMS.BusinessLogic.Models;

public class AuthResult
{
    public bool Succeeded { get; set; }
    public string[] Errors { get; set; } = Array.Empty<string>();
    public UserDto User { get; set; }
    public string Token { get; set; }
}
