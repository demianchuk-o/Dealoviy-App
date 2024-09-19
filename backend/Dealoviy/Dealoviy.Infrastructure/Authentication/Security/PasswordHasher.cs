using System.Security.Cryptography;
using Dealoviy.Application.Common.Interfaces.Security;

namespace Dealoviy.Infrastructure.Authentication.Security;

public class PasswordHasher : IPasswordHasher
{
    private const int Iterations = 10000;
    
    private const int SaltSize = 16;
    
    private const int HashSize = 32;

    public string HashPassword(string password)
    {
        byte[] salt = new byte[SaltSize];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }
        
        var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations);
        
        byte[] hash = pbkdf2.GetBytes(HashSize);
        
        byte[] hashBytes = new byte[SaltSize + HashSize];
        Array.Copy(salt, 0, hashBytes, 0, SaltSize);
        Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);
        string hashedPassword = Convert.ToBase64String(hashBytes);

        return hashedPassword;
    }

    public bool VerifyPassword(string hashedPassword, string password)
    {
        byte[] hashBytes = Convert.FromBase64String(hashedPassword);
        
        byte[] salt = new byte[SaltSize];
        Array.Copy(hashBytes, 0, salt, 0, SaltSize);
        
        var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations);
        byte[] hash = pbkdf2.GetBytes(HashSize);
        
        for (int i = 0; i < HashSize; i++)
        {
            if (hashBytes[i + SaltSize] != hash[i])
                return false;
        }

        return true;
    }
}