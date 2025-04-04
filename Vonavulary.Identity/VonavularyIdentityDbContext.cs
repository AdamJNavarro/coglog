using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Vonavulary.Identity.Models;

namespace Vonavulary.Identity;

public class VonavularyIdentityDbContext(DbContextOptions<VonavularyIdentityDbContext> options)
    : IdentityDbContext<AppUser>(options)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(VonavularyIdentityDbContext).Assembly);
        base.OnModelCreating(builder);
    }
}
