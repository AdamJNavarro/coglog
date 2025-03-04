namespace CogLog.UI.Models.Topic;

public class CreateTopicVm
{
    public required string Label { get; init; }

    public string? Icon { get; init; }

    public string? Description { get; init; }

    public required int SubjectId { get; init; }
}
