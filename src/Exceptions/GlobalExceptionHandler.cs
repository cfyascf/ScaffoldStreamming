using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
namespace App.Exceptions;

public class GlobalExceptionHandler(ILogger<ApplicationException> _logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext, 
        Exception exception, 
        CancellationToken cancellationToken)
    {
        ProblemDetails details;

        if(exception is GlobalException applicationException)
        {
            _logger.LogError(
                applicationException,
                "Exception occurred: {Message}",
                applicationException.Message
            );

            details = new ProblemDetails
            {
                Status = applicationException.StatusCode,
                Title = "Application Exception",
                Detail = applicationException.Message
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