using ErrorOr;
using MediatR;
namespace Dealoviy.Application.Requests.Commands.AcceptRequest;

public record AcceptRequestCommand(Guid RequestId, Guid UserContractorId) 
    : IRequest<ErrorOr<Unit>>;