namespace CogLog.Domain.Shared;

public class BaseHierarchy : BaseEntity
{
    public required string Name { get; init; }

    public string? Icon { get; init; }

    public string? Description { get; init; }
}
