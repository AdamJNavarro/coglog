using CogLog.UI.Models.Block;
using Microsoft.AspNetCore.Mvc;

namespace CogLog.UI.Components;

public class BlockFormGroups : ViewComponent
{
    public IViewComponentResult Invoke(BlockBaseWriteVm model)
    {
        return View(model);
    }
}
