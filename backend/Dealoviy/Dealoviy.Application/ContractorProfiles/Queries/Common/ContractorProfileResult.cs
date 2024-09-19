namespace Dealoviy.Application.ContractorProfiles.Queries.Common;

public record ContractorProfileResult(
    Guid Id,
    string Name,
    string AdditionalInfo,
    string[] ContactTypes
    );