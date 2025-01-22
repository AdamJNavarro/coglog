using CogLog.UI.Services.Base;

namespace CogLog.UI.Models;

public class CreateBrainBlockVm
{
    public string Title { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;

    public string? AdditionalContext { get; set; } = string.Empty;

    public string? Url { get; set; } = string.Empty;

    public BrainBlockVariantEnum Variant { get; set; }
}
