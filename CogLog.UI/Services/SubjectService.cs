using CogLog.App.Contracts.Data.Subject;
using CogLog.UI.Contracts;
using CogLog.UI.Mapping;
using CogLog.UI.Models.Subject;
using CogLog.UI.Services.Base;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CogLog.UI.Services;

public class SubjectService(IClient client, ILocalStorageService localStorageService)
    : BaseHttpService(client, localStorageService),
        ISubjectService
{
    private readonly IClient _client = client;

    public async Task<SubjectDetailsVm> GetSubjectDetailsAsync(int id)
    {
        var subject = await _client.SubjectGetDetailsAsync(id);
        return subject.ToSubjectDetailsVm();
    }

    public async Task<SubjectPaginationVm> GetPaginatedSubjectsAsync(SubjectQueryParameters qp)
    {
        var data = await _client.SubjectsGetPaginatedAsync(
            qp.Page,
            qp.PerPage,
            qp.Category,
            qp.Name
        );
        return data.ToSubjectPaginationVm();
    }

    public async Task<List<SubjectMinimalVm>> GetSubjectsAllAsync(int? categoryId)
    {
        var subjects = await _client.SubjectsGetAllAsync(categoryId);
        return subjects.ToSubjectMinimalVmList();
    }

    public async Task<Response<Guid>> CreateSubjectAsync(SubjectCreateVm subject)
    {
        try
        {
            var cmd = subject.ToCreateSubjectCommand();
            await _client.SubjectCreateAsync(cmd);
            return new Response<Guid>() { Success = true };
        }
        catch (ApiException ex)
        {
            Console.WriteLine(ex.Message);
            return ConvertApiExceptions<Guid>(ex);
        }
    }

    public async Task<Response<Guid>> UpdateSubjectAsync(SubjectEditVm subject)
    {
        try
        {
            var cmd = subject.ToUpdateSubjectCommand();
            await _client.SubjectUpdateAsync(subject.Id.ToString(), cmd);
            return new Response<Guid>() { Success = true };
        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions<Guid>(ex);
        }
    }

    public async Task<Response<Guid>> DeleteSubjectAsync(int id)
    {
        try
        {
            await _client.SubjectDeleteAsync(id);
            return new Response<Guid>() { Success = true };
        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions<Guid>(ex);
        }
    }

    public async Task<List<SelectListItem>> GetSelectListAsync(int? categoryId)
    {
        var subjects = await _client.SubjectsGetAllAsync(categoryId);

        return subjects
            .Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name })
            .ToList();
    }
}
