namespace CogLog.UI.Models.Tag;

public class TagMinimalVm
{
    public required int Id { get; init; }

    public required string Label { get; init; }

    public string? Icon { get; init; }
}
