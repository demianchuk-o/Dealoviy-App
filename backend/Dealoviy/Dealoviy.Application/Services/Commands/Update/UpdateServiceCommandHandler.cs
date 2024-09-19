using Dealoviy.Application.Common.Interfaces.Persistence;
using Dealoviy.Domain.Common.Errors;
using Dealoviy.Domain.Services;
using MediatR;
using ErrorOr;

namespace Dealoviy.Application.Services.Commands.Update;

public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand, ErrorOr<Unit>>
{
    private readonly IServiceRepository _serviceRepository;
    private readonly ICityRepository _cityRepository;

    public UpdateServiceCommandHandler(IServiceRepository serviceRepository, ICityRepository cityRepository)
    {
        _serviceRepository = serviceRepository;
        _cityRepository = cityRepository;
    }

    public async Task<ErrorOr<Unit>> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
    {
        if(await _cityRepository.GetCityByIdAsync(request.CityId) is null)
        {
            return Errors.CityNotFound;
        }

        if(await _serviceRepository.GetByIdAsync(request.ServiceId)
           is not Service service)
        {
            return Errors.ServiceNotFound;
        }
        
        var serviceResult = service.Update(
            request.CityId,
            request.Name,
            request.Description,
            request.LowerPriceBound,
            request.UpperPriceBound);

        if (serviceResult.IsError)
        {
            return serviceResult.Errors;
        }
        
        await _serviceRepository.UpdateAsync(serviceResult.Value);
        
        return Unit.Value;
    }
}