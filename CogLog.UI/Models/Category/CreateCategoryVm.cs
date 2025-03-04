using System.ComponentModel.DataAnnotations;

namespace CogLog.UI.Models.Category;

public class CreateCategoryVm
{
    [Required(ErrorMessage = "Label is required!")]
    public required string Label { get; init; }

    public required string Icon { get; init; }

    public string? Description { get; init; }
}
