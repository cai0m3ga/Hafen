using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Hafen.Application.Common.Interfaces.Persistence;
using Hafen.Infrastructure.Persistence;

namespace Hafen.Infrastructure;

public static class DependencyInjection
{

    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {

        services.AddScoped<IShipRepository, ShipRepository>();

        return services;

    }    

}