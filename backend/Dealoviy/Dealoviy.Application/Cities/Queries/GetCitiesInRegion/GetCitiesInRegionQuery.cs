using Dealoviy.Application.Cities.Common;
using MediatR;

namespace Dealoviy.Application.Cities.Queries.GetCitiesInRegion;

public record GetCitiesInRegionQuery(Guid RegionId) 
    : IRequest<IEnumerable<CityResult>>;