using CogLog.Domain;

namespace CogLog.App.Contracts.Persistence;

public interface ITagRepo : IBaseRepo<Tag>
{
    Task CreateTagAsync(Tag tag);
}
