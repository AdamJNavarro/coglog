using CogLog.UI.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CogLog.UI.Controllers;

public class TopicsController(ITopicService topicService) : Controller
{
    // INDEX
    public async Task<IActionResult> Index()
    {
        return View();
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> GetTopicsBySubject(int subjectId)
    {
        var data = await topicService.GetTopicsBySubjectAsync(subjectId);
        var topics = data.Select(x => new SelectListItem
        {
            Value = x.Id.ToString(),
            Text = x.Name,
        });
        return Json(topics);
    }
}
