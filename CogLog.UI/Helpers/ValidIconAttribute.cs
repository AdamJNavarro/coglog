using System.ComponentModel.DataAnnotations;
using CogLog.UI.Contracts;

namespace CogLog.UI.Helpers;

public class ValidIconAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        var iconService = validationContext.GetService<IHierarchyIconService>();
        var iconName = value as string;

        if (string.IsNullOrEmpty(iconName))
            return ValidationResult.Success; // Allow empty (will use default)

        if (!iconService.IsValidIcon(iconName))
        {
            return new ValidationResult($"The icon '{iconName}' does not exist in the system.");
        }

        return ValidationResult.Success;
    }
}
