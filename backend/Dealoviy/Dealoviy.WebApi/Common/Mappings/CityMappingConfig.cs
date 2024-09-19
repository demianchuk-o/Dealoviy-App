using Dealoviy.Application.Cities.Common;
using Dealoviy.Contracts.Cities;
using Mapster;

namespace Dealoviy.WebApi.Common.Mappings;

public class CityMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CityResult, CityResponse>();
    }
}