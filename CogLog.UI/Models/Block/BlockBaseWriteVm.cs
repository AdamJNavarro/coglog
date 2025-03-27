using System.ComponentModel.DataAnnotations;

namespace CogLog.UI.Models.Block;

public abstract class BlockBaseWriteVm
{
    [Required]
    public DateTime LearnedAt { get; set; }

    [Required]
    public string Title { get; set; }

    [Required]
    public string Content { get; set; }

    public string? ExtraContent { get; set; }

    public string? Url { get; set; }
}
