using CogLog.UI.Contracts;
using CogLog.UI.Mapping;
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

    public async Task<List<BaseSubjectVm>> GetSubjectsByCategoryAsync(int categoryId)
    {
        var data = await _client.SubjectsByCategoryGETAsync(categoryId);
        return data.Select(x => x.ToBaseSubjectVm()).ToList();
    }

    public async Task<SubjectVm> GetSubjectAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<SubjectWithCategoryTopicsVm> GetSubjectWithCategoryTopicsAsync(int id)
    {
        var data = await _client.SubjectWithCategoryTopicsGETAsync(id);
        return data.ToSubjectWithCategoryTopicsVm();
    }

    public async Task<Response<Guid>> CreateSubjectAsync(CreateSubjectVm subject)
    {
        try
        {
            var cmd = subject.ToCreateSubjectCommand();
            await _client.SubjectsPOSTAsync(cmd);
            return new Response<Guid>() { Success = true };
        }
        catch (ApiException ex)
        {
            Console.WriteLine(ex.Message);
            return ConvertApiExceptions<Guid>(ex);
        }
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
