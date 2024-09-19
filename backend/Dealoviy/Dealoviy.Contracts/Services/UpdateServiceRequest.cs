namespace Dealoviy.Contracts.Services;

public record UpdateServiceRequest(
    Guid CityId,
    string Name,
    string Description,
    int LowerPriceBound,
    int UpperPriceBound);