using CogLog.UI.Models.Subject;

namespace CogLog.UI.Contracts;

public interface ISubjectService
{
    Task<List<SubjectVm>> GetSubjectsAsync();
    Task<SubjectVm> GetSubjectAsync(int id);
    Task CreateSubjectAsync(SubjectVm subjectVm);
    Task UpdateSubjectAsync(SubjectVm subjectVm);
    Task DeleteSubjectAsync(int id);
}
