using System.Text.Json.Serialization;

namespace Vonavulary.UI.Models.Shared.Pagination;

public class PaginationMetadataVm
{
    public int TotalItems { get; set; }
    public int TotalPages { get; set; }
    public int Page { get; set; }
    public int PerPage { get; set; }

    [JsonIgnore] // This property is calculated and not stored
    public bool HasPrevious => Page > 1;

    [JsonIgnore] // This property is calculated and not stored
    public bool HasNext => Page < TotalPages;
}
