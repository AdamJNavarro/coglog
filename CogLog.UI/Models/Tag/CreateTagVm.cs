namespace CogLog.UI.Models.Tag;

public class CreateTagVm
{
    public required string Name { get; init; }

    public string? Icon { get; init; }

    public string? Description { get; init; }

    public required int SubjectId { get; init; }
}
