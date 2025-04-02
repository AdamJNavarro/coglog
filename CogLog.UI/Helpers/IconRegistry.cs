namespace CogLog.UI.Helpers;

public static class IconRegistry
{
    // Dictionary of all available icons in your spritesheet
    public static readonly HashSet<string> AvailableIcons = new HashSet<string>
    {
        "home",
        "user",
        "settings",
        // Add all your icons here
    };

    // Check if an icon exists
    public static bool IconExists(string iconName)
    {
        return !string.IsNullOrEmpty(iconName) && AvailableIcons.Contains(iconName);
    }

    public static string GetFallbackIcon(string iconType)
    {
        return "settings";
    }
}
