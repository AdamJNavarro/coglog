using System.ComponentModel.DataAnnotations;
using CogLog.UI.Models.Category;
using CogLog.UI.Models.Shared.Hierarchy;

namespace CogLog.UI.Models.Subject;

public class SubjectVm : HierarchyBaseMinimalVm
{
    public required BaseCategoryVm Category { get; init; }
}
