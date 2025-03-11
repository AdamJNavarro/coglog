using System.ComponentModel.DataAnnotations;
using CogLog.App.Constants;

namespace CogLog.UI.Models.Topic;

public class TopicCreateVm
{
    [Required]
    [MinLength(
        ValidationConstants.Topic.NameMinLength,
        ErrorMessage = "Must be {1}+ characters long."
    )]
    public string Name { get; init; }

    public string? Icon { get; init; }

    public string? Description { get; init; }

    [Required]
    public int SubjectId { get; init; }
}
