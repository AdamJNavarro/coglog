namespace CogLog.Domain.Hierarchy;

public class Category : BaseHierarchy
{
    public required string Icon { get; init; }

    public List<Subject> Subjects { get; init; } = [];

    public List<BrainBlock> BrainBlocks { get; set; } = [];
}
