using System.Diagnostics;
using CogLog.UI.Contracts;
using CogLog.UI.Models;
using CogLog.UI.Models.Block;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CogLog.UI.Controllers;

public class HomeController(IBlockService blockService, ILogger<HomeController> _logger)
    : Controller
{
    // INDEX - GET
    public async Task<IActionResult> Index()
    {
        var data = await blockService.GetBrainBlocks();
        var sortedData = data.OrderByDescending(x => x.DateAdded).ToList();
        return View(sortedData);
    }

    // DETAILS - GET
    public async Task<IActionResult> Details(int id)
    {
        var brainBlock = await blockService.GetBrainBlockById(id);

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
    public async Task<IActionResult> Create(CreateBlockVm createBlock)
    {
        await blockService.CreateBrainBlock(createBlock);
        return RedirectToAction(nameof(Index));
    }

    // EDIT - GET
    public async Task<IActionResult> Edit(int id)
    {
        var brainBlock = await blockService.GetBrainBlockById(id);
        return View(brainBlock);
    }

    // EDIT - POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, BlockVm block)
    {
        if (id != block.Id)
        {
            return NotFound();
        }
        var response = await blockService.EditBrainBlock(id, block);
        Console.WriteLine(response.ToString());
        if (response.Success)
        {
            return RedirectToAction(nameof(Index));
        }
        return View(block);
    }

    // DELETE - POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        var response = await blockService.DeleteBrainBlock(id);
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
