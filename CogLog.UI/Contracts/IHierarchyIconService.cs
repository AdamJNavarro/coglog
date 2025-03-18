namespace CogLog.UI.Contracts;

public interface IHierarchyIconService
{
    string? GetIcon(string iconName);
    bool IsValidIcon(string iconName);
    IEnumerable<string> GetAllAvailableIcons();
}
