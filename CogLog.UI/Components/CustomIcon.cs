using CogLog.UI.Models.Shared.Components;
using Microsoft.AspNetCore.Mvc;

namespace CogLog.UI.Components;

public class CustomIcon : ViewComponent
{
    public IViewComponentResult Invoke(string name)
    {
        var vm = new CustomIconVm() { IconName = name };
        return View("Default", vm);
    }
}
