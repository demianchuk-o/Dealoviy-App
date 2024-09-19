using Dealoviy.Contracts.Orders;
using MediatR;
using ErrorOr;

namespace Dealoviy.Application.Orders.Queries.GetOrdersForService;

public record GetOrdersForServiceQuery(Guid ServiceId)
    : IRequest<ErrorOr<IEnumerable<ServiceOrderResponse>>>;