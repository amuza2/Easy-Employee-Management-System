using EEMS.BusinessLogic.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace EEMS.BusinessLogic.Services;

public class PasswordHasher : IPasswordHasher
{
    private const int _saltSize = 16;
    private const int KeySize = 32;
    private const int iterations = 10_000;
    private static readonly HashAlgorithmName _algorith = HashAlgorithmName.SHA256;

    public string GenerateSalt()
    {
        var salt = RandomNumberGenerator.GetBytes(_saltSize);
        return Convert.ToBase64String(salt);
    }

    public string HashPassword(string password, string salt)
    {
        var saltBytes = Convert.FromBase64String(salt);

        var hash = Rfc2898DeriveBytes.Pbkdf2(
            Encoding.UTF8.GetBytes(password),
            saltBytes,
            iterations,
            _algorith,
            KeySize);

        return Convert.ToBase64String(hash);
    }

    public bool VerifyPassword(string password, string passwordHash, string salt)
    {
        var hashCompare = HashPassword(password, salt);
        return CryptographicOperations.FixedTimeEquals(
            Convert.FromBase64String(hashCompare),
            Convert.FromBase64String(passwordHash));
    }
}
