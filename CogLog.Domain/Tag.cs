using CogLog.Domain.Common;

namespace CogLog.Domain;

public class Tag : BaseEntity
{
    public string? Icon { get; init; }

    public required int SubjectId { get; init; }

    public Subject Subject { get; init; }

    public List<BrainBlockTag> BrainBlockTags { get; init; } = [];
}
