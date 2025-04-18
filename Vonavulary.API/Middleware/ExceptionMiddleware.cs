using System.Net;
using Vonavulary.API.Models;
using Vonavulary.App.Exceptions;

namespace Vonavulary.API.Middleware;

public class ExceptionMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception ex)
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
            default:
                break;
        }

        context.Response.StatusCode = (int)statusCode;
        await context.Response.WriteAsJsonAsync(problem);
    }
}
