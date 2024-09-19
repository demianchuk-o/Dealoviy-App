using Dealoviy.Application.Common.Models;
using Dealoviy.Application.Requests.Commands.AcceptRequest;
using Dealoviy.Application.Requests.Commands.Create;
using Dealoviy.Application.Requests.Commands.DeclineRequest;
using Dealoviy.Application.Requests.Commands.DeleteIfDeclined;
using Dealoviy.Application.Requests.Queries.GetRequestsForService;
using Dealoviy.Application.Requests.Queries.GetRequestsForUser;
using Dealoviy.Contracts.Requests;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dealoviy.WebApi.Controllers;

[Route("api")]
public class RequestsController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public RequestsController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("services/{serviceId:guid}/requests")]
    public async Task<IActionResult> GetRequestsForService(
        [FromRoute] Guid serviceId)
    {
        var query = new GetRequestsForServiceQuery(serviceId);
        var result = await _mediator.Send(query);
        return result.Match<IActionResult>(
            success => Ok(success),
            error => Problem(error)
        );
    }
    
    [HttpPost("requests/{requestId:guid}/accept")]
    public async Task<IActionResult> AcceptRequest(
        [FromRoute] Guid requestId)
    {
        var userId = GetUserId();
        var command = new AcceptRequestCommand(requestId, userId);
        var result = await _mediator.Send(command);
        return result.Match<IActionResult>(
            success => Ok(),
            error => Problem(error)
        );
    }
    
    [HttpPost("requests/{requestId:guid}/decline")]
    public async Task<IActionResult> DeclineRequest(
        [FromRoute] Guid requestId)
    {
        var userId = GetUserId();
        var command = new DeclineRequestCommand(requestId, userId);
        var result = await _mediator.Send(command);
        return result.Match<IActionResult>(
            success => Ok(),
            error => Problem(error)
        );
    }
    
    [HttpDelete("requests/{requestId:guid}")]
    public async Task<IActionResult> DeleteRequest(
        [FromRoute] Guid requestId)
    {
        var userId = GetUserId();
        var command = new DeleteRequestIfDeclinedCommand(requestId, userId);
        var result = await _mediator.Send(command);
        return result.Match<IActionResult>(
            success => Ok(),
            error => Problem(error)
        );
    }

    [HttpGet("users/requests")]
    public async Task<IActionResult> GetUsersRequests()
    {
        var userId = GetUserId();
        var query = new GetRequestsForUserQuery(userId);
        var result = await _mediator.Send(query);
        return result.Match<IActionResult>(
            success => Ok(success),
            error => Problem(error)
        );
    }
    
    [HttpPost("services/{serviceId:guid}/requests")]
    public async Task<IActionResult> CreateRequest(
        [FromRoute] Guid serviceId,
        [FromBody] CreateRequestRequest request)
    {
        var userId = GetUserId();
        var command = new CreateRequestCommand(
            serviceId,
            userId,
            request.Description,
            _mapper.Map<ContactInfoModel>(request.CustomerContactInfo),
            request.PaymentAmount);
        
        var result = await _mediator.Send(command);
        return result.Match<IActionResult>(
            success => Ok(),
            error => Problem(error)
        );
    }
}