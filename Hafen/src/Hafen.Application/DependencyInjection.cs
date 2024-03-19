using Microsoft.Extensions.DependencyInjection;
using MediatR;
using Hafen.Application.Common.Behaviors;
using FluentValidation;
using System.Reflection;

namespace Hafen.Application;

public static class DependencyInjection
{

    public static IServiceCollection AddApplication(this IServiceCollection services)
    {

        services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;

    }

}