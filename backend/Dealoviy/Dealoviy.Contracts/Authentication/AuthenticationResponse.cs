namespace Dealoviy.Contracts.Authentication;

public record AuthenticationResponse(
    Guid Id,
    string Username,
    string? DisplayName,
    string? ContractorProfileId,
    string Token);