namespace CogLog.UI.Models.Tag;

public class CreateTagVm
{
    public required string Label { get; init; }

    public string? Icon { get; init; }

    public required int SubjectId { get; init; }
}
