using CogLog.App.Contracts.Data.Block;
using CogLog.UI.Contracts;
using CogLog.UI.Models.Block;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CogLog.UI.Controllers;

public class BlocksController(IBlockService blockService) : Controller
{
    // INDEX - GET
    public async Task<IActionResult> Index([FromQuery] BlocksQueryParameters parameters)
    {
        if (parameters == null)
        {
            parameters = new BlocksQueryParameters();
        }

        var data = await blockService.GetBlocksAsync(parameters);

        return View(data);
    }

    public async Task<IActionResult> Play()
    {
        var data = await blockService.GetBlocksByDayAsync();

        return View(data);
    }

    // CREATE - GET
    public async Task<IActionResult> Create()
    {
        var vm = new CreateBlockVm { };

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
}
