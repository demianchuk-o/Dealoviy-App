using MediatR;
using ErrorOr;

namespace Dealoviy.Application.Services.Queries.GetByKeywordAndCity;

public record GetByKeywordAndCityQuery(
    string Keyword, 
    Guid CityId) : IRequest<ErrorOr<ServiceSearchResult>>;