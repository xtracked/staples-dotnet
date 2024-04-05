// Copyright 2024 Xtracked
// SPDX-License-Identifier: Apache-2.0

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Xtracked.Staples.ApiErrors.Handlers;
using Xtracked.Staples.ApiErrors.Models;
using Xtracked.Staples.ApiErrors.Utils;

namespace Xtracked.Staples.ApiErrors.AspNetCore.Extensions;

/// <summary>Extensions for <see cref="IServiceCollection"/>.</summary>
public static class ServiceCollectionExtensions
{
    /// <summary>Adds services required for creation of <see cref="ApiError"/> for failed requests.</summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
    /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
    /// <remarks>
    /// Overrides <see cref="IClientErrorFactory"/> and
    /// <see cref="ApiBehaviorOptions.InvalidModelStateResponseFactory"/>. This means it can't be used in combination
    /// with <see cref="ProblemDetails"/>.
    /// </remarks>
    public static IServiceCollection AddApiError(this IServiceCollection services)
    {
        // Factory to transform IClientErrorActionResult to ApiError, overriding the default ProblemDetails one
        services.AddSingleton<IClientErrorFactory, ApiErrorClientErrorFactory>();

        // Override default InvalidModelStateResponseFactory to use an ApiError
        services.Configure<ApiBehaviorOptions>(options =>
        {
            options.InvalidModelStateResponseFactory = InvalidModelStateResponseFactory;

        });

        return services;
    }

    /// <summary>
    /// Factory to create <see cref="ApiError"/> response for an invalid <see cref="ActionContext.ModelState"/>.
    /// </summary>
    /// <param name="context">Context for response.</param>
    /// <returns>The response.</returns>
    private static IActionResult InvalidModelStateResponseFactory(ActionContext context)
    {
        var apiError = new ApiError(
            400,
            ApiErrorType.InvalidArgument,
            ApiErrorType.InvalidArgument.GetDefaultErrorMessage(),
            CreateApiErrorDetailsList(context.ModelState)
        );
                
        return new ObjectResult(apiError)
        {
            StatusCode = apiError.Status,
        };
    }

    /// <summary>Creates the list with <see cref="ApiErrorDetails"/> for given <paramref name="modelState"/>.</summary>
    /// <param name="modelState">Model state to get errors for.</param>
    /// <returns>The list with <see cref="ApiErrorDetails"/>.</returns>
    private static IReadOnlyList<ApiErrorDetails>? CreateApiErrorDetailsList(ModelStateDictionary modelState)
    {
        var result = new List<ApiErrorDetails>();
        
        foreach (var (key, entry) in modelState)
        {
            var errors = entry.Errors;
            foreach (var error in errors)
            {
                var errorMessage = !string.IsNullOrEmpty(error.ErrorMessage)
                    ? error.ErrorMessage
                    : "The input was not valid.";
                
                // Add details for each error for current key
                result.Add(new ApiErrorDetails(
                    key,
                    errorMessage
                ));
            }
        }

        return result.Count > 0 
            ? result 
            // Return null if there are no items so we're not returning an empty list to client
            : null;
    }
    
    /// <summary>Adds <typeparamref name="T"/> as singleton service.</summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
    /// <typeparam name="T">Type of the <see cref="IExceptionApiErrorHandler"/> to add.</typeparam>
    /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
    public static IServiceCollection AddExceptionApiErrorHandler<T>(this IServiceCollection services) 
        where T : class, IExceptionApiErrorHandler
    {
        // Factory to transform IClientErrorActionResult to ApiError, overriding the default ProblemDetails one
        services.AddSingleton<IExceptionApiErrorHandler, T>();

        return services;
    }
    
    /// <summary>Adds the default <see cref="IExceptionApiErrorHandler"/>s.</summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
    /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
    public static IServiceCollection AddDefaultExceptionApiErrorHandlers(this IServiceCollection services) =>
        services.AddExceptionApiErrorHandler<ExceptionApiErrorHandler>()
            .AddExceptionApiErrorHandler<ApiErrorExceptionApiErrorHandler>();
    
    /// <summary>
    /// Adds the <see cref="JsonExceptionApiErrorHandler"/>, using <see cref="ThrowingSystemTextJsonInputFormatter"/> if
    /// <paramref name="useThrowingInputFormatter"/> is true so that JSON exceptions thrown when reading request body
    /// are also handled by the <see cref="JsonExceptionApiErrorHandler"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
    /// <param name="useThrowingInputFormatter">
    /// Whether to use <see cref="ThrowingSystemTextJsonInputFormatter"/>.
    /// </param>
    /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
    public static IServiceCollection AddJsonExceptionApiErrorHandler(
        this IServiceCollection services, 
        bool useThrowingInputFormatter = true
    )
    {
        services.AddExceptionApiErrorHandler<JsonExceptionApiErrorHandler>();
        // Override SystemTextJsonInputFormatter with our own so that JsonExceptionApiErrorHandler can handle exception
        if (useThrowingInputFormatter) 
            services.AddTransient<IConfigureOptions<MvcOptions>, ThrowingSystemTextJsonMvcOptionsSetup>();

        return services;
    }
}