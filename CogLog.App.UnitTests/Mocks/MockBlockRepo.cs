using CogLog.App.Contracts.Persistence;
using CogLog.Domain;
using Moq;

namespace CogLog.Core.Tests.Mocks;

public class MockBlockRepo
{
    public static Mock<IBlockRepo> GetMockBlockRepo()
    {
        var mockBlocks = new List<Block>()
        {
            new()
            {
                Id = 1,
                Title = "Title",
                Content = "Content",
            },
            new()
            {
                Id = 2,
                Title = "Title2",
                Content = "Content2",
            },
        };

        var mockRepo = new Mock<IBlockRepo>();

        mockRepo.Setup(r => r.GetBlocksAsync()).ReturnsAsync(mockBlocks);

        mockRepo
            .Setup(r => r.CreateBlockAsync(It.IsAny<Block>()))
            .Returns(
                (Block brainBlock) =>
                {
                    mockBlocks.Add(brainBlock);
                    return Task.CompletedTask;
                }
            );
        return mockRepo;
    }
}
