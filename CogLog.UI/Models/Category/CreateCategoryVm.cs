using System.ComponentModel.DataAnnotations;

namespace CogLog.UI.Models.Category;

public class CreateCategoryVm
{
    [Required(ErrorMessage = "Name is required!")]
    public required string Name { get; init; }

    public string? Icon { get; init; }

    public string? Description { get; init; }
}
