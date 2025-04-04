using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Vonavulary.App.Exceptions;
using Vonavulary.UI.Contracts;
using Vonavulary.UI.Models;
using Vonavulary.UI.Services.Base;

namespace Vonavulary.UI.Middleware;

public class CustomMiddleware(RequestDelegate next, ILocalStorageService localStorageService)
{
    public async Task InvokeAsync(HttpContext ctx)
    {
        var endpoint = ctx.GetEndpoint();

        if (endpoint?.DisplayName != null && endpoint.DisplayName.Contains("API"))
        {
            try
            {
                await next(ctx);
            }
            catch (Exception ex)
            {
                await HandleApiExceptionAsync(ctx, ex);
            }
        }
        else
        {
            try
            {
                var authAttr = endpoint?.Metadata?.GetMetadata<AuthorizeAttribute>();

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
                        await SignOutAndRedirect(ctx);
                        return;
                    }

                    if (authAttr.Roles != null)
                    {
                        const string forbiddenPath = "/auth/forbidden";
                        var userRole = ctx.User.FindFirst(ClaimTypes.Role)?.Value;
                        if (userRole == null)
                        {
                            ctx.Response.Redirect(forbiddenPath);
                            return;
                        }

                        if (authAttr.Roles.Contains(userRole) == false)
                        {
                            ctx.Response.Redirect(forbiddenPath);
                            return;
                        }
                    }
                }

                await next(ctx);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(ctx, ex);
            }
        }
    }

    private static async Task HandleExceptionAsync(HttpContext ctx, Exception exception)
    {
        switch (exception)
        {
            case ApiException:
                await SignOutAndRedirect(ctx);
                break;
            default:
                const string path = "/words/error";
                ctx.Response.Redirect(path);
                break;
        }
    }

    private static async Task SignOutAndRedirect(HttpContext httpContext)
    {
        await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        const string path = "/auth/login";
        httpContext.Response.Redirect(path);
    }

    private async Task HandleApiExceptionAsync(HttpContext ctx, Exception ex)
    {
        HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
        CustomValidationProblemDetails problem = new();

        switch (ex)
        {
            case BadRequestException badRequestException:
                statusCode = HttpStatusCode.BadRequest;
                problem = new CustomValidationProblemDetails()
                {
                    Title = badRequestException.Message,
                    Status = (int)statusCode,
                    Detail = badRequestException.InnerException?.Message,
                    Errors = badRequestException.ValidationErrors,
                };
                break;
        }

        ctx.Response.StatusCode = (int)statusCode;
        await ctx.Response.WriteAsJsonAsync(problem);
    }
}
