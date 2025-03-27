using CogLog.App.Contracts.Data.Subject;
using CogLog.App.Contracts.Data.Tag;
using CogLog.App.Contracts.Data.Topic;

namespace CogLog.App.Contracts.Data.Block;

public record BlockDetailsDto(
    int Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime LearnedAt,
    string Title,
    string Content,
    string? ExtraContent,
    string? Url,
    int? SubjectId,
    SubjectMinimalDto? Subject,
    List<TopicMinimalDto> Topics,
    List<TagMinimalDto> Tags
);
