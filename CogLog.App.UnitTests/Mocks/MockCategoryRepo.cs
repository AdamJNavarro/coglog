using CogLog.App.Contracts.Persistence;
using CogLog.Domain;
using Moq;

namespace CogLog.Core.Tests.Mocks;

public class MockCategoryRepo
{
    public static Mock<ICategoryRepo> GetMockCategoryRepo()
    {
        var mockCategories = new List<Category>()
        {
            new() { Id = 1, Name = "category 1" },
        };

        var mockRepo = new Mock<ICategoryRepo>();

        mockRepo.Setup(r => r.GetCategoriesAsync()).ReturnsAsync(mockCategories);

        mockRepo
            .Setup(r => r.CreateCategoryAsync(It.IsAny<Category>()))
            .Returns(
                (Category category) =>
                {
                    mockCategories.Add(category);
                    return Task.CompletedTask;
                }
            );
        return mockRepo;
    }
}
