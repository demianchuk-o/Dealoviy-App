using Dealoviy.Application.Common.Interfaces.Persistence;
using Dealoviy.Application.Regions.Common;
using MapsterMapper;
using MediatR;

namespace Dealoviy.Application.Regions.Queries.GetRegion;

public class GetRegionQueryHandler : IRequestHandler<GetRegionsQuery, IEnumerable<RegionResult>>
{
    private readonly IRegionRepository _regionRepository;
    private readonly IMapper _mapper;

    public GetRegionQueryHandler(
        IRegionRepository regionRepository, 
        IMapper mapper)
    {
        _regionRepository = regionRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<RegionResult>> Handle(GetRegionsQuery request, CancellationToken cancellationToken)
    {
        var regions = await _regionRepository.GetAllRegionsAsync();
        return _mapper.Map<IEnumerable<RegionResult>>(regions);
    }
}