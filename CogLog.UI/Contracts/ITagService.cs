using CogLog.UI.Models.Tag;
using CogLog.UI.Services.Base;

namespace CogLog.UI.Contracts;

public interface ITagService
{
    Task<List<BaseTagVm>> GetTagsBySubjectAsync(int subjectId);
    Task<List<TagVm>> GetTagsAsync();
    Task<TagVm> GetTagAsync(int id);
    Task<Response<Guid>> CreateTagAsync(TagCreateVm tag);
    Task<Response<Guid>> UpdateTagAsync(TagVm tagVm);
    Task<Response<Guid>> DeleteTagAsync(int id);
}
