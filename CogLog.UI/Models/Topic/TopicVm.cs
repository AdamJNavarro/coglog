using System.ComponentModel.DataAnnotations;
using CogLog.UI.Models.Shared.Hierarchy;

namespace CogLog.UI.Models.Topic;

public class TopicVm : HierarchyBaseMinimalVm
{
    [Required]
    public required int SubjectId { get; init; }

    // SubjectVm

    // List BlockTopicVm
}
