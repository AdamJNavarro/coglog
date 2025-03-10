using System.ComponentModel.DataAnnotations;
using CogLog.UI.Models.Shared.Hierarchy;

namespace CogLog.UI.Models.Subject;

public class BaseSubjectVm : HierarchyBaseMinimalVm
{
    public required int CategoryId { get; init; }
}
