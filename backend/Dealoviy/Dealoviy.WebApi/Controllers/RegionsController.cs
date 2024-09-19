using Dealoviy.Application.Regions.Queries.GetRegion;
using Dealoviy.Contracts.Regions;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dealoviy.WebApi.Controllers;
[AllowAnonymous]
[Route("api/[controller]")]
public class RegionsController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;
    
    public RegionsController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetRegions()
    {
        var query = new GetRegionsQuery();
        var regions = await _mediator.Send(query);

        return Ok(_mapper.Map<IEnumerable<RegionResponse>>(regions));
    }
}