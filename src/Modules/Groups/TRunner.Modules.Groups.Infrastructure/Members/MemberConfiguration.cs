using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TRunner.Modules.Groups.Domain.Groups;
using TRunner.Modules.Groups.Domain.Runners;

namespace TRunner.Modules.Groups.Infrastructure.Members;
internal class MemberConfiguration : IEntityTypeConfiguration<Member>
{
    public void Configure(EntityTypeBuilder<Member> builder)
    {
        builder.ToTable("Members");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.Id)
            .ValueGeneratedNever();

        builder.Property(m => m.UserName)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(m => m.Score)
            .IsRequired();

        builder
            .HasMany<Group>()
            .WithMany(g => g.Members)
            .UsingEntity(joinBuilder =>
            {
                joinBuilder.ToTable("GroupMembers");
                joinBuilder.Property("MembersId").HasColumnName("MemberId");
            });

    }
}
