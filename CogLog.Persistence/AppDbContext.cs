using CogLog.Domain;
using CogLog.Domain.Hierarchy;
using Microsoft.EntityFrameworkCore;

namespace CogLog.Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<BrainBlock> BrainBlocks { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Topic> Topics { get; set; }
    public DbSet<Tag> Tags { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        // Category-BrainBlock 1-N
        builder
            .Entity<Category>()
            .HasMany(c => c.BrainBlocks)
            .WithOne(b => b.Category)
            .HasForeignKey(b => b.CategoryId)
            .OnDelete(DeleteBehavior.NoAction);

        // Category-Subject 1-N
        builder
            .Entity<Category>()
            .HasMany(c => c.Subjects)
            .WithOne(s => s.Category)
            .HasForeignKey(s => s.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);

        // Subject-BrainBlock 1-N
        builder
            .Entity<Subject>()
            .HasMany(s => s.BrainBlocks)
            .WithOne(b => b.Subject)
            .HasForeignKey(b => b.SubjectId)
            .OnDelete(DeleteBehavior.NoAction);

        // Subject-Topic 1-N
        builder
            .Entity<Subject>()
            .HasMany(s => s.Topics)
            .WithOne(t => t.Subject)
            .HasForeignKey(t => t.SubjectId)
            .OnDelete(DeleteBehavior.Cascade);

        // Subject-Tag 1-N
        builder
            .Entity<Subject>()
            .HasMany(s => s.Tags)
            .WithOne(t => t.Subject)
            .HasForeignKey(t => t.SubjectId)
            .OnDelete(DeleteBehavior.Cascade);

        // BrainBlock-Topic N-N
        builder
            .Entity<BrainBlock>()
            .HasMany(b => b.Topics)
            .WithMany(t => t.BrainBlocks)
            .UsingEntity(j => j.ToTable("BrainBlockTopics"));

        // BrainBlock-Tag N-N
        builder
            .Entity<BrainBlock>()
            .HasMany(b => b.Tags)
            .WithMany(t => t.BrainBlocks)
            .UsingEntity(j => j.ToTable("BrainBlockTags"));

        base.OnModelCreating(builder);
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
