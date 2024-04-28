using Microsoft.AspNetCore.Diagnostics;
using System.Diagnostics;

namespace Mock_ASM
{
    public class AppExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
          
             
            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await httpContext.Response.WriteAsJsonAsync(exception.Message);
            return true;
        }
    }
}