namespace CogLog.UI.Models.Subject;

public class CreateSubjectVm
{
    public required string Label { get; init; }

    public string? Icon { get; init; }

    public string? Description { get; init; }

    public required int CategoryId { get; init; }
}
