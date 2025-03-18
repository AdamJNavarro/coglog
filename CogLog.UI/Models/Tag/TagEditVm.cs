using System.ComponentModel.DataAnnotations;
using CogLog.UI.Models.Shared.Hierarchy;

namespace CogLog.UI.Models.Tag;

public class TagEditVm : HierarchyBaseEditVm
{
    [Required]
    public int SubjectId { get; set; }
}
