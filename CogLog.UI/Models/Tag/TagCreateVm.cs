using System.ComponentModel.DataAnnotations;
using CogLog.UI.Models.Shared.Hierarchy;

namespace CogLog.UI.Models.Tag;

public class TagCreateVm : HierarchyBaseWriteVm
{
    [Required]
    public int SubjectId { get; set; }
}
