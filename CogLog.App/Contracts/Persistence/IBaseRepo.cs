namespace CogLog.App.Contracts.Persistence;

public interface IBaseRepo<T>
    where T : class
{
    Task<bool> EntityExistsAsync(int id);
    Task<T?> GetEntityAsync(int id);
}
