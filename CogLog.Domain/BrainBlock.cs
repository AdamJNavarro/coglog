using CogLog.Domain.Common;
using CogLog.Domain.Hierarchy;

namespace CogLog.Domain;

public class BrainBlock : BaseEntity
{
    public DateTime? DateAdded { get; set; }

    public required string Title { get; init; }
    public required string Content { get; init; }

    public string? ExtraContent { get; init; }

    public string? Url { get; init; }

    public Category? Category { get; init; }

    public int? CategoryId { get; init; }

    public Subject? Subject { get; init; }

    public int? SubjectId { get; init; }

    public List<Topic> Topics { get; init; } = [];

    public List<Tag> Tags { get; init; } = [];
}
