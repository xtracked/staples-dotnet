// Copyright 2025 Xtracked
// SPDX-License-Identifier: Apache-2.0

using FluentValidation;
using Microsoft.Extensions.Logging;
using Xtracked.Staples.ApiErrors.Handlers;
using Xtracked.Staples.ApiErrors.Models;
using Xtracked.Staples.ApiErrors.Utils;

namespace Xtracked.Staples.ApiErrors.FluentValidation;

/// <summary>Handler that handles any <see cref="ValidationException"/>, returning the <see cref="ApiError"/>.</summary>
public class ValidationExceptionApiErrorHandler : IExceptionApiErrorHandler
{
    /// <summary>Status for the <see cref="ApiError"/>.</summary>
    private const int ApiErrorStatus = 422;
    
    /// <summary>Logger for logging exceptions.</summary>
    private readonly ILogger<ValidationExceptionApiErrorHandler> _logger;

    /// <summary>Initializes properties.</summary>
    public ValidationExceptionApiErrorHandler(ILogger<ValidationExceptionApiErrorHandler> logger)
    {
        _logger = logger;
    }
    
    /// <inheritdoc/>
    public int Order => 0;
    
    /// <inheritdoc/>
    public ApiError? Handle(Exception exception) => exception switch
    {
        ValidationException e => Handle(e),
        _ => null
    };

    /// <summary>Handles <paramref name="exception"/>.</summary>
    /// <param name="exception">Exception to handle.</param>
    /// <returns>The <see cref="ApiError"/>.</returns>
    private ApiError Handle(ValidationException exception)
    {
        // Validation is a user error, so log as information for debugging purposes
        _logger.LogInformation(exception, "ValidationException thrown");

        return new ApiError(
            ApiErrorStatus,
            ApiErrorType.InvalidArgument,
            ApiErrorType.InvalidArgument.GetDefaultErrorMessage(),
            // Transform validation errors to ErrorDetails
            exception.Errors
                .Select(it => new ApiErrorDetails(it.PropertyName, it.ErrorMessage))
                .ToList()
        );
    }
}