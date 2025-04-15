using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vonavulary.Domain;

namespace Vonavulary.Persistence.Configs;

public class WordConfig : IEntityTypeConfiguration<Word>
{
    public void Configure(EntityTypeBuilder<Word> builder)
    {
        builder.Property(b => b.Id).HasIdentityOptions(startValue: 280);
        builder.HasIndex(x => x.Spelling).IsUnique();

        builder.Property(x => x.CreatedAt).HasColumnType("timestamptz");
        builder.Property(x => x.UpdatedAt).HasColumnType("timestamptz");
        builder.Property(x => x.LearnedAt).HasColumnType("timestamptz");

        builder
            .Property(w => w.Language)
            .HasConversion(
                v => v.ToString().ToLowerInvariant(),
                v => (Language)Enum.Parse(typeof(Language), v, true)
            );

        builder
            .Property(w => w.PartOfSpeech)
            .HasConversion(
                v => v.ToString()!.ToLowerInvariant(),
                v => (PartOfSpeech)Enum.Parse(typeof(PartOfSpeech), v, true)
            );
    }
}
