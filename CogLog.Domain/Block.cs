using CogLog.Domain.Shared;

namespace CogLog.Domain;

public class Block : BaseEntity
{
    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime LearnedAt { get; set; }

    public required string Title { get; set; }
    public required string Content { get; set; }

    public string? ExtraContent { get; set; }

    public string? Url { get; set; }

    public Subject? Subject { get; init; }

    public int? SubjectId { get; set; }

    public List<BlockTopic> BlockTopics { get; set; } = [];

    public List<BlockTag> BlockTags { get; set; } = [];
}
