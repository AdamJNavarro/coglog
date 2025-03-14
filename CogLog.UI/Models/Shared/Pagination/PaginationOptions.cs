namespace CogLog.UI.Models.Shared.Pagination;

public class PaginationOptions
{
    public string Controller { get; set; }
    public string Action { get; set; }
    public Dictionary<string, object> RouteValues { get; set; } = new Dictionary<string, object>();

    public int MaxDisplayedPages { get; set; } = 5;
    public bool ShowFirstLast { get; set; } = true;
    public bool ShowPrevNext { get; set; } = true;
}
