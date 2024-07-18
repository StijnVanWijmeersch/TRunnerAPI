using Microsoft.EntityFrameworkCore;
using TRunner.Domain.Badges;
using TRunner.Domain.Friendships;
using TRunner.Domain.Groups;
using TRunner.Domain.JoinTables;
using TRunner.Domain.Runs;
using TRunner.Domain.Users;

namespace TRunner.Infrastructure.Database;

internal sealed class TRunnerDbContext(DbContextOptions<TRunnerDbContext> options) : DbContext(options)
{
    internal DbSet<Run> Runs { get; set; }
    internal DbSet<User> Users { get; set; }
    internal DbSet<Friendship> Friendships { get; set; }
    internal DbSet<Badge> Badges { get; set; }
    internal DbSet<Group> Groups { get; set; }
    internal DbSet<UserBadge> UserBadges { get; set; }
    internal DbSet<UserGroup> UserGroups { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Infrastructure.AssemblyReference.Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
