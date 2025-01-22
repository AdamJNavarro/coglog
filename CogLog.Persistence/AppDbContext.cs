using CogLog.Domain;
using Microsoft.EntityFrameworkCore;

namespace CogLog.Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<BrainBlock> BrainBlocks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
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
