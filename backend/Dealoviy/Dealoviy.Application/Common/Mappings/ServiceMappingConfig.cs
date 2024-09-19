using Dealoviy.Application.Services.Queries.Common;
using Dealoviy.Domain.Services;
using Mapster;

namespace Dealoviy.Application.Common.Mappings;

public class ServiceMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(Service service, string CityName), ServiceResult>()
            .Map(dest => dest.ServiceId, src => src.service.Id)
            .Map(dest => dest.ContractorId, src => src.service.ContractorId)
            .Map(dest => dest.Name, src => src.service.Name)
            .Map(dest => dest.CityName, src => src.CityName)
            .Map(dest => dest.Description, src => src.service.Description)
            .Map(dest => dest.LowerPriceBound, src => src.service.PriceRange.Lower)
            .Map(dest => dest.UpperPriceBound, src => src.service.PriceRange.Upper)
            .Map(dest => dest.AverageRating, src => src.service.AverageRating.Value)
            .Map(dest => dest.ReviewsCount, src => src.service.AverageRating.Count);
    }
}