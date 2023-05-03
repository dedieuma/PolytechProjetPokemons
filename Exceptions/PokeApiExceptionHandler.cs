using System.Net;
using System.Net.Mime;
using Microsoft.AspNetCore.Diagnostics;

namespace PokeAPIPolytech.Exceptions;

public static class PokeApiExceptionHandler
{
    public static async Task HandleException(HttpContext httpContext)
    {
        var exceptionContext = httpContext.Features.Get<IExceptionHandlerFeature>();

        if (exceptionContext == null)
        {
            return;
        }

        httpContext.Response.ContentType = MediaTypeNames.Text.Plain;
            
        if (exceptionContext.Error is not HttpException httpEx)
        {
            httpContext.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
            await httpContext.Response.WriteAsync(exceptionContext.Error.Message);
            return;
        }

        httpContext.Response.StatusCode = (int)httpEx.StatusCode;
            
        await httpContext.Response.WriteAsync(httpEx.Message);
    }
}