using CogLog.UI.Models.Shared.Hierarchy;

namespace CogLog.UI.Models.Topic;

public class BaseTopicVm : HierarchyBaseMinimalVm
{
    public required int SubjectId { get; init; }
}
