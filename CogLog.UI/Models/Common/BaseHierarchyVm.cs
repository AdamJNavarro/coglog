namespace CogLog.UI.Models.Common;

public abstract class BaseHierarchyVm
{
    public required int Id { get; init; }

    public required string Label { get; init; }

    public string? Description { get; init; }
}
