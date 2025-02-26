using System.ComponentModel.DataAnnotations;
using CogLog.UI.Models.Common;

namespace CogLog.UI.Models.Subject;

public class SubjectVm : BaseHierarchyVm
{
    public string? Icon { get; init; }

    [Required]
    public required int Category { get; init; }

    // CategoryVm

    // List TopicVm

    // List TagVm

    // List BlockVm
}
