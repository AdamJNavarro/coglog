using System.ComponentModel.DataAnnotations;
using CogLog.UI.Models.Common;

namespace CogLog.UI.Models.Subject;

public class BaseSubjectVm : BaseHierarchyVm
{
    public string? Icon { get; init; }

    [Required]
    public required int CategoryId { get; init; }
}
