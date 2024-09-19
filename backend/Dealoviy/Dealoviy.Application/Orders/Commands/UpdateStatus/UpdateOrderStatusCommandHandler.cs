using Dealoviy.Application.Common.Interfaces.Persistence;
using Dealoviy.Domain.Orders;
using Dealoviy.Domain.Users;
using ErrorOr;
using MediatR;

namespace Dealoviy.Application.Orders.Commands.UpdateStatus;

public class UpdateOrderStatusCommandHandler
    : IRequestHandler<UpdateOrderStatusCommand, ErrorOr<Unit>>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IUserRepository _userRepository;
    private readonly IContractorProfileRepository _contractorProfileRepository;

    public UpdateOrderStatusCommandHandler(
        IOrderRepository orderRepository, 
        IUserRepository userRepository, 
        IContractorProfileRepository contractorProfileRepository)
    {
        _orderRepository = orderRepository;
        _userRepository = userRepository;
        _contractorProfileRepository = contractorProfileRepository;
    }

    public async Task<ErrorOr<Unit>> Handle(UpdateOrderStatusCommand request, CancellationToken cancellationToken)
    {
        if (await _orderRepository.GetByIdAsync(request.OrderId)
            is not Order order)
        {
            return Error.NotFound("Order.NotFound", "Order was not found");
        }
        
        if (await _userRepository.GetUserByIdAsync(request.UserContractorId)
            is not User contractor)
        {
            return Error.NotFound("Contractor.NotFound", "Contractor was not found");
        }
        
        if (contractor.ContractorProfileId is null)
        {
            return Error.Conflict("User.NotContractor", "User is not a contractor");
        }
        
        if (await _contractorProfileRepository.GetByIdAsync(contractor.ContractorProfileId.Value)
            is null)
        {
            return Error.NotFound("ContractorProfile.NotFound", "Contractor profile was not found");
        }
        
        order.UpdateOrderStatus(request.Status);
        await _orderRepository.UpdateAsync(order);

        return Unit.Value;
    }
}