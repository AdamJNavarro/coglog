using CogLog.UI.Models.Common;

namespace CogLog.UI.Models.Topic;

public class BaseTopicVm : BaseHierarchyVm
{
    public string? Icon { get; init; }

    public required int SubjectId { get; init; }
}
