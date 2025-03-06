using CogLog.App.Contracts.Data.Category;
using CogLog.App.Contracts.Data.Subject;
using CogLog.App.Contracts.Data.Tag;
using CogLog.App.Contracts.Data.Topic;

namespace CogLog.App.Contracts.Data.Block;

public record BlockDto(
    int Id,
    DateTime DateAdded,
    string Title,
    string Content,
    string? ExtraContent,
    string? Url,
    int? CategoryId,
    CategoryMinimalDto? Category,
    int? SubjectId,
    SubjectMinimalDto? Subject,
    List<TopicMinimalDto> Topics,
    List<TagMinimalDto> Tags
);
