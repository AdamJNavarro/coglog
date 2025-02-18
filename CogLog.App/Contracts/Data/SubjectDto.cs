namespace CogLog.App.Contracts.Data;

public class SubjectDto
{
    public int Id { get; init; }

    public string Label { get; init; }

    public string? Icon { get; init; }

    public string? Description { get; init; }

    public int CategoryId { get; init; }
}
