using CogLog.UI.Models.Shared.Hierarchy;
using CogLog.UI.Models.Subject;

namespace CogLog.UI.Models.Tag;

public class TagDetailsVm : HierarchyBaseMinimalVm
{
    public string? Description { get; init; }

    public int SubjectId { get; init; }

    public SubjectMinimalVm Subject { get; init; }
}
