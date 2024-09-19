using Dealoviy.Application.Regions.Common;
using MediatR;

namespace Dealoviy.Application.Regions.Queries.GetRegion;

public record GetRegionsQuery() : IRequest<IEnumerable<RegionResult>>;