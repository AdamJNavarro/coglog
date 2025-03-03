using CogLog.UI.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CogLog.UI.Controllers;

public class CategoriesController(ICategoryService categoryService) : Controller
{
    // INDEX - GET
    public async Task<IActionResult> Index()
    {
        var data = await categoryService.GetCategoriesAsync();
        return View(data);
    }
}
