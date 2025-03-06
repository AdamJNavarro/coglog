using CogLog.App.Contracts.Data.Category;
using CogLog.App.Features.Category.Commands;
using CogLog.Domain;

namespace CogLog.App.Mapping;

public static class CategoryMapper
{
    public static CategoryMinimalDto ToCategoryMinimalDto(this Category category)
    {
        return new CategoryMinimalDto(category.Id, category.Label, category.Icon);
    }

    public static List<CategoryMinimalDto> ToCategoryMinimalDtoList(this List<Category> categories)
    {
        return categories.Select(x => x.ToCategoryMinimalDto()).ToList();
    }

    public static CategoryDto ToCategoryDto(this Category category)
    {
        return new CategoryDto(category.Id, category.Label, category.Icon, category.Description);
    }

    public static List<CategoryDto> ToCategoriesDto(this List<Category> categories)
    {
        return categories.Select(x => x.ToCategoryDto()).ToList();
    }

    public static CategoryWithSubjectsDto ToCategoryWithSubjectsDto(this Category category)
    {
        return new CategoryWithSubjectsDto(
            category.Id,
            category.Label,
            category.Icon,
            category.Description,
            category.Subjects.Select(x => x.ToSubjectDto()).ToList()
        );
    }

    public static CategoryWithBlocksDto ToCategoryWithBlocksDto(this Category category)
    {
        return new CategoryWithBlocksDto(
            category.Id,
            category.Label,
            category.Icon,
            category.Description,
            category.Blocks.Select(x => x.ToBlockDto()).ToList()
        );
    }

    public static Category ToCategory(this CreateCategoryCommand request)
    {
        return new Category
        {
            Label = request.Label,
            Icon = request.Icon,
            Description = request.Description,
        };
    }

    public static Category ToCategory(this UpdateCategoryCommand request)
    {
        return new Category
        {
            Id = request.Id,
            Label = request.Label,
            Icon = request.Icon,
            Description = request.Description,
        };
    }
}
