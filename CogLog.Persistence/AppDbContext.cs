using CogLog.Domain;
using Microsoft.EntityFrameworkCore;

namespace CogLog.Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Block> Blocks { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Topic> Topics { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<BlockTopic> BlockTopics { get; set; }
    public DbSet<BlockTag> BlockTags { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        base.OnModelCreating(builder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (
            var entry in base
                .ChangeTracker.Entries<Block>()
                .Where(q => q.State == EntityState.Added)
        )
        {
            entry.Entity.DateAdded = DateTime.Now;
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}
