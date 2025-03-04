using CogLog.UI.Contracts;
using CogLog.UI.Models.Category;
using CogLog.UI.Models.Subject;
using Microsoft.AspNetCore.Mvc;

namespace CogLog.UI.Controllers;

public class CategoriesController(ICategoryService categoryService, ISubjectService subjectService)
    : Controller
{
    // INDEX - GET
    public async Task<IActionResult> Index()
    {
        var data = await categoryService.GetCategoriesAsync();
        return View(data);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateCategoryVm category)
    {
        await categoryService.CreateCategoryAsync(category);
        return RedirectToAction(nameof(Index));
    }

    [Route("categories/{id:int}/subjects", Name = "CategoryWithSubjects")]
    public async Task<IActionResult> CategoryWithSubjects(int id)
    {
        var data = await categoryService.GetCategoryWithSubjectsAsync(id);
        return View(data);
    }

    [Route("categories/{id:int}/subjects/create")]
    public IActionResult CreateSubject(int id)
    {
        return View();
    }

    [HttpPost("categories/{id:int}/subjects/create", Name = "CreateSubject")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateSubject(CreateSubjectVm subject, int id)
    {
        await subjectService.CreateSubjectAsync(subject);
        return RedirectToRoute("CategoryWithSubjects", new { id });
    }
}
