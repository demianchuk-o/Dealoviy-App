using Dealoviy.Contracts.Requests;
using MediatR;
using ErrorOr;

namespace Dealoviy.Application.Requests.Queries.GetRequestsForUser;

public record GetRequestsForUserQuery(Guid UserId) 
    : IRequest<ErrorOr<IEnumerable<UserRequestResponse>>>;