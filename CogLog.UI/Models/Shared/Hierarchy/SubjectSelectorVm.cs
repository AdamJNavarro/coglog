using Microsoft.AspNetCore.Mvc.Rendering;

namespace CogLog.UI.Models.Shared.Hierarchy;

public class SubjectSelectorVm
{
    public int SubjectId { get; set; }

    public IEnumerable<SelectListItem> SubjectSelectItems { get; init; } = [];
}
