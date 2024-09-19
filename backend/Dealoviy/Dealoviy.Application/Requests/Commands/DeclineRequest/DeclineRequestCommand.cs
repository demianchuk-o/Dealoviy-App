using ErrorOr;
using MediatR;

namespace Dealoviy.Application.Requests.Commands.DeclineRequest;

public record DeclineRequestCommand(Guid RequestId, Guid UserContractorId) 
    : IRequest<ErrorOr<Unit>>;