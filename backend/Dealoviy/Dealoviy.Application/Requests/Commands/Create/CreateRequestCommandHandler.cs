using Dealoviy.Application.Common.Interfaces.Persistence;
using Dealoviy.Application.Common.Interfaces.Services;
using Dealoviy.Domain.Common.ContactInfo;
using Dealoviy.Domain.Common.Errors;
using Dealoviy.Domain.Requests;
using Dealoviy.Domain.Services;
using MediatR;
using ErrorOr;
using Mapster;

namespace Dealoviy.Application.Requests.Commands.Create;

public class CreateRequestCommandHandler
    : IRequestHandler<CreateRequestCommand, ErrorOr<Unit>>
{
    private readonly IRequestRepository _requestRepository;
    private readonly IServiceRepository _serviceRepository;
    private readonly IUserRepository _userRepository;
    private readonly IContractorProfileRepository _contractorProfileRepository;
    private readonly IDateTimeProvider _dateTimeProvider;
    
    public CreateRequestCommandHandler(
        IRequestRepository requestRepository, 
        IServiceRepository serviceRepository, 
        IUserRepository userRepository, 
        IContractorProfileRepository contractorProfileRepository, 
        IDateTimeProvider dateTimeProvider)
    {
        _requestRepository = requestRepository;
        _serviceRepository = serviceRepository;
        _userRepository = userRepository;
        _contractorProfileRepository = contractorProfileRepository;
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task<ErrorOr<Unit>> Handle(CreateRequestCommand request, CancellationToken cancellationToken)
    {
        if (await _serviceRepository.GetByIdAsync(request.ServiceId) 
            is not Service service)
        {
            return Errors.ServiceNotFound;
        }
        
        if (await _userRepository.GetUserByIdAsync(request.CustomerId) is null)
        {
            return Errors.UserNotFound;
        }

        var contractor = await _contractorProfileRepository.GetByIdAsync(service.ContractorId);
        var contractorContactInfo = contractor.ContactInfos
            .FirstOrDefault(ci => ci.Type.ToString() == request.CustomerContactInfo.Type);
        var requestResult = Request.Create(
            request.CustomerId,
            request.ServiceId,
            request.Description,
            request.PaymentAmount,
            _dateTimeProvider.UtcNow,    
            RequestStatus.Pending,
            request.CustomerContactInfo.Adapt<ContactInfoCreateModel>(),
            contractorContactInfo
            );

        if (requestResult.IsError)
        {
            return requestResult.Errors;
        }
        
        await _requestRepository.AddAsync(requestResult.Value);
        
        return Unit.Value;
    }
}