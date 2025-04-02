using CogLog.App.Contracts.Data.Shared.QueryParameters;

namespace CogLog.App.Contracts.Data.Word;

public class WordsQueryParameters : IPaginationParameters
{
    private const int MaxPerPage = 50;
    private int _perPage = 10;

    public int Page { get; set; } = 1;

    public int PerPage
    {
        get => _perPage;
        set => _perPage = (value > MaxPerPage) ? MaxPerPage : value;
    }

    public string? Search { get; set; }
}
