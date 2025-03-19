using CogLog.UI.Contracts;
using CogLog.UI.Mapping;
using CogLog.UI.Models.Tag;
using CogLog.UI.Services.Base;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CogLog.UI.Services;

public class TagService(IClient client, ILocalStorageService localStorageService)
    : BaseHttpService(client, localStorageService),
        ITagService
{
    private readonly IClient _client = client;

    public async Task<List<TagMinimalVm>> GetTagsAsync()
    {
        var data = await _client.TagsGetAllAsync(null);
        return data.ToTagMinimalVmList();
    }

    public async Task<TagDetailsVm> GetTagDetailsAsync(int id)
    {
        var tag = await _client.TagGetDetailsAsync(id);
        return tag.ToTagDetailsVm();
    }

    public async Task<List<SelectListItem>> GetSelectListAsync(int? subjectId = null)
    {
        var tags = await _client.TagsGetAllAsync(subjectId);

        return tags.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name })
            .ToList();
    }

    public async Task<Response<Guid>> CreateTagAsync(TagCreateVm tag)
    {
        try
        {
            AddBearerToken();
            await _client.TagCreateAsync(tag.ToCreateTagCommand());
            return new Response<Guid>() { Success = true };
        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions<Guid>(ex);
        }
    }

    public async Task<Response<Guid>> UpdateTagAsync(TagEditVm tag)
    {
        try
        {
            AddBearerToken();
            var cmd = tag.ToUpdateTagCommand();
            await _client.TagUpdateAsync(tag.Id.ToString(), cmd);
            return new Response<Guid>() { Success = true };
        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions<Guid>(ex);
        }
    }

    public async Task<Response<Guid>> DeleteTagAsync(int id)
    {
        try
        {
            AddBearerToken();
            await _client.TagDeleteAsync(id);
            return new Response<Guid>() { Success = true };
        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions<Guid>(ex);
        }
    }
}
