using CogLog.UI.Models.Subject;
using CogLog.UI.Services.Base;

namespace CogLog.UI.Contracts;

public interface ISubjectService
{
    Task<List<SubjectVm>> GetSubjectsAsync();
    Task<List<BaseSubjectVm>> GetSubjectsByCategoryAsync(int categoryId);
    Task<BaseSubjectVm> GetSubjectAsync(int id);
    Task<SubjectWithCategoryTopicsVm> GetSubjectWithCategoryTopicsAsync(int id);
    Task<Response<Guid>> CreateSubjectAsync(SubjectCreateVm subject);
    Task UpdateSubjectAsync(SubjectVm subject);
    Task DeleteSubjectAsync(int id);
}
