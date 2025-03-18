using CogLog.UI.Models.Shared.Components;
using Microsoft.AspNetCore.Mvc;

namespace CogLog.UI.Components;

public class FloatingActionButton : ViewComponent
{
    public IViewComponentResult Invoke(string actionName, int? routeId)
    {
        var vm = new FloatingActionButtonVm() { ActionName = actionName, RouteId = routeId };
        return View("Default", vm);
    }
}
