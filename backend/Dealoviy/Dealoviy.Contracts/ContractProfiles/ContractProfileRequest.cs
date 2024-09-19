using Dealoviy.Contracts.Common;

namespace Dealoviy.Contracts.ContractProfiles;

public record ContractProfileRequest(
    string AdditionalInfo,
    List<ContactInfoRequest> ContactInfos
    );