using Dealoviy.Application.Services.Queries.GetByKeywordAndCity;
using Dealoviy.Contracts.Services;
using Mapster;

namespace Dealoviy.WebApi.Common.Mappings;

public class ServiceSearchMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<ServiceSearchResult, ServiceSearchResponse>()
            .Map(dest => dest.Services, src 
                => src.Services.Select(service => service.Adapt<ServiceResponse>()))
            .Map(dest => dest, src => src);
    }
}