using CogLog.Domain.Common;

namespace CogLog.Domain;

public class BrainBlock : BaseEntity
{
    public DateTime? DateAdded { get; set; }

    public required string Title { get; init; }
    public required string Content { get; init; }

    public string? ExtraContent { get; init; }

    public string? Url { get; init; }

    public Category? Category { get; init; }

    public int? CategoryId { get; set; }

    public Subject? Subject { get; init; }

    public int? SubjectId { get; set; }

    public List<BrainBlockTopic> BrainBlockTopics { get; set; } = [];

    public List<BrainBlockTag> BrainBlockTags { get; set; } = [];
}
