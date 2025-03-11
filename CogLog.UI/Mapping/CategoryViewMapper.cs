using CogLog.UI.Models.Category;
using CogLog.UI.Services.Base;

namespace CogLog.UI.Mapping;

public static class CategoryViewMapper
{
    public static CategoryMinimalVm ToCategoryMinimalVm(this CategoryMinimalDto category)
    {
        var categoryVm = new CategoryMinimalVm
        {
            Id = category.Id,
            Name = category.Name,
            Icon = category.Icon,
        };

        return categoryVm;
    }

    public static BaseCategoryVm ToBaseCategoryVm(this CategoryDto category)
    {
        var categoryVm = new BaseCategoryVm
        {
            Id = category.Id,
            Name = category.Name,
            Icon = category.Icon,
            Description = category.Description,
        };

        return categoryVm;
    }

    public static List<BaseCategoryVm> ToBaseCategoriesVm(this ICollection<CategoryDto> categories)
    {
        return categories.Select(x => x.ToBaseCategoryVm()).ToList();
    }

    public static CategoryWithSubjectsVm ToCategoryWithSubjectsVm(
        this CategoryWithSubjectsDto category
    )
    {
        var vm = new CategoryWithSubjectsVm
        {
            Id = category.Id,
            Name = category.Name,
            Icon = category.Icon,
            Subjects = category.Subjects.ToBaseSubjectVmList(),
        };
        return vm;
    }

    public static CreateCategoryCommand ToCreateCategoryCommand(this CategoryCreateVm category)
    {
        return new CreateCategoryCommand
        {
            Name = category.Name,
            Icon = category.Icon,
            Description = category.Description,
        };
    }

    public static UpdateCategoryCommand ToUpdateCategoryCommand(this CategoryEditVm category)
    {
        return new UpdateCategoryCommand
        {
            Id = category.Id,
            Name = category.Name,
            Icon = category.Icon,
            Description = category.Description,
        };
    }
}
