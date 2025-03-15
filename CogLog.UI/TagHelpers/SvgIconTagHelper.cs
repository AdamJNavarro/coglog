using Microsoft.AspNetCore.Razor.TagHelpers;

namespace CogLog.UI.TagHelpers;

[HtmlTargetElement("svg-icon")]
public class SvgIconTagHelper : TagHelper
{
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
        output.TagName = "svg";
        output.Attributes.SetAttribute("class", CssClass ?? "icon");
        output.Attributes.SetAttribute("width", Width);
        output.Attributes.SetAttribute("height", Height);
        output.Attributes.SetAttribute("aria-hidden", "true");

        output.Content.AppendHtml($"<use href=\"/svg/sprite.svg#icon-{IconName}\"></use>");

        // Make self-closing
        output.TagMode = TagMode.StartTagAndEndTag;
    }
}
