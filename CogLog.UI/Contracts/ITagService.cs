using CogLog.UI.Models.Tag;
using CogLog.UI.Services.Base;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CogLog.UI.Contracts;

public interface ITagService
{
    Task<List<TagMinimalVm>> GetTagsAsync();
    Task<TagDetailsVm> GetTagDetailsAsync(int id);
    Task<List<SelectListItem>> GetSelectListAsync(int? subjectId = null);
    Task<Response<Guid>> CreateTagAsync(TagCreateVm tag);
    Task<Response<Guid>> UpdateTagAsync(TagEditVm tagVm);
    Task<Response<Guid>> DeleteTagAsync(int id);
}
