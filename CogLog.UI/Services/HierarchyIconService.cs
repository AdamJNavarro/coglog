using CogLog.UI.Contracts;
using CogLog.UI.Helpers;

namespace CogLog.UI.Services;

public class HierarchyIconService : IHierarchyIconService
{
    public string GetIcon(string iconName)
    {
        if (!string.IsNullOrEmpty(iconName) && IconRegistry.IconExists(iconName))
            return iconName;

        var normalizedName = iconName.ToLower().Replace(" ", "-");
        if (IconRegistry.IconExists(normalizedName))
        {
            return normalizedName;
        }

        return IconRegistry.GetFallbackIcon("custom");
    }

    public bool IsValidIcon(string iconName)
    {
        return IconRegistry.IconExists(iconName);
    }

    public IEnumerable<string> GetAllAvailableIcons()
    {
        return IconRegistry.AvailableIcons;
    }
}
