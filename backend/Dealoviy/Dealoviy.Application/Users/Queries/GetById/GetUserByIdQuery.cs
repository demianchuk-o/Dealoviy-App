using MediatR;
using ErrorOr;
namespace Dealoviy.Application.Users.Queries.GetById;

public record GetUserByIdQuery(Guid UserId) 
    : IRequest<ErrorOr<UserResult>>;