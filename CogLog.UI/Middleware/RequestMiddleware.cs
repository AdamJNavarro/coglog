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
                    var userRole = httpContext.User.FindFirst(ClaimTypes.Role)?.Value;
                    if (authAttr.Roles.Contains("Administrator") == false)
                    {
                        var path = $"/home/notauthorized";
                        httpContext.Response.Redirect(path);
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
        switch (exception)
        {
            case ApiException apiException:
                await SignOutAndRedirect(context);
                break;
            default:
                var path = $"/Home/Error";
                context.Response.Redirect(path);
                break;
        }
    }

    private static async Task SignOutAndRedirect(HttpContext httpContext)
    {
        await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        var path = $"/admin/login";
        httpContext.Response.Redirect(path);
    }
}
