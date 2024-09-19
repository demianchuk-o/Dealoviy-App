using Dealoviy.Application.Authentication.Common;
using Dealoviy.Application.Common.Interfaces.Authentication;
using Dealoviy.Application.Common.Interfaces.Persistence;
using Dealoviy.Application.Common.Interfaces.Security;
using Dealoviy.Domain.Common.Errors;
using Dealoviy.Domain.Users;
using ErrorOr;

using MediatR;

namespace Dealoviy.Application.Authentication.Commands.Register;

public class RegisterCommandHandler 
    : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;

    public RegisterCommandHandler(
        IJwtTokenGenerator jwtTokenGenerator, 
        IUserRepository userRepository, 
        IPasswordHasher passwordHasher)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {

        if (await _userRepository.GetUserByUsernameAsync(request.Username) is not null)
        {
            return Errors.DuplicateUsername;
        }

        var hashedPassword = _passwordHasher.HashPassword(request.Password);
        
        var user = User.Create(
            request.Username,
            request.DisplayName,
            hashedPassword);
        
        
        await _userRepository.AddAsync(user);
        
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