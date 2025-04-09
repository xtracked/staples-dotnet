// Copyright 2025 Xtracked
// SPDX-License-Identifier: Apache-2.0

using Microsoft.Extensions.Logging;
using Xtracked.Staples.ApiErrors.Exceptions;
using Xtracked.Staples.ApiErrors.Models;

namespace Xtracked.Staples.ApiErrors.Handlers;

/// <summary>
/// Handler that handles any <see cref="ApiErrorException"/>, returning the <see cref="ApiErrorException.ApiError"/>.
/// </summary>
public class ApiErrorExceptionApiErrorHandler : IExceptionApiErrorHandler
{
    /// <summary>Logger for logging exceptions.</summary>
    private readonly ILogger<ApiErrorExceptionApiErrorHandler> _logger;

    /// <summary>Initializes properties.</summary>
    public ApiErrorExceptionApiErrorHandler(ILogger<ApiErrorExceptionApiErrorHandler> logger)
    {
        _logger = logger;
    }
    
    /// <inheritdoc/>
    public int Order => 0;

    /// <inheritdoc/>
    public ApiError? Handle(Exception exception) => exception switch
    {
        ApiErrorException e => Handle(e),
        _ => null
    };

    /// <summary>Handles <paramref name="exception"/>.</summary>
    /// <param name="exception">Exception to handle.</param>
    /// <returns>The <see cref="ApiError"/>.</returns>
    private ApiError Handle(ApiErrorException exception)
    {
        var logLevel = exception.ApiError.Type switch
        {
            // User errors
            ApiErrorType.InvalidArgument => LogLevel.Information,
            ApiErrorType.Unauthenticated => LogLevel.Information,
            ApiErrorType.PermissionDenied => LogLevel.Information,
            ApiErrorType.NotFound => LogLevel.Information,
            ApiErrorType.AlreadyExists => LogLevel.Information,
            ApiErrorType.ResourceExhausted => LogLevel.Information,
            // Unexpected errors
            ApiErrorType.Internal => LogLevel.Error,
            // Expected errors that should not happen
            ApiErrorType.NotImplemented => LogLevel.Warning,
            ApiErrorType.Unavailable => LogLevel.Warning,
            _ => throw new ArgumentOutOfRangeException(message: "Unknown ApiErrorType", null)
        };
        
        _logger.Log(logLevel, exception, "ApiErrorException thrown");

        return exception.ApiError;
    }
}