using Dealoviy.Application.Services.Queries.GetOwnServices;
using Dealoviy.Application.Services.Queries.GetServicesWithStats;
using Dealoviy.Application.Users.Queries.GetById;
using Dealoviy.Contracts.Services;
using Dealoviy.Contracts.Users;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dealoviy.WebApi.Controllers;

[Route("api")]
public class UsersController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;
    
    public UsersController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    
    
    
    [HttpPatch]
    public async Task<IActionResult> UpdateUser([FromBody] UpdateUserRequest request)
    {
        await Task.CompletedTask;
        return Ok("User updated successfully");
    }

    [HttpGet("services")]
    public async Task<IActionResult> GetOwnServices()
    {
        var userId = GetUserId();
        var query = new GetOwnServicesQuery(userId);
        var result = await _mediator.Send(query);
        
        return result.Match<IActionResult>(
            success => Ok(success),
            error => Problem(error)
        );
    }

    [HttpGet("serviceStats")]
    public async Task<IActionResult> GetServiceStats()
    {
        var userId = GetUserId();
        var query = new GetServicesWithStatsQuery(userId);
        var result = await _mediator.Send(query);
        
        return result.Match<IActionResult>(
            success => Ok(_mapper.Map<IEnumerable<ServiceTaskStatResponse>>(success)),
            error => Problem(error)
        );
    }

    [HttpGet]
    public async Task<IActionResult> GetUser()
    {
        await Task.CompletedTask;
        var userId = GetUserId();
        
        var query = new GetUserByIdQuery(userId);
        var result = await _mediator.Send(query);
        
        return result.Match<IActionResult>(
            success => Ok(success.Adapt<UserResponse>()),
            error => Problem(error)
        );
    }
}