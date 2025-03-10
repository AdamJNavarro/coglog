using CogLog.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CogLog.Persistence.Configs;

public class SubjectConfig : IEntityTypeConfiguration<Subject>
{
    public void Configure(EntityTypeBuilder<Subject> builder)
    {
        builder.HasIndex(s => s.Name).IsUnique();

        // Subject-Block 1-N
        builder
            .HasMany(s => s.Blocks)
            .WithOne(b => b.Subject)
            .HasForeignKey(b => b.SubjectId)
            .OnDelete(DeleteBehavior.NoAction);

        // Subject-Topic 1-N
        builder
            .HasMany(s => s.Topics)
            .WithOne(t => t.Subject)
            .HasForeignKey(t => t.SubjectId)
            .OnDelete(DeleteBehavior.Cascade);

        // Subject-Tag 1-N
        builder
            .HasMany(s => s.Tags)
            .WithOne(t => t.Subject)
            .HasForeignKey(t => t.SubjectId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
