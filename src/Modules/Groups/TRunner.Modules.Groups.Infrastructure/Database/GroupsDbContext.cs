using Microsoft.EntityFrameworkCore;
using TRunner.Modules.Groups.Application.Abstractions;
using TRunner.Modules.Groups.Domain.Groups;
using TRunner.Modules.Groups.Domain.Runners;
using TRunner.Modules.Groups.Infrastructure.Groups;
using TRunner.Modules.Groups.Infrastructure.Members;

namespace TRunner.Modules.Groups.Infrastructure.Database;
public sealed class GroupsDbContext(DbContextOptions<GroupsDbContext> options) : DbContext(options), IUnitOfWork
{
    internal DbSet<Group> Groups { get; set; }
    internal DbSet<Member> Members { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schemas.Groups);

        modelBuilder.ApplyConfiguration(new GroupConfiguration());
        modelBuilder.ApplyConfiguration(new MemberConfiguration());
    }
}
