using Dealoviy.Application.Common.Models;

namespace Dealoviy.Application.ContractorProfiles.Commands.Common.Interfaces;

public interface IContractorProfileCommand
{
    Guid UserId { get; }
    string AdditionalInfo { get; }
    List<ContactInfoModel> ContactInfos { get; }
}