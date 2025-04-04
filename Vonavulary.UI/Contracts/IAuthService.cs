namespace Vonavulary.UI.Contracts;

public interface IAuthService
{
    Task<bool> AuthenticateAsync(string email, string password);
    Task<bool> RegisterAsync(string email, string password);
    Task Logout();
}
