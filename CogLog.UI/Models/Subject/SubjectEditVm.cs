using System.ComponentModel.DataAnnotations;
using CogLog.App.Constants;

namespace CogLog.UI.Models.Subject;

public class SubjectEditVm
{
    public int Id { get; init; }

    [Required]
    [MinLength(ValidationConstants.Subject.NameMinLength)]
    public string Name { get; init; }

    public string? Icon { get; init; }

    public string? Description { get; init; }

    [Required]
    public int CategoryId { get; init; }
}
