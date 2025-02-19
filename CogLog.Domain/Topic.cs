using CogLog.Domain.Common;

namespace CogLog.Domain;

public class Topic : BaseHierarchy
{
    public string? Icon { get; init; }

    public required int SubjectId { get; init; }

    public Subject Subject { get; init; }

    public List<BlockTopic> BlockTopics { get; init; } = [];
}
