namespace Dealoviy.Contracts.Services;

public record CreateServiceRequest(
    Guid CityId,
    string Name,
    string Description,
    int LowerPriceBound,
    int UpperPriceBound);