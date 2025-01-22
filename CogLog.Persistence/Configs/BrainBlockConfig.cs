using CogLog.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CogLog.Persistence.Configs;

public class BrainBlockConfig : IEntityTypeConfiguration<BrainBlock>
{
    public void Configure(EntityTypeBuilder<BrainBlock> builder)
    {
        builder.Property(x => x.Id).UseIdentityColumn(1, 1);

        builder.HasData(
            new BrainBlock
            {
                Id = 1,
                Title = "Rubicund",
                Content = "having a rosy complexion of the face.",
                AdditionalContext = "adjective",
                DateAdded = new DateTime(2024, 11, 5, 7, 30, 0),
                Variant = BrainBlockVariantEnum.Learning,
            },
            new BrainBlock
            {
                Id = 2,
                Title = "Erudite",
                Content = "having or showing great knowledge.",
                AdditionalContext = "adjective",
                DateAdded = new DateTime(2024, 11, 12, 7, 30, 0),
                Variant = BrainBlockVariantEnum.Learning,
            },
            new BrainBlock
            {
                Id = 3,
                Title = "Ziggurat",
                Content = "A rectangular stepped tower found in ancient Mesopotamia.",
                AdditionalContext = "noun",
                DateAdded = new DateTime(2024, 11, 23, 7, 30, 0),
                Variant = BrainBlockVariantEnum.Learning,
            }
        );
    }
}
