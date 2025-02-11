using CogLog.Domain;
using Microsoft.EntityFrameworkCore;

namespace CogLog.Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<BrainBlock> BrainBlocks { get; set; }
    public DbSet<Topic> Topics { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        modelBuilder
            .Entity<Topic>()
            .HasMany(t => t.BrainBlocks)
            .WithOne(b => b.Topic)
            .HasForeignKey(b => b.TopicId)
            .OnDelete(DeleteBehavior.SetNull);

        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (
            var entry in base
                .ChangeTracker.Entries<BrainBlock>()
                .Where(q => q.State == EntityState.Added)
        )
        {
            entry.Entity.DateAdded = DateTime.Now;
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}
