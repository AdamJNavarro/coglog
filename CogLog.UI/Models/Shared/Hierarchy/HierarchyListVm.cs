namespace CogLog.UI.Models.Shared.Hierarchy;

public class HierarchyListVm
{
    public IEnumerable<HierarchyBaseMinimalVm> Items { get; set; }
    public string Controller { get; set; }
    public string Action { get; set; }
}
