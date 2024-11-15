﻿using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace ProfilesApi.ExceptionHandlers
{
    public class InvalidOperationExceptionToProblemDetailsHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception.GetType().Name != typeof(InvalidOperationException).Name)
                return false;

            httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
            await httpContext.Response.WriteAsJsonAsync(new ProblemDetails
            {
                Title = "An error occurred",
                Detail = exception.Message,
                Type = exception.GetType().Name,
                Status = StatusCodes.Status404NotFound
            }, cancellationToken: cancellationToken);

            return true;
        }
    }
}
