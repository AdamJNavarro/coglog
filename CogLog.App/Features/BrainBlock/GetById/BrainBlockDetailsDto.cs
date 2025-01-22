using CogLog.Domain;

namespace CogLog.App.Features.BrainBlock.GetById;

public class BrainBlockDetailsDto
{
    public int Id { get; set; }

    public DateTime DateAdded { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;

    public string? Url { get; set; } = string.Empty;

    public BrainBlockVariantEnum Variant { get; set; }

    public string? AdditionalContext { get; set; }
}
