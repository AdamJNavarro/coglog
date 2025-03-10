using CogLog.UI.Models.Shared.Hierarchy;

namespace CogLog.UI.Models.Tag;

public class BaseTagVm : HierarchyBaseMinimalVm
{
    public required int SubjectId { get; init; }
}
