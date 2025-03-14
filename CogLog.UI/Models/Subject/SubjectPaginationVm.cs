using CogLog.UI.Models.Shared.Pagination;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CogLog.UI.Models.Subject;

public class SubjectPaginationVm : PaginationResponseVm<SubjectPaginatedVm>
{
    public IEnumerable<SelectListItem> CategorySelectItems { get; init; } = [];
}
