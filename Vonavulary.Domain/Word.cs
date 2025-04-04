using Vonavulary.Domain.Shared;

namespace Vonavulary.Domain;

public class Word : BaseEntity
{
    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime LearnedAt { get; set; }

    public required string Spelling { get; set; }
    public required string Definition { get; set; }
    public string? ExtraInfo { get; set; }

    public Language Language { get; set; }

    public PartOfSpeech? PartOfSpeech { get; set; }
}
