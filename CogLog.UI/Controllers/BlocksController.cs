using CogLog.UI.Contracts;
using CogLog.UI.Models.Block;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CogLog.UI.Controllers;

public class BlocksController(
    IBlockService blockService,
    ICategoryService categoryService,
    ISubjectService subjectService,
    ITopicService topicService
) : Controller
{
    // INDEX - GET
    public async Task<IActionResult> Index()
    {
        var data = await blockService.GetBlocksAsync();
        var sortedData = data.OrderByDescending(x => x.DateAdded).ToList();
        // Console.WriteLine("SD");
        // Console.WriteLine(sortedData);
        // Console.WriteLine(sortedData.ToString());
        return View(sortedData);
    }

    public async Task<IActionResult> Play()
    {
        var data = await blockService.GetBlocksByDayAsync();

        return View(data);
    }

    // CREATE - GET
    public async Task<IActionResult> Create()
    {
        var categories = await categoryService.GetCategoriesAsync();
        var vm = new CreateBlockVm
        {
            Categories = categories
                .Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Label })
                .ToList(),
        };

        return View(vm);
    }

    // CREATE - POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateBlockVm vm)
    {
        await blockService.CreateBlockAsync(vm);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> GetSubjectsByCategory(int categoryId)
    {
        var data = await subjectService.GetSubjectsByCategoryAsync(categoryId);
        var subjects = data.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Label,
            })
            .ToList();

        return Json(subjects);
    }

    [HttpGet]
    public async Task<IActionResult> GetTopicsBySubject(int subjectId)
    {
        var data = await topicService.GetTopicsBySubjectAsync(subjectId);
        var topics = data.Select(x => new SelectListItem
        {
            Value = x.Id.ToString(),
            Text = x.Label,
        });
        return Json(topics);
    }
}
