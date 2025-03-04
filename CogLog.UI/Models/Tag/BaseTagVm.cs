using CogLog.UI.Models.Common;

namespace CogLog.UI.Models.Tag;

public class BaseTagVm
{
    public required int Id { get; init; }

    public required string Label { get; init; }

    public string? Icon { get; init; }

    public required int SubjectId { get; init; }
}
