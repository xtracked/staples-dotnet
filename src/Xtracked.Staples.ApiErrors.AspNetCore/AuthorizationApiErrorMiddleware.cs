// Copyright 2025 Xtracked
// SPDX-License-Identifier: Apache-2.0

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Routing;
using Xtracked.Staples.ApiErrors.Models;
using Xtracked.Staples.ApiErrors.Utils;

namespace Xtracked.Staples.ApiErrors.AspNetCore;

/// <summary>
/// Middleware that will handle <see cref="HttpResponse.StatusCode"/> <see cref="StatusCodes.Status401Unauthorized"/>
/// and <see cref="StatusCodes.Status403Forbidden"/>, writing the proper HTTP response as an <see cref="ApiError"/>.
///
/// In order to use the configured serialization, we will leverage the <see cref="IActionResultExecutor{TResult}"/> in
/// combination with <see cref="ObjectResult"/>. This way we e.g. don't explicitly always serialize content to JSON, but
/// instead allow for serializing to other formats (e.g. XML) as well.
/// </summary>
/// <remarks>
/// By not implementing <see cref="IMiddleware"/> but instead using the generic middleware <see cref="Invoke"/> format,
/// you can simply call <c>app.UseMiddleware&lt;CustomMiddleware&gt;()</c> and dependencies will be resolved without
/// having to add middleware to <c>ServiceCollection</c>.
/// </remarks>
public class AuthorizationApiErrorMiddleware
{
    /// <summary>Next handler.</summary>
    private readonly RequestDelegate _next;
    /// <summary>The executor for the <see cref="ObjectResult"/>.</summary>
    private readonly IActionResultExecutor<ObjectResult> _executor;

    /// <summary>Initializes properties.</summary>
    public AuthorizationApiErrorMiddleware(
        RequestDelegate next,
        IActionResultExecutor<ObjectResult> executor
    )
    {
        _next = next;
        _executor = executor;
    }
    
    /// <summary>Invokes this middleware.</summary>
    /// <param name="context">Context for middleware.</param>
    public async Task Invoke(HttpContext context)
    {
        await _next(context);
        
        // Early return if already sending response 
        if (context.Response.HasStarted)
            return;
        
        // Handle authorization errors
        var apiErrorType = context.Response.StatusCode switch
        {
            StatusCodes.Status401Unauthorized => ApiErrorType.Unauthenticated,
            StatusCodes.Status403Forbidden => ApiErrorType.PermissionDenied,
            _ => (ApiErrorType?) null
        };

        if (apiErrorType != null)
        {
            var apiError = new ApiError(
                context.Response.StatusCode,
                apiErrorType.Value,
                apiErrorType.Value.GetDefaultErrorMessage()
            );
            
            var result = new ObjectResult(apiError)
            {
                StatusCode = apiError.Status
            };
            
            // Build required context for executor
            var routeData = context.GetRouteData();
            // In case exception was thrown from a controller, we can get its descriptor
            var descriptor = context.GetEndpoint()?.Metadata.GetMetadata<ControllerActionDescriptor>() 
                ?? new ActionDescriptor();
            var actionContext = new ActionContext(context, routeData, descriptor);
            
            await _executor.ExecuteAsync(actionContext, result);
        }
    }
}