using CogLog.App.Contracts.Data.Block;
using CogLog.Domain;
using CogLog.UI.Contracts;
using CogLog.UI.Models.Block;
using Microsoft.AspNetCore.Mvc;

namespace CogLog.UI.Controllers;

public class BlocksController(IBlockService blockService) : Controller
{
    // INDEX - GET
    public async Task<IActionResult> Index([FromQuery] BlocksQueryParameters? parameters)
    {
        parameters ??= new BlocksQueryParameters();

        var data = await blockService.GetBlocksAsync(parameters);

        return View(data);
    }

    [Route("blocks/{id:int}")]
    public async Task<IActionResult> Details(int id)
    {
        var data = await blockService.GetBlockDetailsAsync(id);
        return View(data);
    }

    // CREATE - GET
    public async Task<IActionResult> Create()
    {
        var vm = new BlockCreateVm();
        return View(vm);
    }

    // CREATE - POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(BlockCreateVm vm)
    {
        await blockService.CreateBlockAsync(vm);
        return RedirectToAction(nameof(Index));
    }

    [Route("blocks/{id:int}/edit", Name = "EditBlock")]
    public async Task<IActionResult> Edit(int id)
    {
        var block = await blockService.GetBlockDetailsAsync(id);
        Console.WriteLine("STI");
        Console.WriteLine(block.Topics.Select(x => x.Id).ToList()[0]);

        var vm = new BlockEditVm()
        {
            Id = block.Id,
            Title = block.Title,
            Content = block.Content,
            ExtraContent = block.ExtraContent,
            Url = block.Url,
            SubjectId = block.SubjectId,
            SelectedTopicIds = block.Topics.Select(t => t.Id).ToList(),
            SelectedTagIds = block.Tags.Select(t => t.Id).ToList(),
        };
        return View(vm);
    }

    [HttpPost]
    [Route("blocks/{id:int}/edit", Name = "EditBlock")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, BlockEditVm block)
    {
        if (id != block.Id)
        {
            return NotFound();
        }

        var selectedIds = string.Join(", ", block.SelectedTopicIds);
        Console.WriteLine($"Selected IDs: {selectedIds}");

        var resp = await blockService.UpdateBlockAsync(block);

        return resp.Success ? RedirectToAction(nameof(Index)) : View(block);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        var response = await blockService.DeleteBlockAsync(id);

        return RedirectToAction(response.Success ? nameof(Index) : nameof(Edit));
    }

    // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    // public IActionResult Error()
    // {
    //     return View(
    //         new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier }
    //     );
    // }
    //
    // public IActionResult NotAuthorized()
    // {
    //     return View();
    // }
}
