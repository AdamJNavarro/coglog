using CogLog.Domain.Shared;

namespace CogLog.Domain;

public class Topic : BaseHierarchy
{
    public required int SubjectId { get; init; }

    public Subject Subject { get; init; }

    public List<BlockTopic> BlockTopics { get; init; } = [];
}
