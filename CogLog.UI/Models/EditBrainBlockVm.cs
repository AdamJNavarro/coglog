using System.ComponentModel.DataAnnotations;
using CogLog.UI.Services.Base;

namespace CogLog.UI.Models;

public class EditBrainBlockVm : BaseBrainBlockVm
{
    [Required]
    public string Title { get; set; } = string.Empty;

    [Required]
    public string Content { get; set; } = string.Empty;

    public string? AdditionalContext { get; set; } = string.Empty;

    public string? Url { get; set; } = string.Empty;

    [Required]
    public BrainBlockVariantEnum Variant { get; set; }
}
