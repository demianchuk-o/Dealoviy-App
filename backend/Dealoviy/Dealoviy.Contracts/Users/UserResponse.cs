namespace Dealoviy.Contracts.Users;

public record UserResponse(
    Guid UserId,
    string Username,
    string? DisplayName,
    Guid? ContractorProfileId);