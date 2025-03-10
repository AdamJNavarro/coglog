using CogLog.UI.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CogLog.UI.Controllers;

public class TagsController(ITagService tagService) : Controller
{
    [HttpGet]
    public async Task<IActionResult> GetTagsBySubject(int subjectId)
    {
        var data = await tagService.GetTagsBySubjectAsync(subjectId);
        var tags = data.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name });
        return Json(tags);
    }
}
