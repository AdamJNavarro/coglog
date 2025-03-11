using CogLog.UI.Contracts;
using CogLog.UI.Models.Subject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CogLog.UI.Controllers;

public class SubjectsController(ISubjectService subjectService, ICategoryService categoryService)
    : Controller
{
    public async Task<IActionResult> Create()
    {
        var data = await categoryService.GetCategoriesAsync();
        var categories = data.Select(x => new SelectListItem
        {
            Value = x.Id.ToString(),
            Text = x.Name,
        });

        var vm = new SubjectCreateVm() { Categories = categories };

        return View(vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(SubjectCreateVm subject)
    {
        await subjectService.CreateSubjectAsync(subject);
        return RedirectToAction(nameof(Index));
    }

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
