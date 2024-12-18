﻿using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace ProfilesApi.ExceptionHandlers
{
    public class DefaultExceptionToProblemDetailsHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {

            httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            await httpContext.Response.WriteAsJsonAsync(new ProblemDetails
            {
                Title = "An error occurred",
                Detail = exception.Message,
                Type = exception.GetType().Name,
                Status = StatusCodes.Status400BadRequest
            }, cancellationToken: cancellationToken);

            return true;
        }
    }
}
