using CogLog.UI.Models.Subject;

namespace CogLog.UI.Models.Category;

public class CategoryDetailsVm
{
    public int Id { get; init; }

    public string Name { get; init; }

    public string? Icon { get; init; }

    public string? Description { get; init; }

    public List<SubjectMinimalVm> Subjects { get; init; }
}
