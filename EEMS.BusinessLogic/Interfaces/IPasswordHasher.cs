namespace EEMS.BusinessLogic.Interfaces;

public interface IPasswordHasher
{
    string GenerateSalt();
    string HashPassword(string password, string salt);
    bool VerifyPassword(string password, string passwordHash, string salt);
}
