using Microsoft.EntityFrameworkCore;
using TRunner.Modules.Groups.Application.Abstractions;
using TRunner.Modules.Groups.Domain.Groups;
using TRunner.Modules.Groups.Domain.Invites;
using TRunner.Modules.Groups.Domain.JoinTables;
using TRunner.Modules.Groups.Domain.Runners;

namespace TRunner.Modules.Groups.Infrastructure.Database;
public sealed class GroupsDbContext(DbContextOptions<GroupsDbContext> options) : DbContext(options), IUnitOfWork
{
    internal DbSet<Group> Groups { get; set; }
    internal DbSet<Runner> Runners { get; set; }
    internal DbSet<Invite> Invites { get; set; }
    internal DbSet<RunnerGroup> RunnersGroup { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schemas.Groups);
    }
}
