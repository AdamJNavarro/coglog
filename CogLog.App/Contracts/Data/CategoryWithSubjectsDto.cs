namespace CogLog.App.Contracts.Data;

public record CategoryWithSubjectsDto(
    int Id,
    string Label,
    string Icon,
    string? Description,
    List<SubjectDto> Subjects
);
