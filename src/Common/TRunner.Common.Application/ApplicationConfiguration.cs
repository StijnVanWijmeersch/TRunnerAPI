﻿using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using TRunner.Common.Application.Behaviors;

namespace TRunner.Common.Application;
public static class ApplicationConfiguration
{

    public static IServiceCollection AddApplication(
        this IServiceCollection services,
        Assembly[] moduleAssemblies)
    {

        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssemblies(moduleAssemblies);
            config.AddOpenBehavior(typeof(RequestLoggingPipelineBehavior<,>));
        });

        return services;
    }
}
