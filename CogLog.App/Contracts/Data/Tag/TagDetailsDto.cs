using CogLog.App.Contracts.Data.Subject;

namespace CogLog.App.Contracts.Data.Tag;

public record TagDetailsDto(
    int Id,
    string Name,
    string? Icon,
    string? Description,
    int SubjectId,
    SubjectMinimalDto Subject
);
