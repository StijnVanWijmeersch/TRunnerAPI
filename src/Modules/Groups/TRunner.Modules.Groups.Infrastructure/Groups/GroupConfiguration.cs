using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TRunner.Modules.Groups.Domain.Groups;

namespace TRunner.Modules.Groups.Infrastructure.Groups;
internal sealed class GroupConfiguration : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.HasKey(g => g.Id);

        builder.Property(g => g.Id)
            .ValueGeneratedNever();

        builder.Property(g => g.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.HasIndex(g => g.Name)
            .IsUnique();

        builder.Property(g => g.Description)
            .HasMaxLength(255)
            .IsRequired(false);

        builder.Property(g => g.Size)
            .IsRequired();

        builder.Property(g => g.OwnerId)
            .IsRequired();

        builder.Property(g => g.Status)
            .IsRequired();
    }
}
