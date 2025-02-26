using CogLog.UI.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CogLog.UI.Controllers;

public class TopicController(ITopicService topicService) : Controller
{
    // INDEX
    public async Task<IActionResult> Index()
    {
        var data = await topicService.GetTopicsAsync();
        return View(data);
    }
}
