using Dealoviy.Application.ContractorProfiles.Queries.Common;
using Dealoviy.Contracts.ContractProfiles;
using Mapster;

namespace Dealoviy.WebApi.Common.Mappings;

public class ContractorProfileConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<ContractorProfileResult, ContractorProfileResponse>();
    }
}