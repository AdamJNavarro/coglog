using CogLog.UI.Contracts;
using CogLog.UI.Models.Subject;
using CogLog.UI.Models.Tag;
using CogLog.UI.Models.Topic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CogLog.UI.Controllers;

public class SubjectsController(
    ISubjectService subjectService,
    ICategoryService categoryService,
    ITopicService topicService,
    ITagService tagService
) : Controller
{
    public async Task<IActionResult> Create([FromQuery] string? categoryId)
    {
        var vm = new SubjectCreateVm()
        {
            CategorySelectItems = await categoryService.GetSelectListAsync(),
        };

        if (!string.IsNullOrWhiteSpace(categoryId))
        {
            vm.CategoryId = Convert.ToInt32(categoryId);
        }

        return View(vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(SubjectCreateVm subject)
    {
        await subjectService.CreateSubjectAsync(subject);
        return RedirectToAction("Index", "Blocks");
    }

    [Route("subjects/{id:int}/topics", Name = "SubjectWithTopics")]
    public async Task<IActionResult> SubjectWithTopics(int id)
    {
        var data = await subjectService.GetSubjectWithCategoryTopicsAsync(id);
        return View(data);
    }

    [HttpGet]
    public async Task<IActionResult> GetSubjectsByCategory(int categoryId)
    {
        var data = await subjectService.GetSubjectsByCategoryAsync(categoryId);
        var subjects = data.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name,
            })
            .ToList();

        return Json(subjects);
    }

    [HttpGet("subjects/{id:int}/topics/create")]
    public IActionResult CreateTopic(int id)
    {
        return View();
    }

    [HttpPost("subjects/{id:int}/topics/create", Name = "CreateTopic")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateTopic(TopicCreateVm topic, int id)
    {
        await topicService.CreateTopicAsync(topic);
        return RedirectToRoute("SubjectWithTopics", new { id });
    }

    [HttpGet("subjects/{id:int}/tags/create")]
    public IActionResult CreateTag(int id)
    {
        return View();
    }

    [HttpPost("subjects/{id:int}/tags/create", Name = "CreateTag")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateTag(TagCreateVm tag, int id)
    {
        await tagService.CreateTagAsync(tag);
        return RedirectToRoute("Index");
    }
}
