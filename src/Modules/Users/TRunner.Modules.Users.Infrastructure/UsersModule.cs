using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TRunner.Common.Presentation.Endpoints;
using TRunner.Modules.Users.Application.Abstractions.Data;
using TRunner.Modules.Users.Domain.Users;
using TRunner.Modules.Users.Infrastructure.Database;
using TRunner.Modules.Users.Infrastructure.Users;

namespace TRunner.Modules.Users.Infrastructure;
public static class UsersModule
{
    public static IServiceCollection AddUsersModule(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddInfrastructure(configuration);
        services.AddEndpoints(Presentation.AssemblyReference.Assembly);
        return services;
    }

    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<UsersDbContext>((sp, options) =>
        {
            options.UseSqlServer(configuration.GetConnectionString("Database"), mssqlOptions =>
            {
                mssqlOptions.MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemas.Users);
                mssqlOptions.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
            });
        });

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<UsersDbContext>());
    }
}
