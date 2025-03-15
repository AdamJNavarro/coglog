using CogLog.App.Contracts.Data.Shared.QueryParameters;

namespace CogLog.App.Contracts.Data.Subject;

public class SubjectQueryParameters : IPaginationParameters
{
    private const int MaxPerPage = 50;
    private int _perPage = 30;

    public int Page { get; set; } = 1;

    public int PerPage
    {
        get => _perPage;
        set => _perPage = (value > MaxPerPage) ? MaxPerPage : value;
    }

    public string? Category { get; set; }

    public string? Name { get; set; }
}
