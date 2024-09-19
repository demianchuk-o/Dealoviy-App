using Dealoviy.Application.Authentication.Common;
using Dealoviy.Application.Common.Interfaces.Authentication;
using Dealoviy.Application.Common.Interfaces.Persistence;
using Dealoviy.Application.Common.Interfaces.Security;
using Dealoviy.Domain.Common.Errors;
using Dealoviy.Domain.Users;
using ErrorOr;
using MediatR;

namespace Dealoviy.Application.Authentication.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;

    public LoginQueryHandler(
        IJwtTokenGenerator jwtTokenGenerator, 
        IUserRepository userRepository, 
        IPasswordHasher passwordHasher)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        if (await _userRepository.GetUserByUsernameAsync(request.Username) is not User user)
        {
            return Errors.InvalidCredentials;
        }
        
        if(!_passwordHasher.VerifyPassword(user.PasswordHash, request.Password))
        {
            return Errors.InvalidCredentials;
        }
        
        var token = _jwtTokenGenerator.GenerateToken(user);
        
        var contractorProfileId = user.ContractorProfileId is null
            ? null
            : user.ContractorProfileId.ToString();
        
        return new AuthenticationResult(
            user.Id,
            user.Username,
            user.DisplayName,
            contractorProfileId,
            token);
    }
}