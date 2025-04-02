using CogLog.App.Constants;
using CogLog.UI.Contracts;
using CogLog.UI.Models.Category;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CogLog.UI.Controllers;

[Authorize(Roles = AuthConstants.Roles.Administrator)]
public class CategoriesController(ICategoryService categoryService) : Controller
{
    [ViewData]
    public string Title { get; set; }

    public async Task<IActionResult> Index()
    {
        Title = "Categories";
        var data = await categoryService.GetCategoriesAsync();
        return View(data);
    }

    public IActionResult Create()
    {
        Title = "New Category";
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
        Title = "Category Details";
        return View(data);
    }

    [Route("categories/{id:int}/edit", Name = "EditCategory")]
    public async Task<IActionResult> Edit(int id)
    {
        var category = await categoryService.GetCategoryDetailsAsync(id);

        Title = "Edit Category";

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
