using Hafen.Api.Common.Mapping;
using Hafen.Api.Filters;

namespace Hafen.Api;

public static class DependencyInjection
{

    public static IServiceCollection AddPresentation(
        this IServiceCollection services)
    {

        services.AddMappings();
        services.AddControllers(
            options => options.Filters.Add<ErrorHandlingFilterAttribute>()
        );

        return services;

    }

}