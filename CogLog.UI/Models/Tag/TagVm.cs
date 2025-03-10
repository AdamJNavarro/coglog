using System.ComponentModel.DataAnnotations;
using CogLog.UI.Models.Shared.Hierarchy;

namespace CogLog.UI.Models.Tag;

public class TagVm : HierarchyBaseMinimalVm
{
    [Required]
    public required int SubjectId { get; init; }

    // SubjectVm

    // List BlockTagVm
}
