using Dealoviy.Application.Common.Models;
using Dealoviy.Domain.Common.ContactInfo;
using Mapster;

namespace Dealoviy.Application.Common.Mappings;

public class ContactInfoMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<ContactInfoModel, ContactInfoCreateModel>();
    }
}