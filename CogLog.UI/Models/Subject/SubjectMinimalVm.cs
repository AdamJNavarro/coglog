using CogLog.UI.Models.Shared.Hierarchy;

namespace CogLog.UI.Models.Subject;

public class SubjectMinimalVm
{
    public int Id { get; init; }

    public string Name { get; init; }

    public string? Icon { get; init; }

    public int? CategoryId { get; init; }
}
