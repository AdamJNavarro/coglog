using CogLog.UI.Models.Subject;
using CogLog.UI.Models.Tag;
using CogLog.UI.Models.Topic;

namespace CogLog.UI.Models.Block;

public class BlockDetailsVm
{
    public int Id { get; init; }

    public DateTime LearnedAt { get; init; }

    public string Title { get; init; }

    public string Content { get; init; }

    public string? ExtraContent { get; init; }

    public string? Url { get; init; }

    public int? SubjectId { get; init; }

    public SubjectMinimalVm? Subject { get; init; }

    public List<TopicMinimalVm>? Topics { get; init; }

    public List<TagMinimalVm>? Tags { get; init; }
}
