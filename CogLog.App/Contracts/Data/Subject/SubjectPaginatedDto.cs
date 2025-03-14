using CogLog.App.Contracts.Data.Category;

namespace CogLog.App.Contracts.Data.Subject;

public record SubjectPaginatedDto(
    int Id,
    string Name,
    string? Icon,
    int CategoryId,
    CategoryMinimalDto Category
);
