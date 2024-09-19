using Dealoviy.Contracts.Requests;
using MediatR;
using ErrorOr;
namespace Dealoviy.Application.Requests.Queries.GetRequestsForService;

public record GetRequestsForServiceQuery(Guid ServiceId) 
    : IRequest<ErrorOr<IEnumerable<ServiceRequestResponse>>>;