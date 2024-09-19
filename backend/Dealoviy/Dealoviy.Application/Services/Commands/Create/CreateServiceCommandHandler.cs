using Dealoviy.Application.Common.Interfaces.Persistence;
using Dealoviy.Domain.Common.Errors;
using Dealoviy.Domain.ContractorProfiles;
using Dealoviy.Domain.Services;
using Dealoviy.Domain.Users;
using ErrorOr;
using MediatR;

namespace Dealoviy.Application.Services.Commands.Create;

public class CreateServiceCommandHandler 
    : IRequestHandler<CreateServiceCommand, ErrorOr<Unit>>
{
    private readonly IUserRepository _userRepository;
    private readonly IServiceRepository _serviceRepository;
    private readonly IContractorProfileRepository _contractorProfileRepository;
    private readonly ICityRepository _cityRepository;

    public CreateServiceCommandHandler(
        IUserRepository userRepository,
        IServiceRepository serviceRepository, 
        IContractorProfileRepository contractorProfileRepository, 
        ICityRepository cityRepository)
    {
        _userRepository = userRepository;
        _serviceRepository = serviceRepository;
        _contractorProfileRepository = contractorProfileRepository;
        _cityRepository = cityRepository;
    }

    public async Task<ErrorOr<Unit>> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
    {
        if (await _userRepository.GetUserByIdAsync(request.UserId) is not User user)
        {
            return Errors.UserNotFound;
        }

        if (user.ContractorProfileId is null)
        {
            return Errors.UserIsNotAContractor;
        }
        
        if (await _contractorProfileRepository.GetByIdAsync(user.ContractorProfileId.Value)
            is not ContractorProfile profile)
        {
            return Errors.ContractorProfileNotFound;
        }
        
        if (await _cityRepository.GetCityByIdAsync(request.CityId)
            is null)
        {
            return Errors.CityNotFound;
        }
        
        var serviceResult = Service.Create(
            profile.Id,
            request.CityId,
            request.Name,
            request.Description,
            request.LowerPriceBound,
            request.UpperPriceBound);

        if (serviceResult.IsError)
        {
            return serviceResult.Errors;
        }
        
        await _serviceRepository.AddAsync(serviceResult.Value);
        
        return Unit.Value;
    }
}