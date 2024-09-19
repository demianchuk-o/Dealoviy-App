using Dealoviy.Application.Reviews.Commands.AddReviewOnService;
using Dealoviy.Application.Reviews.Queries.GetReviewsForService;
using Dealoviy.Application.Services.Commands.Create;
using Dealoviy.Application.Services.Commands.Update;
using Dealoviy.Application.Services.Queries.GetById;
using Dealoviy.Application.Services.Queries.GetByKeywordAndCity;
using Dealoviy.Contracts.Reviews;
using Dealoviy.Contracts.Services;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dealoviy.WebApi.Controllers;

[Route("api/[controller]")]
public class ServicesController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public ServicesController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> CreateService(CreateServiceRequest request)
    {
        var userId = GetUserId();

        var command = new CreateServiceCommand(
            userId,
            request.CityId,
            request.Name,
            request.Description,
            request.LowerPriceBound,
            request.UpperPriceBound
        );

        var result = await _mediator.Send(command);

        return result.Match<IActionResult>(
            success => Ok("Service created successfully"),
            error => Problem(error)
        );
    }

    [HttpPut("{serviceId:guid}")]
    public async Task<IActionResult> UpdateService(Guid serviceId, UpdateServiceRequest request)
    {
        var userId = GetUserId();

        var command = new UpdateServiceCommand(
            serviceId,
            request.CityId,
            request.Name,
            request.Description,
            request.LowerPriceBound,
            request.UpperPriceBound
        );

        var result = await _mediator.Send(command);

        return result.Match<IActionResult>(
            success => Ok("Service updated successfully"),
            error => Problem(error)
        );
    }

    [HttpGet("search")]
    public async Task<IActionResult> GetServicesByKeywordAndCity(
        [FromQuery] string keyword,
        [FromQuery] Guid cityId)
    {
        var query = new GetByKeywordAndCityQuery(keyword, cityId);

        var result = await _mediator.Send(query);

        return result.Match<IActionResult>(
            success => Ok(_mapper.Map<ServiceSearchResponse>(success)),
            error => Problem(error)
        );
    }

    [HttpGet("{serviceId:guid}")]
    public async Task<IActionResult> GetService(Guid serviceId)
    {
        var query = new GetServiceByIdQuery(serviceId);

        var result = await _mediator.Send(query);

        return result.Match<IActionResult>(
            success => Ok(success.Adapt<ServiceResponse>()),
            error => Problem(error)
        );
    }

    [HttpPost("{serviceId:guid}/reviews")]
    public async Task<IActionResult> CreateReview(
        [FromRoute] Guid serviceId,
        [FromBody] CreateReviewRequest request)
    {
        var userId = GetUserId();

        var command = new AddReviewOnServiceCommand(
            serviceId,
            userId,
            request.Rating,
            request.ReviewText
        );

        var result = await _mediator.Send(command);

        return result.Match<IActionResult>(
            success => Ok("Review created successfully"),
            error => Problem(error)
        );
    }
    
    [HttpGet("{serviceId:guid}/reviews")]
    public async Task<IActionResult> GetReviewsForService([FromRoute] Guid serviceId)
    {
        var query = new GetReviewsForServiceQuery(serviceId);

        var result = await _mediator.Send(query);

        return result.Match<IActionResult>(
            success => Ok(success.Adapt<IEnumerable<ReviewResponse>>()),
            error => Problem(error)
        );
    }
}