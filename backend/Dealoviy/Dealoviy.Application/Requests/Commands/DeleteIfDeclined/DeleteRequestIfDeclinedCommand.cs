using MediatR;
using ErrorOr;

namespace Dealoviy.Application.Requests.Commands.DeleteIfDeclined;

public record DeleteRequestIfDeclinedCommand(Guid RequestId, Guid UserCustomerId) 
    : IRequest<ErrorOr<Unit>>;