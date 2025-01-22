using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using AutoMapper;
using CogLog.UI.Contracts;
using CogLog.UI.Services.Base;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace CogLog.UI.Services;

public class AuthService(
    IClient client,
    ILocalStorageService localStorage,
    IHttpContextAccessor httpContextAccessor,
    IMapper mapper
) : BaseHttpService(client, localStorage), IAuthService
{
    private readonly IMapper _mapper = mapper;
    private readonly JwtSecurityTokenHandler _tokenHandler = new();
    private readonly IClient _client = client;

    public async Task<bool> AuthenticateAsync(string email, string password)
    {
        try
        {
            AuthRequest authenticationRequest = new() { Email = email, Password = password };
            var authenticationResponse = await _client.LoginAsync(authenticationRequest);

            if (authenticationResponse.Token != string.Empty)
            {
                //Get Claims from token and Build auth user object
                var tokenContent = _tokenHandler.ReadJwtToken(authenticationResponse.Token);
                var claims = ParseClaims(tokenContent);
                var user = new ClaimsPrincipal(
                    new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme)
                );
                var login = httpContextAccessor.HttpContext!.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    user
                );
                _localStorage.SetStorageValue("token", authenticationResponse.Token);

                return true;
            }
            return false;
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
