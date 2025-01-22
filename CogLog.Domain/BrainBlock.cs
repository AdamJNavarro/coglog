namespace CogLog.Domain;

public class BrainBlock : BaseEntity
{
    public DateTime? DateAdded { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;
    public string? AdditionalContext { get; set; } = string.Empty;

    public string? Url { get; set; } = string.Empty;

    public BrainBlockVariantEnum Variant { get; set; }
}
