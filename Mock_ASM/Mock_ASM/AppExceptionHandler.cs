using Microsoft.AspNetCore.Diagnostics;

namespace Mock_ASM
{
    public class AppExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            await httpContext.Response.WriteAsJsonAsync(exception.Message, cancellationToken);
            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            return true;
        }
    }
}