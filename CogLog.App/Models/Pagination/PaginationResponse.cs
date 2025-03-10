namespace CogLog.App.Models.Pagination;

public class PaginationResponse<T>
{
    public PaginationMetadata Pagination { get; set; }
    public IEnumerable<T> Data { get; set; }
}
