namespace Dealoviy.Application.Authentication.Common;

public record AuthenticationResult(
    Guid Id,
    string Username,
    string? DisplayName,
    string? ContractorProfileId,
    string Token);