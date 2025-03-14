using CogLog.UI.Models.Shared.Hierarchy;
using Microsoft.AspNetCore.Mvc;

namespace CogLog.UI.Components;

public class HierarchyList : ViewComponent
{
    public IViewComponentResult Invoke(
        IEnumerable<HierarchyBaseMinimalVm> items,
        string controller,
        string action
    )
    {
        var vm = new HierarchyListVm()
        {
            Items = items,
            Controller = controller,
            Action = action,
        };

        return View("Default", vm);
    }
}
