using Dealoviy.Application.Regions.Common;
using Dealoviy.Contracts.Regions;
using Mapster;

namespace Dealoviy.WebApi.Common.Mappings;

public class RegionMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegionResult, RegionResponse>();
    }
}