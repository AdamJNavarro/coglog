using CogLog.UI.Contracts;
using CogLog.UI.Models.Shared.Hierarchy;
using Microsoft.AspNetCore.Mvc;

namespace CogLog.UI.Components;

public class CategorySelector(ICategoryService categoryService) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync(int? categoryId)
    {
        var vm = new CategorySelectorVm
        {
            CategorySelectItems = await categoryService.GetSelectListAsync(),
        };

        if (categoryId.HasValue)
        {
            vm.CategoryId = categoryId.Value;
        }

        return View("Default", vm);
    }
}
