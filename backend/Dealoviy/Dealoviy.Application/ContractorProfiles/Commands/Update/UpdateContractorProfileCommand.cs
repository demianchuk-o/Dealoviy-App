using Dealoviy.Application.Common.Models;
using Dealoviy.Application.ContractorProfiles.Commands.Common.Interfaces;
using MediatR;
using ErrorOr;

namespace Dealoviy.Application.ContractorProfiles.Commands.Update;

public record UpdateContractorProfileCommand(
    Guid UserId,
    string AdditionalInfo,
    List<ContactInfoModel> ContactInfos
) : IContractorProfileCommand,
    IRequest<ErrorOr<Unit>>;