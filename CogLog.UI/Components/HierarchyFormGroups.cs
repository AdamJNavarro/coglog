using CogLog.UI.Models.Shared.Hierarchy;
using Microsoft.AspNetCore.Mvc;

namespace CogLog.UI.Components;

public class HierarchyFormGroups : ViewComponent
{
    public IViewComponentResult Invoke(HierarchyBaseWriteVm model)
    {
        return View(model);
    }
}
