namespace CogLog.App.Contracts.Persistence;

public interface IGenericRepo<T>
    where T : class
{
    Task CreateAsync(T entity);
    Task DeleteAsync(T entity);
    Task UpdateAsync(T entity);

    Task<T?> GetByIdAsync(int id);
    Task<IReadOnlyList<T>> GetAsync();
}
