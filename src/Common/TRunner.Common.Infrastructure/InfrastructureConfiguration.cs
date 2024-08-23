﻿using System.Data.Common;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using TRunner.Common.Application.Data;
using TRunner.Common.Infrastructure.Data;

namespace TRunner.Common.Infrastructure;

public static class InfrastructureConfiguration
{

    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string dbConnectionString)
    {
         DataSource    new SqmDa (dbConnectionString);

        services.TryAddSingleton(sqlDataSource);

        services.TryAddScoped<IDbConnectionFactory, DbConnectionFactory>();

        return services;
    }
}
