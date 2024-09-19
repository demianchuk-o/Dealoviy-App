namespace Dealoviy.Contracts.Services;

public record ServiceResponse(
    Guid ServiceId,
    Guid ContractorId,
    string Name,
    string CityName,
    string Description,
    int LowerPriceBound,
    int UpperPriceBound,
    double AverageRating,
    int ReviewsCount);