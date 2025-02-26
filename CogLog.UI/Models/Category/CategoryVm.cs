using System.ComponentModel.DataAnnotations;
using CogLog.UI.Models.Common;

namespace CogLog.UI.Models.Category;

public class CategoryVm : BaseHierarchyVm
{
    [Required]
    public required string Icon { get; init; }

    // List SubjectVM

    // List BlockVM??
}
