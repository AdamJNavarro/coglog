using Microsoft.AspNetCore.Mvc.Rendering;

namespace CogLog.UI.Models.Shared.Hierarchy;

public class CategorySelectorVm
{
    public int CategoryId { get; set; }

    public IEnumerable<SelectListItem> CategorySelectItems { get; init; } = [];
}
