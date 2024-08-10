using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TRunner.Modules.Users.Domain.Users;

namespace TRunner.Modules.Users.Infrastructure.Users;
internal sealed class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Roles");

        builder.HasKey(r => r.Name);

        builder.Property(r => r.Name)
            .HasMaxLength(50)
            .IsRequired();

        builder
            .HasMany<User>()
            .WithMany(u => u.Roles)
            .UsingEntity(joinBuilder =>
            {
                joinBuilder.ToTable("UserRoles");
                joinBuilder.Property("RolesName").HasColumnName("RoleName");
            });

        builder.HasData(
            Role.User,
            Role.Administator);
    }
}
