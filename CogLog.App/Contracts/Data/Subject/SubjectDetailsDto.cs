using CogLog.App.Contracts.Data.Category;
using CogLog.App.Contracts.Data.Tag;
using CogLog.App.Contracts.Data.Topic;

namespace CogLog.App.Contracts.Data.Subject;

public record SubjectDetailsDto(
    int Id,
    string Name,
    string? Icon,
    string? Description,
    int CategoryId,
    CategoryMinimalDto Category,
    List<TopicMinimalDto> Topics,
    List<TagMinimalDto> Tags
);
