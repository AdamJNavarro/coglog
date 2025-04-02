using CogLog.UI.Models.Word;
using Microsoft.AspNetCore.Mvc;

namespace CogLog.UI.Components;

public class WordFormGroups : ViewComponent
{
    public IViewComponentResult Invoke(WordBaseWriteVm model)
    {
        return View(model);
    }
}
