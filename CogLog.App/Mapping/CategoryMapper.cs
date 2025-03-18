using CogLog.App.Contracts.Data.Category;
using CogLog.App.Features.Category.Commands;
using CogLog.Domain;

namespace CogLog.App.Mapping;

public static class CategoryMapper
{
    public static CategoryMinimalDto ToCategoryMinimalDto(this Category category)
    {
        return new CategoryMinimalDto(category.Id, category.Name, category.Icon);
    }

    public static List<CategoryMinimalDto> ToCategoryMinimalDtoList(this List<Category> categories)
    {
        return categories.Select(x => x.ToCategoryMinimalDto()).ToList();
    }

    public static CategoryDetailsDto ToCategoryDetailsDto(this Category category)
    {
        return new CategoryDetailsDto(
            category.Id,
            category.Name,
            category.Icon,
            category.Description,
            category.Subjects.Select(x => x.ToSubjectMinimalDto()).ToList()
        );
    }

    public static Category ToCategory(this CreateCategoryCommand request)
    {
        return new Category
        {
            Name = request.Name,
            Icon = request.Icon,
            Description = request.Description,
        };
    }

    public static Category ToCategory(this UpdateCategoryCommand request)
    {
        return new Category
        {
            Id = request.Id,
            Name = request.Name,
            Icon = request.Icon,
            Description = request.Description,
        };
    }
}
