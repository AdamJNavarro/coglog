using System.ComponentModel.DataAnnotations;

namespace CogLog.App.Models.Identity;

public class RegistrationRequest
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [MinLength(6)]
    public string Password { get; set; }
}
