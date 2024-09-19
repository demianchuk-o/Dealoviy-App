using Dealoviy.Application.Common.Interfaces.Persistence;
using Dealoviy.Domain.Requests;
using ErrorOr;
using MediatR;

namespace Dealoviy.Application.Requests.Commands.DeclineRequest;

public class DeclineRequestCommandHandler
    : IRequestHandler<DeclineRequestCommand, ErrorOr<Unit>>
{
    private readonly IRequestRepository _requestRepository;
    private readonly IUserRepository _userRepository;
    private readonly IContractorProfileRepository _contractorProfileRepository;

    public DeclineRequestCommandHandler(
        IRequestRepository requestRepository, 
        IUserRepository userRepository, 
        IContractorProfileRepository contractorProfileRepository)
    {
        _requestRepository = requestRepository;
        _userRepository = userRepository;
        _contractorProfileRepository = contractorProfileRepository;
    }

    public async Task<ErrorOr<Unit>> Handle(DeclineRequestCommand request, CancellationToken cancellationToken)
    {
        var requestEntity = await _requestRepository.GetByIdAsync(request.RequestId);
        
        if (requestEntity is null)
            return Error.NotFound("Request not found");
        
        var contractor = await _userRepository.GetUserByIdAsync(request.UserContractorId);
        if(contractor.ContractorProfileId is null)
            return Error.NotFound("Contractor not found");
        
        var contractorProfile = await _contractorProfileRepository.GetByIdAsync(contractor.ContractorProfileId.Value);
        
        if (contractorProfile is null)
            return Error.NotFound("Contractor profile not found");
        
        requestEntity.UpdateRequestStatus(RequestStatus.Declined);
        
        await _requestRepository.UpdateAsync(requestEntity);

        return Unit.Value;
    }
}