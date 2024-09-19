using Dealoviy.Application.Common.Interfaces.Persistence;
using Dealoviy.Contracts.Common;
using Dealoviy.Contracts.Orders;
using Dealoviy.Domain.Common.Errors;
using Dealoviy.Domain.Users;
using ErrorOr;
using MediatR;

namespace Dealoviy.Application.Orders.Queries.GetOrdersForService;

public class GetOrdersForServiceQueryHandler
    : IRequestHandler<GetOrdersForServiceQuery, 
        ErrorOr<IEnumerable<ServiceOrderResponse>>>
{
    private readonly IServiceRepository _serviceRepository;
    private readonly IOrderRepository _orderRepository;
    private readonly IUserRepository _userRepository;

    public GetOrdersForServiceQueryHandler(
        IServiceRepository serviceRepository, 
        IOrderRepository orderRepository, 
        IUserRepository userRepository)
    {
        _serviceRepository = serviceRepository;
        _orderRepository = orderRepository;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<IEnumerable<ServiceOrderResponse>>> 
        Handle(GetOrdersForServiceQuery request, 
            CancellationToken cancellationToken)
    {
        if (await _serviceRepository.GetByIdAsync(request.ServiceId) 
            is not { } service)
        {
            return Errors.ServiceNotFound;
        }
        
        
        var orders = await _orderRepository.GetByServiceIdAsync(service.Id);

        var customersTasks = orders
            .Select(r => _userRepository.GetUserByIdAsync(r.CustomerId));
        
        var customers = new List<User>();
        
        foreach (var task in customersTasks)
        {
            customers.Add(await task);
        }
        
        return orders
            .Select((o, i) => new ServiceOrderResponse(
                o.Id,
                o.Description,
                o.PaymentAmount,
                o.OrderDate,
                o.OrderStatus.ToString(),
                customers[i].GetDisplayName(),
                new ContactInfoResponse(
                    o.CustomerContactInfo.Type.ToString(),
                    o.CustomerContactInfo.Value)
            ))
            .OrderByDescending(o => o.RequestDate)
            .ToList();
    }
}