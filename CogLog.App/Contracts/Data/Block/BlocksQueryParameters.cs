using CogLog.App.Contracts.Data.Shared.QueryParameters;

namespace CogLog.App.Contracts.Data.Block;

public class BlocksQueryParameters : IPaginationParameters
{
    private const int MaxPerPage = 50;
    private int _perPage = 3;

    public int Page { get; set; } = 1;

    public int PerPage
    {
        get => _perPage;
        set => _perPage = (value > MaxPerPage) ? MaxPerPage : value;
    }

    // Optional: Add more filtering parameters
    public string? SearchTerm { get; set; }

    public string? CategoryName { get; set; }

    public string? SubjectName { get; set; }

    // Tag filtering
    // public List<int> TagIds { get; set; }

    //public string TagNames { get; set; }
}
