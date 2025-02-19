using CogLog.App.Contracts.Data.Block;
using CogLog.App.Contracts.Persistence;
using CogLog.App.Features.Block.Queries;
using CogLog.Core.Tests.Mocks;
using Moq;
using Shouldly;

namespace CogLog.Core.Tests.Features.Blocks.Get;

public class GetBlocksHandlerTests
{
    private readonly Mock<IBlockRepo> _mockRepo = MockBlockRepo.GetMockBlockRepo();

    [Fact]
    public async Task Get_Blocks_List_Test()
    {
        var handler = new GetBlocksHandler(_mockRepo.Object);
        var result = await handler.Handle(new GetBlocksQuery(), CancellationToken.None);
        result.ShouldBeOfType<List<BlockDto>>();
    }
}
