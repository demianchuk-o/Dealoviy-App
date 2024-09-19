using Dealoviy.Application.Authentication.Commands.Register;
using Dealoviy.Application.Authentication.Queries.Login;
using Dealoviy.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using MediatR;
using MapsterMapper;

namespace Dealoviy.WebApi.Controllers;

[AllowAnonymous]
[Route("api/auth")]
public class AuthenticationController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;
    public AuthenticationController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = _mapper.Map<RegisterCommand>(request);
        
        var result = await _mediator.Send(command);
        
        return result.Match(
            authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
            errors => Problem(errors));
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var command = _mapper.Map<LoginQuery>(request);
        
        var result = await _mediator.Send(command);
        
        return result.Match(
            authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
            errors => Problem(errors));
    }
}