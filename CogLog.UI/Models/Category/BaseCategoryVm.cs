using System.ComponentModel.DataAnnotations;
using CogLog.UI.Models.Shared.Hierarchy;

namespace CogLog.UI.Models.Category;

public class BaseCategoryVm : HierarchyBaseMinimalVm
{
    public string? Icon { get; init; }
}
