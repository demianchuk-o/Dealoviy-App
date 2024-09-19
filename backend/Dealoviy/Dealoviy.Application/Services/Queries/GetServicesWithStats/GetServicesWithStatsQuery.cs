using Dealoviy.Contracts.Services;
using MediatR;
using ErrorOr;
namespace Dealoviy.Application.Services.Queries.GetServicesWithStats;

public record GetServicesWithStatsQuery(Guid UserId)
    : IRequest<ErrorOr<IEnumerable<ServiceTaskStatResponse>>>;