using System.ComponentModel.DataAnnotations;
using CogLog.UI.Models.Shared.Hierarchy;

namespace CogLog.UI.Models.Topic;

public class TopicEditVm : HierarchyBaseEditVm
{
    [Required]
    public int SubjectId { get; set; }
}
