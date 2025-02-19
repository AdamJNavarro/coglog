namespace CogLog.App.Contracts.Data;

public record BrainBlockDto(
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
