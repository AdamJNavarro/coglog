using CogLog.Domain.Shared;

namespace CogLog.Domain;

public class Block : BaseEntity
{
    public DateTime? DateAdded { get; set; }

    public required string Title { get; init; }
    public required string Content { get; init; }

    public string? ExtraContent { get; init; }

    public string? Url { get; init; }

    public Subject? Subject { get; init; }

    public int? SubjectId { get; set; }

    public List<BlockTopic> BlockTopics { get; set; } = [];

    public List<BlockTag> BlockTags { get; set; } = [];
}
