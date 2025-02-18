using CogLog.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CogLog.Persistence.Configs;

public class BrainBlockTagConfig : IEntityTypeConfiguration<BrainBlockTag>
{
    public void Configure(EntityTypeBuilder<BrainBlockTag> builder)
    {
        builder.HasKey(bt => new { bt.BrainBlockId, bt.TagId });

        builder
            .HasOne(bt => bt.BrainBlock)
            .WithMany(bt => bt.BrainBlockTags)
            .HasForeignKey(bt => bt.BrainBlockId);

        builder
            .HasOne(bt => bt.Tag)
            .WithMany(bt => bt.BrainBlockTags)
            .HasForeignKey(bt => bt.TagId);

        builder.ToTable("BrainBlockTags");
    }
}
