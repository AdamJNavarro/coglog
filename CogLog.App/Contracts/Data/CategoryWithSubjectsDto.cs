namespace CogLog.App.Contracts.Data;

public class CategoryWithSubjectsDto
{
    public int Id { get; init; }

    public string Label { get; init; }

    public string Icon { get; init; }

    public string? Description { get; init; }

    public List<SubjectDto> Subjects { get; init; }
}
