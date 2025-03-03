using CogLog.UI.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CogLog.UI.Controllers;

public class BlocksController(IBlockService blockService) : Controller
{
    // INDEX - GET
    public async Task<IActionResult> Index()
    {
        var data = await blockService.GetBlocksAsync();
        var sortedData = data.OrderByDescending(x => x.DateAdded).ToList();
        return View(sortedData);
    }
}
