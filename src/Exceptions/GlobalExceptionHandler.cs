using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
namespace App.Exceptions;

public class GlobalExceptionHandler(ILogger<GlobalException> _logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext, 
        Exception exception, 
        CancellationToken cancellationToken)
    {
        ProblemDetails details;

        if(exception is GlobalException globalException)
        {
            _logger.LogError(
                globalException,
                "Exception occurred: {Message}",
                globalException.Message
            );

            details = new ProblemDetails
            {
                Status = globalException.StatusCode,
                Title = "Application Exception",
                Detail = globalException.Message
            };

            httpContext.Response.StatusCode = details.Status.Value;
            await httpContext.Response.WriteAsJsonAsync(details, cancellationToken);

            return true;
        }

        if(exception is FormatException formatException)
        {
            _logger.LogError(
                formatException,
                "Exception occurred: {Message}",
                formatException.Message
            );

            details = new ProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Title = "Format Exception",
                Detail = formatException.Message
            };

            httpContext.Response.StatusCode = details.Status.Value;
            await httpContext.Response.WriteAsJsonAsync(details, cancellationToken);

            return true;
        }

        _logger.LogError(
                exception,
                "Exception occurred: {Message}",
                exception.Message
            );

        details = new ProblemDetails
        {
            Status = StatusCodes.Status500InternalServerError,
            Title = "Internal Server Error",
            Detail = exception.Message
        };

        httpContext.Response.StatusCode = details.Status.Value;
        await httpContext.Response.WriteAsJsonAsync(details, cancellationToken);

        return true;
    }
}