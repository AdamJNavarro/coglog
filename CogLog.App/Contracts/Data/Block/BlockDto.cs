using CogLog.App.Contracts.Data.Category;
using CogLog.App.Contracts.Data.Tag;

namespace CogLog.App.Contracts.Data.Block;

public record BlockDto(
    int Id,
    DateTime DateAdded,
    string Title,
    string Content,
    string? ExtraContent,
    string? Url,
    int? CategoryId,
    CategoryDto? Category,
    int? SubjectId,
    SubjectDto? Subject,
    List<TopicDto> Topics,
    List<TagDto> Tags
);
