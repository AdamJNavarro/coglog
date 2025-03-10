using CogLog.UI.Models.Category;
using CogLog.UI.Models.Shared.Hierarchy;
using CogLog.UI.Models.Topic;

namespace CogLog.UI.Models.Subject;

public class SubjectWithCategoryTopicsVm : HierarchyBaseMinimalVm
{
    public required int CategoryId { get; init; }

    public required BaseCategoryVm Category { get; init; }

    public List<BaseTopicVm> Topics { get; init; }
}
