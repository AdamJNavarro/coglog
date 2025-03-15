using Microsoft.AspNetCore.Mvc;

namespace CogLog.UI.Components;

public class SvgIcon : ViewComponent
{
    private readonly IWebHostEnvironment _webHostEnvironment;

    public SvgIcon(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }

    public IViewComponentResult Invoke()
    {
        var spritePath = Path.Combine(_webHostEnvironment.WebRootPath, "svg", "sprite.svg");
        var spriteContent = File.ReadAllText(spritePath);

        ViewBag.SpriteContent = spriteContent;
        return View();
    }
}
