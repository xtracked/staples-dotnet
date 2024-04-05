// Copyright 2024 Xtracked
// SPDX-License-Identifier: Apache-2.0

using Microsoft.Extensions.Logging;
using Xtracked.Staples.ApiErrors.Models;

namespace Xtracked.Staples.ApiErrors.Handlers;

/// <summary>
/// Handler that handles any <see cref="Exception"/>, returning an <see cref="ApiErrorType.Internal"/> error. This
/// handler should be run last as it handles any <see cref="Exception"/> not yet handled.
/// </summary>
public class ExceptionApiErrorHandler : IExceptionApiErrorHandler
{
    /// <summary>Status for the <see cref="ApiError"/>.</summary>
    private const int ApiErrorStatus = 500;
    
    /// <summary>Logger for logging exceptions.</summary>
    private readonly ILogger<ExceptionApiErrorHandler> _logger;

    /// <summary>Initializes properties.</summary>
    public ExceptionApiErrorHandler(ILogger<ExceptionApiErrorHandler> logger)
    {
        _logger = logger;
    }
    
    /// <inheritdoc/>
    public int Order => int.MinValue;
    
    /// <inheritdoc/>
    public ApiError Handle(Exception exception)
    {
        _logger.LogError(exception, "Unknown exception");
        
        return new ApiError(
            ApiErrorStatus,
            ApiErrorType.Internal,
            "Internal error."
        );
    }
}