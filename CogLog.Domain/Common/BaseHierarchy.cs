namespace CogLog.Domain.Common;

public class BaseHierarchy : BaseEntity
{
    public required string Label { get; init; }

    public string? Description { get; init; }
}
