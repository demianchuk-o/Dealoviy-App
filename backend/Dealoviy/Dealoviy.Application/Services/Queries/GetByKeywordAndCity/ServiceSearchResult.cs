using Dealoviy.Application.Services.Queries.Common;

namespace Dealoviy.Application.Services.Queries.GetByKeywordAndCity;

public record ServiceSearchResult(
    IEnumerable<ServiceResult> Services,
    int TotalCount,
    string Keyword,
    string CityName);