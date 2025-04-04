using Microsoft.AspNetCore.Mvc;
using Vonavulary.UI.Models.Word;

namespace Vonavulary.UI.Components;

public class WordFormGroups : ViewComponent
{
    public IViewComponentResult Invoke(WordBaseWriteVm model)
    {
        return View(model);
    }
}
