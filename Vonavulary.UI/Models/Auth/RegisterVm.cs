using System.ComponentModel.DataAnnotations;

namespace Vonavulary.UI.Models.Auth;

public class RegisterVm
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}
