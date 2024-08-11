using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using TRunner.Common.Application.Data;
using TRunner.Common.Infrastructure.Data;

namespace TRunner.Common.Infrastructure;

public static class InfrastructureConfiguration
{

    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string dbConnectionString)
    {
        var sqlConnection = new SqlConnection(dbConnectionString);

        services.TryAddSingleton(sqlConnection);

        services.TryAddScoped<IDbConnectionFactory, DbConnectionFactory>();

        return services;
    }
}
