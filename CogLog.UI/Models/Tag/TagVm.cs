using System.ComponentModel.DataAnnotations;

namespace CogLog.UI.Models.Tag;

public class TagVm
{
    [Required]
    public required int Id { get; init; }

    [Required]
    public string Label { get; init; }

    public string? Icon { get; init; }

    [Required]
    public required int SubjectId { get; init; }

    // SubjectVm

    // List BlockTagVm
}
