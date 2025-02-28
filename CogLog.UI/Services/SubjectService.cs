using CogLog.UI.Contracts;
using CogLog.UI.Models.Subject;
using CogLog.UI.Services.Base;

namespace CogLog.UI.Services;

public class SubjectService(IClient client, ILocalStorageService localStorageService)
    : BaseHttpService(client, localStorageService),
        ISubjectService
{
    private readonly IClient _client = client;

    public async Task<List<SubjectVm>> GetSubjectsAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<SubjectVm> GetSubjectAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task CreateSubjectAsync(SubjectVm subjectVm)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateSubjectAsync(SubjectVm subjectVm)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteSubjectAsync(int id)
    {
        throw new NotImplementedException();
    }
}
