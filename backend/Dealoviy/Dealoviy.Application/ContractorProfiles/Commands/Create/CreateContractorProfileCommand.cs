using Dealoviy.Application.Common.Models;
using Dealoviy.Application.ContractorProfiles.Commands.Common.Interfaces;
using MediatR;
using ErrorOr;

namespace Dealoviy.Application.ContractorProfiles.Commands.Create;

public record CreateContractorProfileCommand(
    Guid UserId,
    string AdditionalInfo,
    List<ContactInfoModel> ContactInfos
    ) : IContractorProfileCommand,
    IRequest<ErrorOr<Unit>>;
