using Dealoviy.Domain.Orders;
using MediatR;
using ErrorOr;

namespace Dealoviy.Application.Orders.Commands.UpdateStatus;

public record UpdateOrderStatusCommand(Guid OrderId, Guid UserContractorId, OrderStatus Status) 
    : IRequest<ErrorOr<Unit>>;