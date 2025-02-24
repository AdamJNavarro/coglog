using System.ComponentModel.DataAnnotations;
using CogLog.UI.Services.Base;

namespace CogLog.UI.Models.Block;

public class EditBlockVm : BaseBlockVm
{
    [Required]
    public required string Title { get; init; }

    [Required]
    public required string Content { get; init; }

    public string? ExtraContent { get; init; }

    public string? Url { get; init; }
}
