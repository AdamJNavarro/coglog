using CogLog.UI.Contracts;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace CogLog.UI.TagHelpers;

[HtmlTargetElement("svg-icon")]
public class SvgIconTagHelper : TagHelper
{
    private readonly IHierarchyIconService _iconService;

    public SvgIconTagHelper(IHierarchyIconService iconService)
    {
        _iconService = iconService;
    }

    [HtmlAttributeName("name")]
    public string IconName { get; set; }

    [HtmlAttributeName("class")]
    public string CssClass { get; set; }

    [HtmlAttributeName("width")]
    public string Width { get; set; } = "24";

    [HtmlAttributeName("height")]
    public string Height { get; set; } = "24";

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        var iconToUse = _iconService.GetIcon(IconName);

        output.TagName = "svg";
        output.Attributes.SetAttribute("class", CssClass ?? "icon");
        output.Attributes.SetAttribute("width", Width);
        output.Attributes.SetAttribute("height", Height);
        output.Attributes.SetAttribute("aria-hidden", "true");

        output.Content.AppendHtml($"<use href=\"/svg/sprite.svg#icon-{iconToUse}\"></use>");

        // Make self-closing
        output.TagMode = TagMode.StartTagAndEndTag;
    }
}
