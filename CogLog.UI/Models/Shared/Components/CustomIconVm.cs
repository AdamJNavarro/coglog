using System.ComponentModel.DataAnnotations;

namespace CogLog.UI.Models.Shared.Components;

public class CustomIconVm
{
    [Required]
    public string IconName { get; init; }
}
