namespace CogLog.UI.Models.Shared.Hierarchy;

public abstract class HierarchyBaseMinimalVm
{
    public int Id { get; init; }

    public string Name { get; init; }

    public string? Icon { get; init; }

    public string CapitalizedName =>
        System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(
            Name?.ToLower() ?? string.Empty
        );
}
