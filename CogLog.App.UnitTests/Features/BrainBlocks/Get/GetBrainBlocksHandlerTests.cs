using CogLog.App.Contracts.Data;
using CogLog.App.Contracts.Persistence;
using CogLog.App.Features.BrainBlock.Queries;
using CogLog.Core.Tests.Mocks;
using Moq;
using Shouldly;

namespace CogLog.Core.Tests.Features.BrainBlocks.Get;

public class GetBrainBlocksHandlerTests
{
    private readonly Mock<IBrainBlockRepo> _mockRepo = MockBrainBlockRepo.GetMockBrainBlockRepo();

    [Fact]
    public async Task Get_BrainBlocks_List_Test()
    {
        var handler = new GetBrainBlocksHandler(_mockRepo.Object);
        var result = await handler.Handle(new GetBrainBlocksQuery(), CancellationToken.None);
        result.ShouldBeOfType<List<BrainBlockDto>>();
    }
}
