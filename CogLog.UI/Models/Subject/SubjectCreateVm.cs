using System.ComponentModel.DataAnnotations;
using CogLog.App.Constants;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CogLog.UI.Models.Subject;

public class SubjectCreateVm
{
    [Required]
    [MinLength(
        ValidationConstants.Subject.NameMinLength,
        ErrorMessage = "{0} must be {1}+ characters long."
    )]
    public string Name { get; init; }

    public string? Icon { get; init; }

    public string? Description { get; init; }

    [Required]
    public int CategoryId { get; set; }

    public IEnumerable<SelectListItem> CategorySelectItems { get; init; } = [];
}
