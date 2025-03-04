using System.ComponentModel.DataAnnotations;
using CogLog.UI.Models.Category;
using CogLog.UI.Models.Common;

namespace CogLog.UI.Models.Subject;

public class SubjectVm : BaseHierarchyVm
{
    public string? Icon { get; init; }

    public required BaseCategoryVm Category { get; init; }
}
