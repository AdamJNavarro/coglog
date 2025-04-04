using Microsoft.AspNetCore.Mvc;
using Vonavulary.UI.Models.Shared.Pagination;

namespace Vonavulary.UI.Components;

public class Pagination : ViewComponent
{
    public IViewComponentResult Invoke(
        PaginationMetadataVm pagination,
        string controller = null,
        string action = null,
        Dictionary<string, object> routeValues = null,
        int maxDisplayedPages = 5,
        bool showFirstLast = true,
        bool showPrevNext = true
    )
    {
        var options = new PaginationOptions
        {
            Controller = controller ?? RouteData.Values["controller"].ToString(),
            Action = action ?? RouteData.Values["action"].ToString(),
            RouteValues = routeValues ?? new Dictionary<string, object>(),
            MaxDisplayedPages = maxDisplayedPages,
            ShowFirstLast = showFirstLast,
            ShowPrevNext = showPrevNext,
        };

        var vm = new PaginationVm { Pagination = pagination, Options = options };

        return View(vm);
    }
}
