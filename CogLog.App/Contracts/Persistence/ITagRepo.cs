using CogLog.App.Contracts.Data.Tag;
using CogLog.Domain;

namespace CogLog.App.Contracts.Persistence;

public interface ITagRepo : IBaseRepo<Tag>
{
    Task CreateTagAsync(Tag tag);
    Task UpdateTagAsync(Tag tag);
    Task DeleteTagAsync(Tag tag);
    Task<TagDetailsDto?> GetTagDetailsAsync(int id);
    Task<List<TagMinimalDto>> GetAllTagsAsync(int? subjectId = null);
}
