using CogLog.App.Contracts.Data;
using CogLog.Domain.Hierarchy;

namespace CogLog.App.Mapping;

public static class DomainToDtoMapper
{
    public static CategoryDto ToCategoryDto(this Category category)
    {
        return new CategoryDto
        {
            Id = category.Id,
            Label = category.Label,
            Description = category.Description,
            Icon = category.Icon,
        };
    }

    public static List<CategoryDto> ToCategoryDtos(this List<Category> categories)
    {
        return categories.Select(x => x.ToCategoryDto()).ToList();
    }

    public static CategoryWithSubjectsDto ToCategoryWithSubjectsDto(this Category category)
    {
        return new CategoryWithSubjectsDto
        {
            Id = category.Id,
            Label = category.Label,
            Description = category.Description,
            Icon = category.Icon,
            Subjects = category.Subjects.Select(x => x.ToSubjectDto()).ToList(),
        };
    }

    public static SubjectDto ToSubjectDto(this Subject subject)
    {
        return new SubjectDto
        {
            Id = subject.Id,
            Label = subject.Label,
            Description = subject.Description,
            Icon = subject.Icon,
            CategoryId = subject.CategoryId,
        };
    }
}
