using CogLog.Domain.Common;

namespace CogLog.Domain.Hierarchy;

public class BaseHierarchy : BaseEntity
{
    public required string Label { get; init; }

    public string? Description { get; init; }
}
