using CogLog.App.Contracts.Data.Subject;
using CogLog.UI.Models.Subject;
using CogLog.UI.Services.Base;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CogLog.UI.Contracts;

public interface ISubjectService
{
    Task<SubjectPaginationVm> GetPaginatedSubjectsAsync(SubjectQueryParameters qp);
    Task<List<SubjectMinimalVm>> GetSubjectsAllAsync(int? categoryId);
    Task<SubjectDetailsVm> GetSubjectDetailsAsync(int id);
    Task<Response<Guid>> CreateSubjectAsync(SubjectCreateVm subject);
    Task<Response<Guid>> UpdateSubjectAsync(SubjectEditVm subject);
    Task<Response<Guid>> DeleteSubjectAsync(int id);
    Task<List<SelectListItem>> GetSelectListAsync(int? categoryId);
}
