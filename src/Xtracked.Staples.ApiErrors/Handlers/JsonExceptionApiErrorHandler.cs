// Copyright 2025 Xtracked
// SPDX-License-Identifier: Apache-2.0

using System.Text.Json;
using Microsoft.Extensions.Logging;
using Xtracked.Staples.ApiErrors.Extensions;
using Xtracked.Staples.ApiErrors.Models;
using Xtracked.Staples.ApiErrors.Utils;

namespace Xtracked.Staples.ApiErrors.Handlers;

/// <summary>Handler that handles any <see cref="JsonException"/>, returning the <see cref="ApiError"/>.</summary>
public class JsonExceptionApiErrorHandler : IExceptionApiErrorHandler
{
    /// <summary>Status for the <see cref="ApiError"/>.</summary>
    private const int ApiErrorStatus = 400;
    
    /// <summary>Logger for logging exceptions.</summary>
    private readonly ILogger<JsonExceptionApiErrorHandler> _logger;

    /// <summary>Initializes properties.</summary>
    public JsonExceptionApiErrorHandler(ILogger<JsonExceptionApiErrorHandler> logger)
    {
        _logger = logger;
    }
    
    /// <inheritdoc/>
    public int Order => 0;

    /// <inheritdoc/>
    public ApiError? Handle(Exception exception) => exception switch
    {
        JsonException e => Handle(e),
        _ => null
    };

    /// <summary>Handles <paramref name="exception"/>.</summary>
    /// <param name="exception">Exception to handle.</param>
    /// <returns>The <see cref="ApiError"/>.</returns>
    private ApiError Handle(JsonException exception)
    {
        // JsonException is a user error, so log as information for debugging purposes
        _logger.LogInformation(exception, "JsonException thrown");

        return new ApiError(
            ApiErrorStatus,
            ApiErrorType.InvalidArgument,
            ApiErrorType.InvalidArgument.GetDefaultErrorMessage(),
            [
                new ApiErrorDetails(exception.BuildFullPath(), "The JSON value could not be parsed.")
            ]
        );
    }
}