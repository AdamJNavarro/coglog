using CogLog.App.Constants;
using CogLog.App.Contracts.Data.Block;
using CogLog.Domain;
using CogLog.UI.Contracts;
using CogLog.UI.Models.Block;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CogLog.UI.Controllers;

public class BlocksController(IBlockService blockService) : Controller
{
    [ViewData]
    public string Title { get; set; }

    // INDEX - GET
    [AllowAnonymous]
    public async Task<IActionResult> Index([FromQuery] BlocksQueryParameters? parameters)
    {
        Title = "Cog Log";
        parameters ??= new BlocksQueryParameters();

        var data = await blockService.GetBlocksAsync(parameters);

        return View(data);
    }

    [Authorize(Roles = AuthConstants.Roles.Administrator)]
    [Route("blocks/{id:int}")]
    public async Task<IActionResult> Details(int id)
    {
        Title = "Block Details";
        var data = await blockService.GetBlockDetailsAsync(id);
        return View(data);
    }

    // CREATE - GET
    [Authorize(Roles = AuthConstants.Roles.Administrator)]
    public async Task<IActionResult> Create()
    {
        Title = "New Block";
        var vm = new BlockCreateVm();
        return View(vm);
    }

    // CREATE - POST
    [Authorize(Roles = AuthConstants.Roles.Administrator)]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(BlockCreateVm vm)
    {
        await blockService.CreateBlockAsync(vm);
        return RedirectToAction(nameof(Index));
    }

    [Authorize(Roles = AuthConstants.Roles.Administrator)]
    [Route("blocks/{id:int}/edit", Name = "EditBlock")]
    public async Task<IActionResult> Edit(int id)
    {
        Title = "Edit Block";
        var block = await blockService.GetBlockDetailsAsync(id);

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

    [Authorize(Roles = AuthConstants.Roles.Administrator)]
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

        var resp = await blockService.UpdateBlockAsync(block);

        return resp.Success ? RedirectToAction(nameof(Index)) : View(block);
    }

    [Authorize(Roles = AuthConstants.Roles.Administrator)]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        var response = await blockService.DeleteBlockAsync(id);

        return RedirectToAction(response.Success ? nameof(Index) : nameof(Edit));
    }
}
