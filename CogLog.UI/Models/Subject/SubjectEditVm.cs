using System.ComponentModel.DataAnnotations;
using CogLog.App.Constants;
using CogLog.UI.Models.Shared.Hierarchy;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CogLog.UI.Models.Subject;

public class SubjectEditVm : HierarchyBaseEditVm
{
    [Required]
    public int CategoryId { get; set; }
}
