using Dealoviy.Contracts.Orders;
using MediatR;
using ErrorOr;

namespace Dealoviy.Application.Orders.Queries.GetOrdersForUser;

public record GetOrdersForUserQuery(Guid UserId) 
    : IRequest<ErrorOr<IEnumerable<UserOrderResponse>>>;