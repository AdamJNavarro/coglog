using System.ComponentModel.DataAnnotations;
using CogLog.UI.Models.Common;

namespace CogLog.UI.Models.Topic;

public class TopicVm : BaseHierarchyVm
{
    public string? Icon { get; init; }

    [Required]
    public required int SubjectId { get; init; }

    // SubjectVm

    // List BlockTopicVm
}
