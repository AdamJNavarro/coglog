using CogLog.UI.Contracts;
using CogLog.UI.Models.Category;
using CogLog.UI.Models.Subject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CogLog.UI.Controllers;

public class CategoriesController(ICategoryService categoryService) : Controller
{
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

    [Route("categories/{id:int}")]
    public async Task<IActionResult> Details(int id)
    {
        var data = await categoryService.GetCategoryDetailsAsync(id);
        return View(data);
    }

    [Route("categories/{id:int}/edit", Name = "EditCategory")]
    public async Task<IActionResult> Edit(int id)
    {
        var category = await categoryService.GetCategoryDetailsAsync(id);

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

        return View(category);
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

        return RedirectToAction(nameof(Edit));
    }
}
