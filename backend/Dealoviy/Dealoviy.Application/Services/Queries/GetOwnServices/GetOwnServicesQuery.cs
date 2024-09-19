using Dealoviy.Contracts.Services;
using MediatR;
using ErrorOr;
namespace Dealoviy.Application.Services.Queries.GetOwnServices;

public record GetOwnServicesQuery(Guid UserId) : IRequest<ErrorOr<IEnumerable<ServiceResponse>>>;