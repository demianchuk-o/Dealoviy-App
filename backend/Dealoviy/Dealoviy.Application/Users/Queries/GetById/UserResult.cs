namespace Dealoviy.Application.Users.Queries.GetById;

public record UserResult(Guid UserId, string Username, string? DisplayName, Guid? ContractorProfileId);