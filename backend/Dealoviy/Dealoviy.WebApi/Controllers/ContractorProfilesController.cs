using Dealoviy.Application.Common.Models;
using Dealoviy.Application.ContractorProfiles.Commands.Create;
using Dealoviy.Application.ContractorProfiles.Commands.Update;
using Dealoviy.Application.ContractorProfiles.Queries.GetById;
using Dealoviy.Contracts.ContractProfiles;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dealoviy.WebApi.Controllers;

[Route("api/contractor-profiles")]  
public class ContractorProfilesController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;
    
    public ContractorProfilesController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateContractorProfile(ContractProfileRequest request)
    {
        var userId = GetUserId();
        
        var command = new CreateContractorProfileCommand(
            userId,
            request.AdditionalInfo,
            _mapper.Map<List<ContactInfoModel>>(request.ContactInfos)
        );
        
        var result = await _mediator.Send(command);

        return result.Match<IActionResult>(
            success => Ok("Contractor profile created successfully"),
            error => Problem(error)
        );
    }
    
    [HttpGet("{contractorId:guid}")]
    public async Task<IActionResult> GetContractorProfile(Guid contractorId)
    {
        var query = new GetContractorProfileByIdQuery(contractorId);
        
        var result = await _mediator.Send(query);

        return result.Match<IActionResult>(
            success => Ok(_mapper.Map<ContractorProfileResponse>(success)),
            error => Problem(error)
        );
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateContractorProfile(ContractProfileRequest request)
    {
        var userId = GetUserId();
        
        var command = new UpdateContractorProfileCommand(
            userId,
            request.AdditionalInfo,
            _mapper.Map<List<ContactInfoModel>>(request.ContactInfos)
        );
        
        var result = await _mediator.Send(command);

        return result.Match<IActionResult>(
            success => Ok("Contractor profile updated successfully"),
            error => Problem(error)
        );
    }
}