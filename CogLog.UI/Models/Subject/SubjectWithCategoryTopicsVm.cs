using CogLog.UI.Models.Category;
using CogLog.UI.Models.Common;
using CogLog.UI.Models.Topic;

namespace CogLog.UI.Models.Subject;

public class SubjectWithCategoryTopicsVm : BaseHierarchyVm
{
    public string? Icon { get; init; }

    public required int CategoryId { get; init; }

    public required BaseCategoryVm Category { get; init; }

    public List<BaseTopicVm> Topics { get; init; }
}
