using Dealoviy.Application.Cities.Queries.GetCitiesInRegion;
using Dealoviy.Contracts.Cities;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dealoviy.WebApi.Controllers;

[AllowAnonymous]
[Route("api/[controller]")]
public class CitiesController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;
    
    public CitiesController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("{regionId:guid}")]
    public async Task<IActionResult> GetCitiesInRegion(Guid regionId)
    {
        var query = new GetCitiesInRegionQuery(regionId);
        var cities = await _mediator.Send(query);

        return Ok(_mapper.Map<IEnumerable<CityResponse>>(cities));
    }
}