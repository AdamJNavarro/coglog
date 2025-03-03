using CogLog.UI.Models.Subject;

namespace CogLog.UI.Models.Category;

public class CategoryWithSubjectsVm : BaseCategoryVm
{
    public List<BaseSubjectVm> Subjects { get; init; }
}
