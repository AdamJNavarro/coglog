using CogLog.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CogLog.Identity.Configs;

public class UserConfig : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        var hasher = new PasswordHasher<AppUser>();
        builder.HasData(
            new AppUser
            {
                Id = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                Email = "adamjnav@gmail.com",
                NormalizedEmail = "ADAMJNAV@GMAIL.COM",
                UserName = "adamjnav@gmail.com",
                NormalizedUserName = "ADAMJNAV@GMAIL.COM",
                PasswordHash = hasher.HashPassword(null, "!6G*opNmG@fju4rCdMT_"),
                EmailConfirmed = true,
            }
        );
    }
}
