using CogLog.App.Contracts.Data.Subject;

namespace CogLog.App.Contracts.Data.Topic;

public record TopicDetailsDto(
    int Id,
    string Name,
    string? Icon,
    string? Description,
    int SubjectId,
    SubjectMinimalDto Subject
);
