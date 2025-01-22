using System.Diagnostics;
using CogLog.UI.Contracts;
using CogLog.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CogLog.UI.Controllers;

public class HomeController(IBrainBlockService brainBlockService, ILogger<HomeController> _logger)
    : Controller
{
    // INDEX - GET
    public async Task<IActionResult> Index()
    {
        var data = await brainBlockService.GetBrainBlocks();
        var sortedData = data.OrderByDescending(x => x.DateAdded).ToList();
        return View(sortedData);
    }

    // DETAILS - GET
    public async Task<IActionResult> Details(int id)
    {
        var brainBlock = await brainBlockService.GetBrainBlockById(id);

        return View(brainBlock);
    }

    // CREATE - GET
    public IActionResult Create()
    {
        return View();
    }

    // CREATE - POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateBrainBlockVm createBrainBlock)
    {
        await brainBlockService.CreateBrainBlock(createBrainBlock);
        return RedirectToAction(nameof(Index));
    }

    // EDIT - GET
    public async Task<IActionResult> Edit(int id)
    {
        var brainBlock = await brainBlockService.GetBrainBlockById(id);
        return View(brainBlock);
    }

    // EDIT - POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, BrainBlockVm brainBlock)
    {
        if (id != brainBlock.Id)
        {
            return NotFound();
        }
        var response = await brainBlockService.EditBrainBlock(id, brainBlock);
        Console.WriteLine(response.ToString());
        if (response.Success)
        {
            return RedirectToAction(nameof(Index));
        }
        return View(brainBlock);
    }

    // DELETE - POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        var response = await brainBlockService.DeleteBrainBlock(id);
        if (response.Success)
        {
            // show toast
        }
        return RedirectToAction(nameof(Index));
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(
            new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier }
        );
    }

    public IActionResult NotAuthorized()
    {
        return View();
    }
}
