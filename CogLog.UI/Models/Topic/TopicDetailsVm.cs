using CogLog.UI.Models.Subject;

namespace CogLog.UI.Models.Topic;

public class TopicDetailsVm
{
    public int Id { get; init; }

    public string Name { get; init; }

    public string? Icon { get; init; }

    public string? Description { get; init; }

    public int SubjectId { get; init; }

    public SubjectMinimalVm Subject { get; init; }
}
