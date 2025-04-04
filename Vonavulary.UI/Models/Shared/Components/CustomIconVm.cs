using System.ComponentModel.DataAnnotations;

namespace Vonavulary.UI.Models.Shared.Components;

public class CustomIconVm
{
    [Required]
    public string IconName { get; init; }
}
