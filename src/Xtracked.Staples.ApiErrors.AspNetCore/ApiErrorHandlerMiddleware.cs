// Copyright 2024 Xtracked
// SPDX-License-Identifier: Apache-2.0

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Routing;
using Xtracked.Staples.ApiErrors.Handlers;
using Xtracked.Staples.ApiErrors.Models;

namespace Xtracked.Staples.ApiErrors.AspNetCore;

/// <summary>
/// Middleware that will call all <see cref="IExceptionApiErrorHandler"/> for any <see cref="Exception"/> thrown,
/// writing the proper HTTP response.
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
public class ApiErrorHandlerMiddleware
{
    /// <summary>Next handler.</summary>
    private readonly RequestDelegate _next;
    /// <summary>API error handlers.</summary>
    private readonly IReadOnlyList<IExceptionApiErrorHandler> _apiErrorHandlers;
    /// <summary>The executor for the <see cref="ObjectResult"/>.</summary>
    private readonly IActionResultExecutor<ObjectResult> _executor;

    /// <summary>Initializes properties.</summary>
    public ApiErrorHandlerMiddleware(
        RequestDelegate next,
        IEnumerable<IExceptionApiErrorHandler> apiErrorHandlers,
        IActionResultExecutor<ObjectResult> executor
    )
    {
        _next = next;
        _apiErrorHandlers = apiErrorHandlers.OrderByDescending(it => it.Order).ToList();
        _executor = executor;
    }
    
    /// <summary>Invokes this middleware.</summary>
    /// <param name="context">Context for middleware.</param>
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            // Early return if already sending response 
            if (context.Response.HasStarted)
                return;
            
            ApiError? apiError = null;
            foreach (var handler in _apiErrorHandlers)
            {
                apiError = handler.Handle(exception);
                if (apiError != null)
                    break;
            }

            // Rethrow error if it was not handled by any handler
            if (apiError == null)
                throw;
            
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