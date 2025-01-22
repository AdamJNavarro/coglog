using AutoMapper;
using CogLog.App.Contracts.Persistence;
using CogLog.App.Features.BrainBlock.Get;
using CogLog.App.Mapping;
using CogLog.Core.Tests.Mocks;
using Moq;
using Shouldly;

namespace CogLog.Core.Tests.Features.BrainBlocks.Get;

public class GetBrainBlocksHandlerTests
{
    private readonly Mock<IBrainBlockRepo> _mockRepo;
    private readonly IMapper _mappper;

    public GetBrainBlocksHandlerTests()
    {
        _mockRepo = MockBrainBlockRepo.GetMockBrainBlockRepo();

        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<BrainBlockProfile>();
        });

        _mappper = mapperConfig.CreateMapper();
    }

    [Fact]
    public async Task Get_BrainBlocks_List_Test()
    {
        var handler = new GetBrainBlocksHandler(_mappper, _mockRepo.Object);
        var result = await handler.Handle(new GetBrainBlocksQuery(), CancellationToken.None);
        result.ShouldBeOfType<List<BrainBlockDto>>();
    }
}
