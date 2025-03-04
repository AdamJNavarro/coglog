using CogLog.UI.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CogLog.UI.Controllers;

public class SubjectsController(ISubjectService subjectService) : Controller
{
    [Route("subjects/{id:int}/topics", Name = "SubjectWithTopics")]
    public async Task<IActionResult> SubjectWithTopics(int id)
    {
        var data = await subjectService.GetSubjectWithCategoryTopicsAsync(id);
        return View(data);
    }
}
