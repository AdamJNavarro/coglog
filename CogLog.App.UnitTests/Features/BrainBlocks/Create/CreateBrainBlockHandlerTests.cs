using AutoMapper;
using CogLog.App.Contracts.Persistence;
using CogLog.App.Features.BrainBlock.Create;
using CogLog.App.Mapping;
using CogLog.Core.Tests.Mocks;
using CogLog.Domain;
using Moq;
using Shouldly;

namespace CogLog.Core.Tests.Features.BrainBlocks.Create;

public class CreateBrainBlockHandlerTests
{
    private readonly Mock<IBrainBlockRepo> _mockRepo;
    private readonly IMapper _mapper;

    public CreateBrainBlockHandlerTests()
    {
        _mockRepo = MockBrainBlockRepo.GetMockBrainBlockRepo();

        _mapper = new MapperConfiguration(c =>
        {
            c.AddProfile<BrainBlockProfile>();
        }).CreateMapper();
    }

    [Fact]
    public async Task Create_BrainBlock_Test()
    {
        var handler = new CreateBrainBlockHandler(_mapper, _mockRepo.Object);

        await handler.Handle(
            new CreateBrainBlockCommand("test", "content", null, BrainBlockVariantEnum.Learning),
            CancellationToken.None
        );

        var brainBlocks = await _mockRepo.Object.GetAsync();
        brainBlocks.Count.ShouldBe(3);
    }
}
