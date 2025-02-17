using CogLog.App.Contracts.Persistence;
using CogLog.Domain;
using Moq;

namespace CogLog.Core.Tests.Mocks;

public class MockBrainBlockRepo
{
    public static Mock<IBrainBlockRepo> GetMockBrainBlockRepo()
    {
        var mockBrainBlocks = new List<BrainBlock>()
        {
            new BrainBlock
            {
                Id = 1,
                Title = "Title",
                Content = "Content",
            },
            new BrainBlock
            {
                Id = 2,
                Title = "Title2",
                Content = "Content2",
            },
        };

        var mockRepo = new Mock<IBrainBlockRepo>();

        mockRepo.Setup(r => r.GetAsync()).ReturnsAsync(mockBrainBlocks);

        mockRepo
            .Setup(r => r.CreateAsync(It.IsAny<BrainBlock>()))
            .Returns(
                (BrainBlock brainBlock) =>
                {
                    mockBrainBlocks.Add(brainBlock);
                    return Task.CompletedTask;
                }
            );
        return mockRepo;
    }
}
