namespace CogLog.Domain;

public class Topic : BaseEntity
{
    public string Title { get; set; } = string.Empty;

    public string? Logo { get; set; } = string.Empty;

    public List<BrainBlock> BrainBlocks { get; set; } = [];
}
