using CogLog.UI.Models.Block;
using Microsoft.AspNetCore.Mvc;

namespace CogLog.UI.Components;

public class BlockClassificationCircle : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync(string? categoryName, string? subjectName)
    {
        var model = new BlockClassificationCircleVm { };

        if (!string.IsNullOrEmpty(categoryName))
        {
            // determine class name based on category
        }

        if (!string.IsNullOrEmpty(subjectName))
        {
            // determine icon name based on subject
        }

        return View("Default", model);
    }
}
