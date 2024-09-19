using Dealoviy.Application.Common.Interfaces.Persistence;
using Dealoviy.Application.Common.Interfaces.Services;
using Dealoviy.Domain.Orders;
using MediatR;
using ErrorOr;

namespace Dealoviy.Application.Requests.Commands.AcceptRequest;

public class AcceptRequestCommandHandler
    : IRequestHandler<AcceptRequestCommand, ErrorOr<Unit>>
{
    private readonly IRequestRepository _requestRepository;
    private readonly IUserRepository _userRepository;
    private readonly IContractorProfileRepository _contractorProfileRepository;
    private readonly IOrderRepository _orderRepository;
    private readonly IDateTimeProvider _dateTimeProvider;

    public AcceptRequestCommandHandler(
        IRequestRepository requestRepository, 
        IUserRepository userRepository, 
        IContractorProfileRepository contractorProfileRepository,
        IOrderRepository orderRepository, 
        IDateTimeProvider dateTimeProvider)
    {
        _requestRepository = requestRepository;
        _userRepository = userRepository;
        _contractorProfileRepository = contractorProfileRepository;
        _orderRepository = orderRepository;
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task<ErrorOr<Unit>> Handle(AcceptRequestCommand request, CancellationToken cancellationToken)
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
        
        var order = Order.Create(requestEntity,
            _dateTimeProvider.UtcNow);
        await _orderRepository.AddAsync(order);
        
        await _requestRepository.DeleteAsync(requestEntity);
        
        return Unit.Value;
    }
}