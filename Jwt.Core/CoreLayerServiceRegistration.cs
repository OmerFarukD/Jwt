using Jwt.Core.Security.JWT;
using Microsoft.Extensions.DependencyInjection;

namespace Jwt.Core;

public static class CoreLayerServiceRegistration
{
    public static IServiceCollection AddCoreDependencies(this IServiceCollection services)
    {
        services.AddScoped<ITokenHelper, JwtHelper>();
        return services;
    }
}