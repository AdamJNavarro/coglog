namespace CogLog.Domain.Hierarchy;

public class Subject : BaseHierarchy
{
    public string? Icon { get; init; }

    public required int CategoryId { get; init; }

    public required Category Category { get; init; }

    public List<Topic> Topics { get; init; } = [];

    public List<Tag> Tags { get; init; } = [];

    public List<BrainBlock> BrainBlocks { get; init; } = [];
}
