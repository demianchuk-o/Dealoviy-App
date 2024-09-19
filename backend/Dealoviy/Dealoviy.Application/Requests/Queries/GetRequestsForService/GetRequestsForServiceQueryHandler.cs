using Dealoviy.Application.Common.Interfaces.Persistence;
using Dealoviy.Contracts.Common;
using Dealoviy.Contracts.Requests;
using Dealoviy.Domain.Common.Errors;
using Dealoviy.Domain.Requests;
using Dealoviy.Domain.Users;
using MediatR;
using ErrorOr;
using MapsterMapper;

namespace Dealoviy.Application.Requests.Queries.GetRequestsForService;

public class GetRequestsForServiceQueryHandler
    : IRequestHandler<GetRequestsForServiceQuery, 
        ErrorOr<IEnumerable<ServiceRequestResponse>>>
{
    private readonly IServiceRepository _serviceRepository;
    private readonly IRequestRepository _requestRepository;
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public GetRequestsForServiceQueryHandler(
        IServiceRepository serviceRepository, 
        IRequestRepository requestRepository, 
        IMapper mapper, 
        IUserRepository userRepository)
    {
        _serviceRepository = serviceRepository;
        _requestRepository = requestRepository;
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<IEnumerable<ServiceRequestResponse>>> 
        Handle(GetRequestsForServiceQuery request, 
            CancellationToken cancellationToken)
    {
        if (await _serviceRepository.GetByIdAsync(request.ServiceId) 
            is not { } service)
        {
            return Errors.ServiceNotFound;
        }
        
        
        var requests = await _requestRepository.GetByServiceIdAsync(service.Id);
        requests = requests.Where(r => r.RequestStatus == RequestStatus.Pending);
        
        
        var customersTasks = requests
            .Select(r => _userRepository.GetUserByIdAsync(r.CustomerId));
        
        var customers = new List<User>();
        
        foreach (var task in customersTasks)
        {
            customers.Add(await task);
        }
        
        
        
        return requests
            .Select((r, i) => new ServiceRequestResponse(
                r.Id,
                r.Description,
                r.PaymentAmount,
                r.RequestDate,
                r.RequestStatus.ToString(),
                customers[i].GetDisplayName(),
                new ContactInfoResponse(
                    r.CustomerContactInfo.Type.ToString(),
                    r.CustomerContactInfo.Value)
                ))
            .OrderByDescending(r => r.RequestDate)
            .ToList();
    }
}