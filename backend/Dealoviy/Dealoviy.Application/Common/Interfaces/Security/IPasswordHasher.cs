namespace Dealoviy.Application.Common.Interfaces.Security;

public interface IPasswordHasher
{
    string HashPassword(string password);
    bool VerifyPassword(string hashedPassword, string password);
}