using CogLog.UI.Contracts;
using CogLog.UI.Mapping;
using CogLog.UI.Models.Tag;
using CogLog.UI.Services.Base;

namespace CogLog.UI.Services;

public class TagService(IClient client, ILocalStorageService localStorageService)
    : BaseHttpService(client, localStorageService),
        ITagService
{
    private readonly IClient _client = client;

    public async Task<List<BaseTagVm>> GetTagsBySubjectAsync(int subjectId)
    {
        var data = await _client.TagsBySubjectGETAsync(subjectId);
        return data.ToBaseTagVmList();
    }

    public async Task<List<TagVm>> GetTagsAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<TagVm> GetTagAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Response<Guid>> CreateTagAsync(TagVm tagVm)
    {
        throw new NotImplementedException();
    }

    public async Task<Response<Guid>> UpdateTagAsync(TagVm tagVm)
    {
        throw new NotImplementedException();
    }

    public async Task<Response<Guid>> DeleteTagAsync(int id)
    {
        throw new NotImplementedException();
    }
}
