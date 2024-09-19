using Dealoviy.Application.Common.Interfaces.Persistence;
using Dealoviy.Contracts.Services;
using Dealoviy.Domain.Common.Errors;
using Dealoviy.Domain.Common.Location;
using MediatR;
using ErrorOr;

namespace Dealoviy.Application.Services.Queries.GetOwnServices;

public class GetOwnServicesQueryHandler
    : IRequestHandler<GetOwnServicesQuery, ErrorOr<IEnumerable<ServiceResponse>>>
{
    private readonly IUserRepository _userRepository;
    private readonly IServiceRepository _serviceRepository;
    private readonly ICityRepository _cityRepository;
    public GetOwnServicesQueryHandler(
        IUserRepository userRepository, 
        IServiceRepository serviceRepository, 
        ICityRepository cityRepository)
    {
        _userRepository = userRepository;
        _serviceRepository = serviceRepository;
        _cityRepository = cityRepository;
    }

    public async Task<ErrorOr<IEnumerable<ServiceResponse>>> Handle(GetOwnServicesQuery request, CancellationToken cancellationToken)
    {
        if (await _userRepository.GetUserByIdAsync(request.UserId)
            is not { } user)
        {
            return Errors.UserNotFound;
        }

        if (user.ContractorProfileId is null)
        {
            return Errors.UserIsNotAContractor;
        }
        
        var services = await _serviceRepository.GetByContractorIdAsync(user.ContractorProfileId.Value);
        
        var citiesTasks = services.Select(service => _cityRepository.GetCityByIdAsync(service.CityId));
        
        var cities = new List<City>();
        
        foreach (var task in citiesTasks)
        {
            cities.Add(await task);
        }
        
        var result = services.Zip(cities, (service, city) => new ServiceResponse(
            service.Id, 
            service.ContractorId, 
            service.Name, 
            city.Name, 
            service.Description, 
            service.PriceRange.Lower, 
            service.PriceRange.Upper, 
            service.AverageRating.Value, 
            service.AverageRating.Count))
            .ToList();
        
        return result;
    }
}