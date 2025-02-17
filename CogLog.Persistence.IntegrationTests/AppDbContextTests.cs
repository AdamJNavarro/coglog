using CogLog.Domain;
using Microsoft.EntityFrameworkCore;
using Shouldly;

namespace CogLog.Persistence.IntegrationTests;

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
    public async void DateAdded_Set_DuringSave()
    {
        var brainBlock = new BrainBlock
        {
            Id = 1,
            Title = "Hello World",
            Content = "Hello World",
        };

        await _dbContext.BrainBlocks.AddAsync(brainBlock);
        await _dbContext.SaveChangesAsync();

        brainBlock.DateAdded.ShouldBeOfType<DateTime>();
    }
}
