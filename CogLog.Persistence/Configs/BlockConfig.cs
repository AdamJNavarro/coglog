using CogLog.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CogLog.Persistence.Configs;

public class BlockConfig : IEntityTypeConfiguration<Block>
{
    public void Configure(EntityTypeBuilder<Block> builder)
    {
        builder.Property(x => x.Id).UseIdentityColumn(1, 1);
    }
}
