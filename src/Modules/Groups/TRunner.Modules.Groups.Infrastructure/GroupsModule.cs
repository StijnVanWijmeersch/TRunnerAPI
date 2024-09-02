using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TRunner.Common.Presentation.Endpoints;
using TRunner.Modules.Groups.Application.Abstractions;
using TRunner.Modules.Groups.Domain.Groups;
using TRunner.Modules.Groups.Domain.Runners;
using TRunner.Modules.Groups.Infrastructure.Database;
using TRunner.Modules.Groups.Infrastructure.Groups;
using TRunner.Modules.Groups.Infrastructure.Runners;

namespace TRunner.Modules.Groups.Infrastructure;
public static class GroupsModule
{
    public static IServiceCollection AddGroupsModule(
        this IServiceCollection services,
        IConfiguration configuration)
    {

        services.AddInfrastructure(configuration);

        services.AddEndpoints(Presentation.AssemblyReference.Assembly);

        return services;

    }

    private static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<GroupsDbContext>((sp, options) =>
        {
            options.UseSqlServer(configuration.GetConnectionString("Database"), mssqlOptions =>
            {
                mssqlOptions.MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemas.Groups);
            });
        });

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<GroupsDbContext>());

        services.AddScoped<IGroupRepository, GroupRepository>();
        services.AddScoped<IMemberRepository, MemberRepository>();
    }
}
