namespace Dealoviy.Contracts.Authentication;

public record RegisterRequest(
    string Username,
    string? DisplayName,
    string Password);
    