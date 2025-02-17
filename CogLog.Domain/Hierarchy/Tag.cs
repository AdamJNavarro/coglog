using CogLog.Domain.Common;

namespace CogLog.Domain.Hierarchy;

public class Tag : BaseEntity
{
    public string? Icon { get; init; }

    public required int SubjectId { get; init; }

    public required Subject Subject { get; init; }

    public List<BrainBlock> BrainBlocks { get; init; } = [];
}
