using Microsoft.EntityFrameworkCore;
using TRunner.Modules.Users.Application.Abstractions.Data;
using TRunner.Modules.Users.Domain.Users;
using TRunner.Modules.Users.Infrastructure.Users;

namespace TRunner.Modules.Users.Infrastructure.Database;
internal class UsersDbContext(DbContextOptions<UsersDbContext> options) : DbContext(options), IUnitOfWork
{
    internal DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schemas.Users);

        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new RoleConfiguration());
    }

}
