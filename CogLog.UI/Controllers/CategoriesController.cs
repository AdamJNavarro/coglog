using CogLog.UI.Contracts;
using CogLog.UI.Models.Category;
using CogLog.UI.Models.Subject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
    public async Task<IActionResult> Create(CategoryCreateVm category)
    {
        await categoryService.CreateCategoryAsync(category);
        return RedirectToAction(nameof(Index));
    }

    [Route("categories/{id:int}/edit", Name = "EditCategory")]
    public async Task<IActionResult> Edit(int id)
    {
        var category = await categoryService.GetCategoryAsync(id);

        if (category == null)
        {
            return NotFound();
        }

        var vm = new CategoryEditVm()
        {
            Id = category.Id,
            Name = category.Name,
            Icon = category.Icon,
            Description = category.Description,
        };
        return View(vm);
    }

    [HttpPost]
    [Route("categories/{id:int}/edit", Name = "EditCategory")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, CategoryEditVm category)
    {
        if (id != category.Id)
        {
            return NotFound();
        }

        var resp = await categoryService.UpdateCategoryAsync(category);

        if (resp.Success)
        {
            return RedirectToAction(nameof(Index));
        }
        else
        {
            return View(category);
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        var response = await categoryService.DeleteCategoryAsync(id);
        if (response.Success)
        {
            // show toast
            return RedirectToAction(nameof(Index));
        }
        else
        {
            return RedirectToAction(nameof(Edit));
        }
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
    public async Task<IActionResult> CreateSubject(SubjectCreateVm subject, int id)
    {
        await subjectService.CreateSubjectAsync(subject);
        return RedirectToRoute("CategoryWithSubjects", new { id });
    }
}
