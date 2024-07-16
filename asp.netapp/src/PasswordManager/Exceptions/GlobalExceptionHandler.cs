using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;

namespace PasswordManager.Exceptions;

public class GlobalExceptionHandler(IHostEnvironment env, ILogger<GlobalExceptionHandler> logger)
    : IExceptionHandler
{
    private const string UnhandledExceptionMsg = "УУпс, что то пошло не так.";
    
    public async ValueTask<bool> TryHandleAsync(HttpContext context, Exception exception,
        CancellationToken cancellationToken)
    {
        logger.LogError(exception, exception.Message );
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        const string contentType = "application/json";
        context.Response.ContentType = contentType;
        var responseDto = new { Success = false, Error = UnhandledExceptionMsg };
        await context.Response.WriteAsync(JsonSerializer.Serialize(responseDto), cancellationToken);

        return true;
    }
}

