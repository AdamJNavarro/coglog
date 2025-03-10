using CogLog.UI.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CogLog.UI.Controllers;

public class SubjectsController(ISubjectService subjectService) : Controller
{
    [Route("subjects/{id:int}/topics", Name = "SubjectWithTopics")]
    public async Task<IActionResult> SubjectWithTopics(int id)
    {
        var data = await subjectService.GetSubjectWithCategoryTopicsAsync(id);
        return View(data);
    }

    [HttpGet]
    public async Task<IActionResult> GetSubjectsByCategory(int categoryId)
    {
        var data = await subjectService.GetSubjectsByCategoryAsync(categoryId);
        var subjects = data.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name,
            })
            .ToList();

        return Json(subjects);
    }
}
