using System.ComponentModel.DataAnnotations;
using CogLog.UI.Services.Base;

namespace CogLog.UI.Models;

public class BrainBlockVm : BaseBrainBlockVm
{
    [Required]
    public DateTime DateAdded { get; init; }

    [Required]
    public string Title { get; set; }

    [Required]
    public string Content { get; set; }

    [Required]
    public BrainBlockVariantEnum Variant { get; set; }

    public string? AdditionalContext { get; set; } = string.Empty;

    public string? Url { get; set; } = string.Empty;
}
