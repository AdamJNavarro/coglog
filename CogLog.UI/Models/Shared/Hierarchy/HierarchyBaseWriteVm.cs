using System.ComponentModel.DataAnnotations;
using CogLog.App.Constants;

namespace CogLog.UI.Models.Shared.Hierarchy;

public abstract class HierarchyBaseWriteVm
{
    [Required]
    [MinLength(
        ValidationConstants.Hierarchy.NameMinLength,
        ErrorMessage = "{0} must be {1}+ characters long."
    )]
    public string Name { get; init; }

    public string? Icon { get; init; }

    public string? Description { get; init; }
}
