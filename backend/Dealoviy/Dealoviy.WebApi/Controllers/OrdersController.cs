using Dealoviy.Application.Orders.Commands.UpdateStatus;
using Dealoviy.Application.Orders.Queries.GetOrdersForService;
using Dealoviy.Application.Orders.Queries.GetOrdersForUser;
using Dealoviy.Domain.Orders;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dealoviy.WebApi.Controllers;

[Route("api")]
public class OrdersController : ApiController
{
    private readonly ISender _mediator;

    public OrdersController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("services/{serviceId:guid}/orders")]
    public async Task<IActionResult> GetOrdersForService(
        [FromRoute] Guid serviceId)
    {
        var query = new GetOrdersForServiceQuery(serviceId);
        var result = await _mediator.Send(query);
        
        return result.Match<IActionResult>(
            success => Ok(success),
            error => Problem(error)
        );
    }
    
    [HttpPost("orders/{orderId:guid}/start")]
    public async Task<IActionResult> StartOrder(
        [FromRoute] Guid orderId)
    {
        var userId = GetUserId();
        var command = new UpdateOrderStatusCommand(orderId, userId, OrderStatus.InProgress);
        
        var result = await _mediator.Send(command);

        return result.Match<IActionResult>(
            success => Ok("Order started"),
            error => Problem(error));
    }
    
    [HttpPost("orders/{orderId:guid}/finish")]
    public async Task<IActionResult> FinishOrder(
        [FromRoute] Guid orderId)
    {
        var userId = GetUserId();
        var command = new UpdateOrderStatusCommand(orderId, userId, OrderStatus.Finished);
        
        var result = await _mediator.Send(command);
        
        return result.Match<IActionResult>(
            success => Ok("Order finished"),
            error => Problem(error));
    }
    
    [HttpGet("users/orders")]
    public async Task<IActionResult> GetOrdersForUser()
    {
        var userId = GetUserId();
        var query = new GetOrdersForUserQuery(userId);
        var result = await _mediator.Send(query);
        
        return result.Match<IActionResult>(
            success => Ok(success),
            error => Problem(error)
        );
    }
}