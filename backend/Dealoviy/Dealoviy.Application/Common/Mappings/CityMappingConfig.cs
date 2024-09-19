using Dealoviy.Application.Cities.Common;
using Dealoviy.Domain.Common.Location;
using Mapster;

namespace Dealoviy.Application.Common.Mappings;

public class CityMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<City, CityResult>();
    }
}