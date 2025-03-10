namespace CogLog.UI.Models.Shared.Pagination;

public class PaginationResponseVm<T>
{
    public PaginationMetadataVm Pagination { get; set; }
    public IEnumerable<T> Data { get; set; }
}
