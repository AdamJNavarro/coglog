using CogLog.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CogLog.Persistence.Configs;

public class TopicConfig : IEntityTypeConfiguration<Topic>
{
    public void Configure(EntityTypeBuilder<Topic> builder)
    {
        builder.HasIndex(q => q.Title).IsUnique();

        builder.HasData(
            new Topic
            {
                Id = 1,
                Title = "Coding",
                Logo = "💻",
            },
            new Topic
            {
                Id = 2,
                Title = "Japanese",
                Logo = "🇯🇵",
            },
            new Topic
            {
                Id = 3,
                Title = "Words",
                Logo = "📖",
            }
        );
    }
}
