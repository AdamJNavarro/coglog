namespace CogLog.UI.Models.Shared.Hierarchy;

public abstract class HierarchyBaseMinimalVm
{
    public required int Id { get; init; }

    public required string Name { get; init; }

    public string? Icon { get; init; }
}
