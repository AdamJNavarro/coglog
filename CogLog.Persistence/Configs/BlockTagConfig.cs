using CogLog.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CogLog.Persistence.Configs;

public class BlockTagConfig : IEntityTypeConfiguration<BlockTag>
{
    public void Configure(EntityTypeBuilder<BlockTag> builder)
    {
        builder.HasKey(bt => new { bt.BlockId, bt.TagId });

        builder.HasOne(bt => bt.Block).WithMany(bt => bt.BlockTags).HasForeignKey(bt => bt.BlockId);

        builder.HasOne(bt => bt.Tag).WithMany(bt => bt.BlockTags).HasForeignKey(bt => bt.TagId);

        builder.ToTable("BlockTags");
    }
}
