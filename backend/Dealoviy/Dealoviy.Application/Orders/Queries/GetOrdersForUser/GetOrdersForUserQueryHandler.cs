using Dealoviy.Application.Common.Interfaces.Persistence;
using Dealoviy.Contracts.Common;
using Dealoviy.Contracts.Orders;
using Dealoviy.Domain.ContractorProfiles;
using Dealoviy.Domain.Services;
using Dealoviy.Domain.Users;
using MediatR;
using ErrorOr;

namespace Dealoviy.Application.Orders.Queries.GetOrdersForUser;

public class GetOrdersForUserQueryHandler
: IRequestHandler<GetOrdersForUserQuery, ErrorOr<IEnumerable<UserOrderResponse>>>
{
    private readonly IServiceRepository _serviceRepository;
    private readonly IOrderRepository _orderRepository;
    private readonly IUserRepository _userRepository;
    private readonly IContractorProfileRepository _contractorProfileRepository;

    public GetOrdersForUserQueryHandler(
        IServiceRepository serviceRepository, 
        IOrderRepository orderRepository, 
        IUserRepository userRepository, 
        IContractorProfileRepository contractorProfileRepository)
    {
        _serviceRepository = serviceRepository;
        _orderRepository = orderRepository;
        _userRepository = userRepository;
        _contractorProfileRepository = contractorProfileRepository;
    }

    public async Task<ErrorOr<IEnumerable<UserOrderResponse>>> Handle(
        GetOrdersForUserQuery request, 
        CancellationToken cancellationToken)
    {
        var orders = await _orderRepository.GetByCustomerIdAsync(request.UserId);
        
        var servicesTasks = orders
            .Select(r => _serviceRepository.GetByIdAsync(r.ServiceId));
        
        var services = new List<Service>();
        
        foreach (var task in servicesTasks)
        {
            services.Add(await task);
        }
        
        var contractorTasks = services
            .Select(s => _contractorProfileRepository.GetByIdAsync(s.ContractorId));
        
        var contractors = new List<ContractorProfile>();
        
        foreach (var task in contractorTasks)
        {
            contractors.Add(await task);
        }
        
        var usersTasks = contractors
            .Select(c => _userRepository.GetByContractorIdAsync(c.Id));
        
        var users = new List<User>();
        
        foreach (var task in usersTasks)
        {
            users.Add(await task);
        }
        
        return orders
            .Select((r, i) => new UserOrderResponse(
                r.Id,
                r.Description,
                r.PaymentAmount,
                r.OrderDate,
                r.OrderStatus.ToString(),
                users[i].GetDisplayName(),
        services[i].Id,
                services[i].Name,
                new ContactInfoResponse(
                    r.ContractorContactInfo.Type.ToString(),
                    r.ContractorContactInfo.Value)))
            .OrderByDescending(r => r.RequestDate)
            .ToList();
    }
}