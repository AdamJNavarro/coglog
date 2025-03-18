using CogLog.UI.Models.Shared.Hierarchy;
using CogLog.UI.Models.Subject;

namespace CogLog.UI.Models.Category;

public class CategoryDetailsVm : HierarchyBaseMinimalVm
{
    public string? Description { get; init; }

    public List<SubjectMinimalVm> Subjects { get; init; }
}
