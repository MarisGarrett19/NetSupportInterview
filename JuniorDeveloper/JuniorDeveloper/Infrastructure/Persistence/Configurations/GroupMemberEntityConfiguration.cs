using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class GroupMemberEntityConfiguration : IEntityTypeConfiguration<GroupMember>
{
    public void Configure(EntityTypeBuilder<GroupMember> builder)
    {
        builder.HasKey(m => m.Id);

        builder
            .Property(m => m.Start)
            .IsRequired();

        builder
            .Property(m => m.End)
            .IsRequired();

        builder
            .HasOne(m => m.User)
            .WithMany()
            .HasForeignKey(m => m.UserId)
            .IsRequired();
    }
}