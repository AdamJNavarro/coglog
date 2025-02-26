namespace CogLog.UI.Models.Common;

public abstract class BaseHierarchyVm
{
    public int Id { get; init; }

    public string Label { get; init; }

    public string? Description { get; init; }
}
