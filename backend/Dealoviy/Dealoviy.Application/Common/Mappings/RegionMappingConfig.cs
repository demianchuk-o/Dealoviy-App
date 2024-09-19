using Dealoviy.Application.Regions.Common;
using Dealoviy.Domain.Common.Location;
using Mapster;

namespace Dealoviy.Application.Common.Mappings;

public class RegionMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Region, RegionResult>();
    }
}