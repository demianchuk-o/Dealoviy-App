using Dealoviy.Application.Common.Interfaces.Persistence;
using Dealoviy.Application.Services.Queries.Common;
using Dealoviy.Domain.Common.Errors;
using Dealoviy.Domain.Common.Location;
using MediatR;
using ErrorOr;
using MapsterMapper;

namespace Dealoviy.Application.Services.Queries.GetByKeywordAndCity;

public class GetByKeywordAndCityQueryHandler
    : IRequestHandler<GetByKeywordAndCityQuery, ErrorOr<ServiceSearchResult>>
{
    private readonly IServiceRepository _serviceRepository;
    private readonly ICityRepository _cityRepository;
    private readonly IMapper _mapper;

    public GetByKeywordAndCityQueryHandler(
        IServiceRepository serviceRepository, 
        ICityRepository cityRepository, 
        IMapper mapper)
    {
        _serviceRepository = serviceRepository;
        _cityRepository = cityRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<ServiceSearchResult>> Handle(
        GetByKeywordAndCityQuery request, 
        CancellationToken cancellationToken)
    {
        if(await _cityRepository.GetCityByIdAsync(request.CityId) is not City city)
        {
            return Errors.CityNotFound;
        }
        
        var services = await _serviceRepository
            .GetByKeywordAndCityAsync(request.Keyword, request.CityId);

        var serviceResults = services.Select(service =>
            _mapper.Map<ServiceResult>((service, city.Name)))
            .OrderByDescending(s => s.AverageRating)  
            .ToList();


        return new ServiceSearchResult(
            serviceResults,
            serviceResults.Count,
            request.Keyword,
            city.Name);

    }
}