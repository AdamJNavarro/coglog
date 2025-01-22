using CogLog.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CogLog.Identity;

public class CogLogIdentityDbContext(DbContextOptions<CogLogIdentityDbContext> options)
    : IdentityDbContext<AppUser>(options)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(CogLogIdentityDbContext).Assembly);
        base.OnModelCreating(builder);
    }
}
