using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class GroupEntityConfiguration : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.HasKey(m => m.Id);

        builder
            .Property(m => m.Name)
            .IsRequired();

        builder
            .HasMany(m => m.Members)
            .WithOne()
            .HasForeignKey(m => m.GroupId)
            .IsRequired();
    }
}
