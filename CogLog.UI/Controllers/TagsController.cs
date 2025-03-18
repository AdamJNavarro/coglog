using CogLog.UI.Contracts;
using CogLog.UI.Models.Tag;
using Microsoft.AspNetCore.Mvc;

namespace CogLog.UI.Controllers;

public class TagsController(ITagService tagService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var data = await tagService.GetTagsAsync();
        return View(data);
    }

    [Route("tags/{id:int}")]
    public async Task<IActionResult> Details(int id)
    {
        var data = await tagService.GetTagDetailsAsync(id);
        return View(data);
    }

    public async Task<IActionResult> Create([FromQuery] string? subjectId)
    {
        var vm = new TagCreateVm();

        if (!string.IsNullOrWhiteSpace(subjectId))
        {
            vm.SubjectId = Convert.ToInt32(subjectId);
        }

        return View(vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(TagCreateVm tag)
    {
        await tagService.CreateTagAsync(tag);
        return RedirectToAction(nameof(Index));
    }

    [Route("tags/{id:int}/edit", Name = "EditTag")]
    public async Task<IActionResult> Edit(int id)
    {
        var tag = await tagService.GetTagDetailsAsync(id);

        var vm = new TagEditVm()
        {
            Id = tag.Id,
            Name = tag.Name,
            Icon = tag.Icon,
            Description = tag.Description,
            SubjectId = tag.SubjectId,
        };
        return View(vm);
    }

    [HttpPost]
    [Route("tags/{id:int}/edit", Name = "EditTag")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, TagEditVm tag)
    {
        if (id != tag.Id)
        {
            return NotFound();
        }

        var resp = await tagService.UpdateTagAsync(tag);

        return resp.Success ? RedirectToAction(nameof(Index)) : View(tag);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        var response = await tagService.DeleteTagAsync(id);

        return RedirectToAction(response.Success ? nameof(Index) : nameof(Edit));
    }

    [HttpGet]
    public async Task<IActionResult> GetTagsBySubject(int subjectId)
    {
        var data = await tagService.GetSelectListAsync(subjectId);
        return Json(data);
    }
}
