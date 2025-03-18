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

    public static List<CategoryMinimalVm> ToCategoryMinimalVmList(
        this IEnumerable<CategoryMinimalDto> categories
    )
    {
        return categories.Select(x => x.ToCategoryMinimalVm()).ToList();
    }

    public static CategoryDetailsVm ToCategoryDetailsVm(this CategoryDetailsDto category)
    {
        return new CategoryDetailsVm
        {
            Id = category.Id,
            Name = category.Name,
            Icon = category.Icon,
            Description = category.Description,
            Subjects = category.Subjects.ToSubjectMinimalVmList(),
        };
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
