using Dealoviy.Application.Common.Interfaces.Persistence;
using Dealoviy.Contracts.Services;
using Dealoviy.Domain.Common.Errors;
using Dealoviy.Domain.Orders;
using Dealoviy.Domain.Requests;
using MediatR;
using ErrorOr;

namespace Dealoviy.Application.Services.Queries.GetServicesWithStats;

public class GetServicesWithStatsQueryHandler
: IRequestHandler<GetServicesWithStatsQuery, ErrorOr<IEnumerable<ServiceTaskStatResponse>>>
{
    private readonly IUserRepository _userRepository;
    private readonly IServiceRepository _serviceRepository;
    private readonly IRequestRepository _requestRepository;
    private readonly IOrderRepository _orderRepository;

    public GetServicesWithStatsQueryHandler(
        IUserRepository userRepository, 
        IServiceRepository serviceRepository, 
        IRequestRepository requestRepository, 
        IOrderRepository orderRepository)
    {
        _userRepository = userRepository;
        _serviceRepository = serviceRepository;
        _requestRepository = requestRepository;
        _orderRepository = orderRepository;
    }

    public async Task<ErrorOr<IEnumerable<ServiceTaskStatResponse>>> Handle(GetServicesWithStatsQuery request, CancellationToken cancellationToken)
    {
        if (await _userRepository.GetUserByIdAsync(request.UserId) is not { } user)
        {
            return Errors.UserNotFound;
        }
        
        if(user.ContractorProfileId is null)
        {
            return Errors.UserIsNotAContractor;
        }
        
        var services = await _serviceRepository.GetByContractorIdAsync(user.ContractorProfileId.Value);
        var serviceTaskStats = new List<ServiceTaskStatResponse>();

        foreach (var service in services)
        {
            var requests = await _requestRepository.GetByServiceIdAsync(service.Id);
            var pendingRequestsCount = requests
                .Count(r => r.RequestStatus == RequestStatus.Pending);
            
            var orders = await _orderRepository.GetByServiceIdAsync(service.Id);
            var notFinishedOrdersCount = orders
                .Count(o => o.OrderStatus != OrderStatus.Finished);
            
            var serviceTaskStat = new ServiceTaskStatResponse(
                service.Id,
                service.Name,
                pendingRequestsCount,
                notFinishedOrdersCount);
            
            serviceTaskStats.Add(serviceTaskStat);
        }
        
        return serviceTaskStats;
    }
}