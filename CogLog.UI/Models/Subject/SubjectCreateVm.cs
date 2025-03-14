using System.ComponentModel.DataAnnotations;
using CogLog.UI.Models.Shared.Hierarchy;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CogLog.UI.Models.Subject;

public class SubjectCreateVm : HierarchyBaseWriteVm
{
    [Required]
    public int CategoryId { get; set; }

    // public IEnumerable<SelectListItem> CategorySelectItems { get; init; } = [];
}
