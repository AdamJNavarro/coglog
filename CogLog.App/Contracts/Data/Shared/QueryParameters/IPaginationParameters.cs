namespace CogLog.App.Contracts.Data.Shared.QueryParameters;

public interface IPaginationParameters
{
    public int Page { get; set; }
    public int PerPage { get; set; }
}
