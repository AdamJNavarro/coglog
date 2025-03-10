using CogLog.Domain.Shared;

namespace CogLog.Domain;

public class Subject : BaseHierarchy
{
    public required int CategoryId { get; init; }

    public Category Category { get; set; }

    public List<Topic> Topics { get; init; } = [];

    public List<Tag> Tags { get; init; } = [];

    public List<Block> Blocks { get; init; } = [];
}
