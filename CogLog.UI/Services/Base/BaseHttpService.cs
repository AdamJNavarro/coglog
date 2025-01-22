using System.Net.Http.Headers;
using CogLog.UI.Contracts;

namespace CogLog.UI.Services.Base;

public class BaseHttpService
{
    protected IClient Client;
    protected readonly ILocalStorageService _localStorage;

    public BaseHttpService(IClient client, ILocalStorageService localStorage)
    {
        Client = client;
        _localStorage = localStorage;
    }

    protected Response<Guid> ConvertApiExceptions<Guid>(ApiException ex)
    {
        // Console.WriteLine(ex.StatusCode);
        if (ex.StatusCode == 400)
        {
            return new Response<Guid>()
            {
                Message = "Invalid data was submitted",
                ValidationErrors = ex.Response,
                Success = false,
            };
        }
        else if (ex.StatusCode == 404)
        {
            return new Response<Guid>() { Message = "The record was not found.", Success = false };
        }
        else
        {
            return new Response<Guid>()
            {
                Message = "Something went wrong, please try again later.",
                Success = false,
            };
        }
    }

    protected void AddBearerToken()
    {
        if (_localStorage.Exists("token"))
            Client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Bearer",
                _localStorage.GetStorageValue<string>("token")
            );
    }
}
