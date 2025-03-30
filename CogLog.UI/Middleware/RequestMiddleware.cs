using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using CogLog.UI.Contracts;
using CogLog.UI.Services.Base;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Features;

namespace CogLog.UI.Middleware;

public class RequestMiddleware(RequestDelegate next, ILocalStorageService localStorageService)
{
    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            var ep = httpContext.Features.Get<IEndpointFeature>()?.Endpoint;

            var authAttr = ep?.Metadata?.GetMetadata<AuthorizeAttribute>();

            if (authAttr != null)
            {
                var tokenExists = localStorageService.Exists("token");
                // Console.WriteLine("Exists");
                // Console.WriteLine(tokenExists);
                var tokenIsValid = true;
                if (tokenExists)
                {
                    var token = localStorageService.GetStorageValue<string>("token");
                    JwtSecurityTokenHandler tokenHandler = new();
                    var tokenContent = tokenHandler.ReadJwtToken(token);
                    var expiry = tokenContent.ValidTo;
                    if (expiry < DateTime.UtcNow)
                    {
                        tokenIsValid = false;
                    }
                }

                if (tokenIsValid == false || tokenExists == false)
                {
                    await SignOutAndRedirect(httpContext);
                    return;
                }
                if (authAttr.Roles != null)
                {
                    const string forbiddenPath = "/auth/forbidden";
                    var userRole = httpContext.User.FindFirst(ClaimTypes.Role)?.Value;
                    if (userRole == null)
                    {
                        httpContext.Response.Redirect(forbiddenPath);
                        return;
                    }

                    if (authAttr.Roles.Contains(userRole) == false)
                    {
                        httpContext.Response.Redirect(forbiddenPath);
                        return;
                    }
                }
            }
            await next(httpContext);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        Console.WriteLine("HEA called");
        Console.WriteLine(exception.Message);
        switch (exception)
        {
            case ApiException:
                await SignOutAndRedirect(context);
                break;
            default:
                const string path = "/Home/Error";
                context.Response.Redirect(path);
                break;
        }
    }

    private static async Task SignOutAndRedirect(HttpContext httpContext)
    {
        await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        const string path = "/auth/login";
        httpContext.Response.Redirect(path);
    }
}
