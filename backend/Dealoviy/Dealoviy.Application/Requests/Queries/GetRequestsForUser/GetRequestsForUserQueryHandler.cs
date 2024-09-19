using Dealoviy.Application.Common.Interfaces.Persistence;
using Dealoviy.Application.Common.Interfaces.Services;
using Dealoviy.Contracts.Common;
using Dealoviy.Contracts.Requests;
using Dealoviy.Domain.ContractorProfiles;
using Dealoviy.Domain.Services;
using Dealoviy.Domain.Users;
using MediatR;
using ErrorOr;
using MapsterMapper;

namespace Dealoviy.Application.Requests.Queries.GetRequestsForUser;

public class GetRequestsForUserQueryHandler
    : IRequestHandler<GetRequestsForUserQuery, ErrorOr<IEnumerable<UserRequestResponse>>>
{
    private readonly IServiceRepository _serviceRepository;
    private readonly IRequestRepository _requestRepository;
    private readonly IMapper _mapper;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IUserRepository _userRepository;
    private readonly IContractorProfileRepository _contractorProfileRepository;

    public GetRequestsForUserQueryHandler(
        IServiceRepository serviceRepository, 
        IRequestRepository requestRepository, 
        IMapper mapper, 
        IDateTimeProvider dateTimeProvider, 
        IUserRepository userRepository, 
        IContractorProfileRepository contractorProfileRepository)
    {
        _serviceRepository = serviceRepository;
        _requestRepository = requestRepository;
        _mapper = mapper;
        _dateTimeProvider = dateTimeProvider;
        _userRepository = userRepository;
        _contractorProfileRepository = contractorProfileRepository;
    }

    public async Task<ErrorOr<IEnumerable<UserRequestResponse>>> Handle(GetRequestsForUserQuery request, CancellationToken cancellationToken)
    {
        var requests = await _requestRepository.GetByCustomerIdAsync(request.UserId);
        
        var servicesTasks = requests
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
        
        return requests
            .Select((r, i) => new UserRequestResponse(
                r.Id,
                r.Description,
                r.PaymentAmount,
                r.RequestDate,
                r.RequestStatus.ToString(),
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