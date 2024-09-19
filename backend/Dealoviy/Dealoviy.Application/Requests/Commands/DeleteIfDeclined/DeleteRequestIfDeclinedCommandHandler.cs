using Dealoviy.Application.Common.Interfaces.Persistence;
using Dealoviy.Domain.Requests;
using MediatR;
using ErrorOr;

namespace Dealoviy.Application.Requests.Commands.DeleteIfDeclined;

public class DeleteRequestIfDeclinedCommandHandler
    : IRequestHandler<DeleteRequestIfDeclinedCommand,
    ErrorOr<Unit>>
{
    private readonly IRequestRepository _requestRepository;
    private readonly IUserRepository _userRepository;

    public DeleteRequestIfDeclinedCommandHandler(
        IRequestRepository requestRepository, 
        IUserRepository userRepository)
    {
        _requestRepository = requestRepository;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<Unit>> Handle(DeleteRequestIfDeclinedCommand request, CancellationToken cancellationToken)
    {
        var requestEntity = await _requestRepository.GetByIdAsync(request.RequestId);
        if(requestEntity is null)
            return Error.NotFound("Request not found");
        
        var customer = await _userRepository.GetUserByIdAsync(request.UserCustomerId);
        if(customer is null)
            return Error.NotFound("Customer not found");
        
        if(requestEntity.RequestStatus == RequestStatus.Declined)
            await _requestRepository.DeleteAsync(requestEntity);
        
        return Unit.Value;
    }
}