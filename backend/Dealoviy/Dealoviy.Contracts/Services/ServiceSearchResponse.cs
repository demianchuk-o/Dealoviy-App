namespace Dealoviy.Contracts.Services;

public record ServiceSearchResponse(
    IEnumerable<ServiceResponse> Services,
    int TotalCount,
    string Keyword,
    string CityName);