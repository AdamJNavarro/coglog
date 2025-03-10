using CogLog.Domain.Shared;

namespace CogLog.Domain;

public class Tag : BaseHierarchy
{
    public required int SubjectId { get; init; }

    public Subject Subject { get; init; }

    public List<BlockTag> BlockTags { get; init; } = [];
}
