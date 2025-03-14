using CogLog.UI.Contracts;
using CogLog.UI.Models.Subject;
using CogLog.UI.Models.Topic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CogLog.UI.Controllers;

public class TopicsController(ITopicService topicService, ISubjectService subjectService)
    : Controller
{
    // INDEX
    public async Task<IActionResult> Index()
    {
        var data = await topicService.GetTopicsAsync();
        return View(data);
    }

    [Route("topics/{id:int}")]
    public async Task<IActionResult> Details(int id)
    {
        var data = await topicService.GetTopicDetailsAsync(id);
        return View(data);
    }

    public async Task<IActionResult> Create([FromQuery] string? subjectId)
    {
        var vm = new TopicCreateVm
        {
            SubjectSelectItems = await subjectService.GetSelectListAsync(null),
        };

        if (!string.IsNullOrWhiteSpace(subjectId))
        {
            vm.SubjectId = Convert.ToInt32(subjectId);
        }

        return View(vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(TopicCreateVm topic)
    {
        await topicService.CreateTopicAsync(topic);
        return RedirectToAction(nameof(Index));
    }

    [Route("topics/{id:int}/edit", Name = "EditTopic")]
    public async Task<IActionResult> Edit(int id)
    {
        var topic = await topicService.GetTopicDetailsAsync(id);

        var vm = new TopicEditVm()
        {
            Id = topic.Id,
            Name = topic.Name,
            Icon = topic.Icon,
            Description = topic.Description,
            SubjectId = topic.SubjectId,
        };
        return View(vm);
    }

    // [HttpPost]
    // [Route("topics/{id:int}/edit", Name = "EditTopic")]
    // [ValidateAntiForgeryToken]
    // public async Task<IActionResult> Edit(int id, TopicEditVm topic)
    // {
    //     if (id != topic.Id)
    //     {
    //         return NotFound();
    //     }
    //
    //     var resp = await topicService.UpdateTopicAsync(topic);
    //
    //     if (resp.Success)
    //     {
    //         return RedirectToAction(nameof(Index));
    //     }
    //     else
    //     {
    //         return View(topic);
    //     }
    // }

    [HttpGet]
    public async Task<IActionResult> GetTopicsBySubject(int subjectId)
    {
        var data = await topicService.GetSelectListAsync(subjectId);

        return Json(data);
    }
}
