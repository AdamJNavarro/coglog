using CogLog.UI.Models.Category;
using CogLog.UI.Services.Base;

namespace CogLog.UI.Mapping;

public static class CategoryViewMapper
{
    public static BaseCategoryVm ToBaseCategoryVm(this CategoryDto category)
    {
        var categoryVm = new BaseCategoryVm
        {
            Id = category.Id,
            Label = category.Label,
            Icon = category.Icon,
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
            Label = category.Label,
            Icon = category.Icon,
            Subjects = category.Subjects.ToBaseSubjectVmList(),
        };
        return vm;
    }

    public static CreateCategoryCommand ToCreateCategoryCommand(this CreateCategoryVm category)
    {
        return new CreateCategoryCommand
        {
            Label = category.Label,
            Icon = category.Icon,
            Description = category.Description,
        };
    }
}
