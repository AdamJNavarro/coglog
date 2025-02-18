using CogLog.Domain.Common;

namespace CogLog.Domain;

public class Subject : BaseHierarchy
{
    public string? Icon { get; init; }

    public required int CategoryId { get; init; }

    public Category Category { get; set; }

    public List<Topic> Topics { get; init; } = [];

    public List<Tag> Tags { get; init; } = [];

    public List<BrainBlock> BrainBlocks { get; init; } = [];
}
