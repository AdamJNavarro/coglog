namespace Vonavulary.UI.Services.Base;

public partial class Client : IClient
{
    public HttpClient HttpClient => _httpClient;
}
