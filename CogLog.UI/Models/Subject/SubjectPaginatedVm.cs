using CogLog.UI.Models.Category;

namespace CogLog.UI.Models.Subject;

public class SubjectPaginatedVm
{
    public int Id { get; init; }

    public string Name { get; init; }

    public string? Icon { get; init; }

    public int? CategoryId { get; init; }

    public CategoryMinimalVm? Category { get; init; }
}
