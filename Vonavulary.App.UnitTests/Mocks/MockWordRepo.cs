using Moq;
using Vonavulary.App.Contracts.Persistence;
using Vonavulary.Domain;

namespace Vonavulary.Core.Tests.Mocks;

public class MockWordRepo
{
    public static Mock<IWordRepo> GetMockWordRepo()
    {
        var mockWords = new List<Word>()
        {
            new()
            {
                Id = 1,
                Spelling = "mock",
                Definition = "definition",
            },
        };

        var mockRepo = new Mock<IWordRepo>();

        // mockRepo.Setup(r => r.GetWordsAsync()).ReturnsAsync(mockWords);

        mockRepo
            .Setup(r => r.CreateWordAsync(It.IsAny<Word>()))
            .Returns(
                (Word word) =>
                {
                    mockWords.Add(word);
                    return Task.CompletedTask;
                }
            );
        return mockRepo;
    }
}
