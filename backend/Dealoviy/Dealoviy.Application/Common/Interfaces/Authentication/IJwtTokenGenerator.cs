using Dealoviy.Domain.Users;

namespace Dealoviy.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}