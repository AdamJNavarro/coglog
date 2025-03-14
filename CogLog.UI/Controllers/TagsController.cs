using CogLog.UI.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CogLog.UI.Controllers;

public class TagsController(ITagService tagService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var data = await tagService.GetTagsAsync();
        return View(data);
    }

    [HttpGet]
    public async Task<IActionResult> GetTagsBySubject(int subjectId)
    {
        var data = await tagService.GetSelectListAsync(subjectId);
        return Json(data);
    }
}
