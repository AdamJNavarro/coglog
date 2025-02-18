using CogLog.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CogLog.Persistence.Configs;

public class BrainBlockTopicConfig : IEntityTypeConfiguration<BrainBlockTopic>
{
    public void Configure(EntityTypeBuilder<BrainBlockTopic> builder)
    {
        builder.HasKey(bt => new { bt.BrainBlockId, bt.TopicId });

        builder
            .HasOne(bt => bt.BrainBlock)
            .WithMany(bt => bt.BrainBlockTopics)
            .HasForeignKey(bt => bt.BrainBlockId);

        builder
            .HasOne(bt => bt.Topic)
            .WithMany(bt => bt.BrainBlockTopics)
            .HasForeignKey(bt => bt.TopicId);

        builder.ToTable("BrainBlockTopics");
    }
}
