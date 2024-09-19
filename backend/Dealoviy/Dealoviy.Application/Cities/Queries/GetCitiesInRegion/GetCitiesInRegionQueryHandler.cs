using Dealoviy.Application.Cities.Common;
using Dealoviy.Application.Common.Interfaces.Persistence;
using MapsterMapper;
using MediatR;

namespace Dealoviy.Application.Cities.Queries.GetCitiesInRegion;

public class GetCitiesInRegionQueryHandler : IRequestHandler<GetCitiesInRegionQuery, IEnumerable<CityResult>>
{
    private readonly ICityRepository _cityRepository;
    private readonly IMapper _mapper;

    public GetCitiesInRegionQueryHandler(
        ICityRepository cityRepository, 
        IMapper mapper)
    {
        _cityRepository = cityRepository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<CityResult>> Handle(GetCitiesInRegionQuery request, CancellationToken cancellationToken)
    {
        var regions = await _cityRepository.GetCitiesByRegionIdAsync(request.RegionId);
        return _mapper.Map<IEnumerable<CityResult>>(regions);
    }
}