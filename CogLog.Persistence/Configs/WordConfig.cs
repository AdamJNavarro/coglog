using CogLog.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CogLog.Persistence.Configs;

public class WordConfig : IEntityTypeConfiguration<Word>
{
    public void Configure(EntityTypeBuilder<Word> builder)
    {
        builder.Property(x => x.Id).UseIdentityColumn(1, 1);

        builder.HasIndex(x => x.Spelling).IsUnique();

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
