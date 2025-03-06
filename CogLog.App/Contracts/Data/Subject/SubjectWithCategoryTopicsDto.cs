using CogLog.App.Contracts.Data.Category;
using CogLog.App.Contracts.Data.Topic;

namespace CogLog.App.Contracts.Data.Subject;

public record SubjectWithCategoryTopicsDto(
    int Id,
    string Label,
    string? Icon,
    string? Description,
    int CategoryId,
    CategoryDto Category,
    List<TopicDto> Topics
);
