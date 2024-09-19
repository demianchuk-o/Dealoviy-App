using Dealoviy.Application.Common.Interfaces.Persistence;
using Dealoviy.Application.Services.Queries.Common;
using Dealoviy.Domain.Common.Errors;
using Dealoviy.Domain.Common.Location;
using Dealoviy.Domain.Services;
using MediatR;
using ErrorOr;
using MapsterMapper;

namespace Dealoviy.Application.Services.Queries.GetById;

public class GetServiceByIdQueryHandler
    : IRequestHandler<GetServiceByIdQuery, ErrorOr<ServiceResult>>
{
    private readonly IServiceRepository _serviceRepository;
    private readonly ICityRepository _cityRepository;
    private readonly IMapper _mapper;

    public GetServiceByIdQueryHandler(
        IServiceRepository serviceRepository, 
        ICityRepository cityRepository, 
        IMapper mapper)
    {
        _serviceRepository = serviceRepository;
        _cityRepository = cityRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<ServiceResult>> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
    {
        if (await _serviceRepository.GetByIdAsync(request.Id)
            is not Service service)
        {
            return Errors.ServiceNotFound;
        }
        
        if (await _cityRepository.GetCityByIdAsync(service.CityId)
            is not City city)
        {
            return Errors.CityNotFound;
        }
        
        return _mapper.Map<ServiceResult>((service, city.Name));
    }
}