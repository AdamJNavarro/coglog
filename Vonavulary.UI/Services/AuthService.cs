using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Vonavulary.UI.Contracts;
using Vonavulary.UI.Services.Base;

namespace Vonavulary.UI.Services;

public class AuthService(
    IClient client,
    ILocalStorageService localStorage,
    IHttpContextAccessor httpContextAccessor
) : BaseHttpService(client, localStorage), IAuthService
{
    private readonly JwtSecurityTokenHandler _tokenHandler = new();
    private readonly IClient _client = client;

    public async Task<bool> AuthenticateAsync(string email, string password)
    {
        try
        {
            AuthRequest authenticationRequest = new() { Email = email, Password = password };
            var authenticationResponse = await _client.LoginAsync(authenticationRequest);

            if (authenticationResponse.Token == string.Empty)
            {
                return false;
            }

            var tokenContent = _tokenHandler.ReadJwtToken(authenticationResponse.Token);
            var claims = ParseClaims(tokenContent);
            var user = new ClaimsPrincipal(
                new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme)
            );

            await httpContextAccessor.HttpContext!.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                user
            );
            _localStorage.SetStorageValue("token", authenticationResponse.Token);

            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> RegisterAsync(string email, string password)
    {
        RegistrationRequest registrationRequest = new RegistrationRequest()
        {
            Email = email,
            Password = password,
        };

        var response = await _client.RegisterAsync(registrationRequest);

        if (!string.IsNullOrEmpty(response.UserId))
        {
            return true;
        }
        return false;
    }

    public async Task Logout()
    {
        _localStorage.ClearStorage(new List<string> { "token" });
        await httpContextAccessor.HttpContext!.SignOutAsync(
            CookieAuthenticationDefaults.AuthenticationScheme
        );
    }

    private IList<Claim> ParseClaims(JwtSecurityToken tokenContent)
    {
        var claims = tokenContent.Claims.ToList();
        claims.Add(new Claim(ClaimTypes.Name, tokenContent.Subject));
        return claims;
    }
}
