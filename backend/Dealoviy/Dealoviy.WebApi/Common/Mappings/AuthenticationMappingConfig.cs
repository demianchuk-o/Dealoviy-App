using Dealoviy.Application.Authentication.Commands.Register;
using Dealoviy.Application.Authentication.Common;
using Dealoviy.Application.Authentication.Queries.Login;
using Dealoviy.Contracts.Authentication;
using Mapster;

namespace Dealoviy.WebApi.Common.Mappings;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();
        config.NewConfig<LoginRequest, LoginQuery>();
        
        config.NewConfig<AuthenticationResult, AuthenticationResponse>();
    }
}