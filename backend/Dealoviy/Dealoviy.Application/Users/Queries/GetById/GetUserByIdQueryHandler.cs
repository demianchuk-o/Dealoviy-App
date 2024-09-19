using Dealoviy.Application.Common.Interfaces.Persistence;
using Dealoviy.Domain.Common.Errors;
using Dealoviy.Domain.Users;
using MediatR;
using ErrorOr;

namespace Dealoviy.Application.Users.Queries.GetById;

public class GetUserByIdQueryHandler
    : IRequestHandler<GetUserByIdQuery, ErrorOr<UserResult>>
{
    private readonly IUserRepository _userRepository;

    public GetUserByIdQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<UserResult>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        if (await _userRepository.GetUserByIdAsync(request.UserId)
            is not User user)
        {
            return Errors.UserNotFound;
        }
        
        return new UserResult(
            user.Id,
            user.Username,
            user.DisplayName,
            user.ContractorProfileId);
    }
}