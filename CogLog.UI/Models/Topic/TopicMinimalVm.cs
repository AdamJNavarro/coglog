namespace CogLog.UI.Models.Topic;

public class TopicMinimalVm
{
    public required int Id { get; init; }

    public required string Label { get; init; }

    public string? Icon { get; init; }
}
