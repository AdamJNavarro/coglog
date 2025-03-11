using System.ComponentModel.DataAnnotations;
using CogLog.App.Constants;

namespace CogLog.UI.Models.Category;

public class CategoryEditVm
{
    public int Id { get; init; }

    [Required]
    [MinLength(ValidationConstants.Category.NameMinLength)]
    public string Name { get; init; }

    public string? Icon { get; init; }

    public string? Description { get; init; }
}
