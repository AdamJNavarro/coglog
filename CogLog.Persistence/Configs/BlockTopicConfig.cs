using CogLog.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CogLog.Persistence.Configs;

public class BlockTopicConfig : IEntityTypeConfiguration<BlockTopic>
{
    public void Configure(EntityTypeBuilder<BlockTopic> builder)
    {
        builder.HasKey(bt => new { bt.BlockId, bt.TopicId });

        builder
            .HasOne(bt => bt.Block)
            .WithMany(bt => bt.BlockTopics)
            .HasForeignKey(bt => bt.BlockId);

        builder
            .HasOne(bt => bt.Topic)
            .WithMany(bt => bt.BlockTopics)
            .HasForeignKey(bt => bt.TopicId);

        builder.ToTable("BlockTopics");
    }
}
