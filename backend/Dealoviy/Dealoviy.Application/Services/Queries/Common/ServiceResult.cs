namespace Dealoviy.Application.Services.Queries.Common;

public record ServiceResult(
    Guid ServiceId,
    Guid ContractorId,
    string Name,
    string CityName,
    string Description,
    int LowerPriceBound,
    int UpperPriceBound,
    double AverageRating,
    int ReviewsCount);