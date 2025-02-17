using CogLog.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CogLog.Persistence.Configs;

public class BrainBlockConfig : IEntityTypeConfiguration<BrainBlock>
{
    public void Configure(EntityTypeBuilder<BrainBlock> builder)
    {
        builder.Property(x => x.Id).UseIdentityColumn(1, 1);
    }
}
