using System.ComponentModel.DataAnnotations;
using CogLog.UI.Models.Category;
using CogLog.UI.Models.Subject;
using CogLog.UI.Models.Tag;
using CogLog.UI.Models.Topic;

namespace CogLog.UI.Models.Block;

public class BlockVm : BaseBlockVm
{
    [Required]
    public DateTime DateAdded { get; init; }

    [Required]
    public required string Title { get; init; }

    [Required]
    public required string Content { get; init; }

    public string? ExtraContent { get; init; }

    public string? Url { get; init; }

    public int? SubjectId { get; init; }

    public SubjectMinimalVm? Subject { get; init; }

    public List<TopicMinimalVm>? Topics { get; init; }

    public List<TagMinimalVm>? Tags { get; init; }
}
