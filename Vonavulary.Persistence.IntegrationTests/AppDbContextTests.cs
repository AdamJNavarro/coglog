using Microsoft.EntityFrameworkCore;
using Shouldly;
using Vonavulary.Domain;
using Vonavulary.Persistence;

namespace Vonavulary.Persistence.IntegrationTests;

public class AppDbContextTests
{
    private readonly AppDbContext _dbContext;

    public AppDbContextTests()
    {
        var dbOptions = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        _dbContext = new AppDbContext(dbOptions);
    }

    [Fact]
    public async void CreatedAt_Set_DuringSave()
    {
        var word = new Word()
        {
            Id = 1,
            Spelling = "Hello World",
            Definition = "Hello World",
        };

        await _dbContext.Words.AddAsync(word);
        await _dbContext.SaveChangesAsync();

        word.CreatedAt.ShouldBeOfType<DateTime>();
    }
}
