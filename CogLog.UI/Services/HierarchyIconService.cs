using CogLog.UI.Contracts;
using CogLog.UI.Helpers;

namespace CogLog.UI.Services;

public class HierarchyIconService : IHierarchyIconService
{
    public string GetIcon(string iconName)
    {
        return iconName;
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
