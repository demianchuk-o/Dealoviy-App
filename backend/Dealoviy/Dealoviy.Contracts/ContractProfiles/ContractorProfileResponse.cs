namespace Dealoviy.Contracts.ContractProfiles;

public record ContractorProfileResponse(
    Guid Id,
    string Name,
    string AdditionalInfo,
    string[] ContactTypes
);