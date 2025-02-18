using CogLog.Domain.Common;

namespace CogLog.Domain;

public class Category : BaseHierarchy
{
    public required string Icon { get; init; }

    public List<Subject> Subjects { get; init; } = [];

    public List<BrainBlock> BrainBlocks { get; init; } = [];
}
