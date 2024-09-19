using Dealoviy.Application.ContractorProfiles.Queries.Common;
using MediatR;
using ErrorOr;

namespace Dealoviy.Application.ContractorProfiles.Queries.GetById;

public record GetContractorProfileByIdQuery(Guid Id) 
    : IRequest<ErrorOr<ContractorProfileResult>>;