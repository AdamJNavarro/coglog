using CogLog.App.Contracts.Data.Category;
using CogLog.App.Contracts.Persistence;
using CogLog.App.Features.Category.Queries;
using CogLog.Core.Tests.Mocks;
using Moq;
using Shouldly;

namespace CogLog.Core.Tests.Features.Category;

public class GetCategoriesHandlerTests
{
    private readonly Mock<ICategoryRepo> _mockRepo = MockCategoryRepo.GetMockCategoryRepo();

    [Fact]
    public async Task Get_Categories_Test()
    {
        var handler = new GetCategoriesHandler(_mockRepo.Object);
        var result = await handler.Handle(new GetCategoriesQuery(), CancellationToken.None);
        result.ShouldBeOfType<List<CategoryMinimalDto>>();
    }
}
