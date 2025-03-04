using System.ComponentModel.DataAnnotations;
using CogLog.UI.Models.Common;

namespace CogLog.UI.Models.Category;

public class BaseCategoryVm : BaseHierarchyVm
{
    public required string Icon { get; init; }
}
