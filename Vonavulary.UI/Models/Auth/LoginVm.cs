using System.ComponentModel.DataAnnotations;

namespace Vonavulary.UI.Models.Auth;

public class LoginVm
{
    [Required]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;
}
