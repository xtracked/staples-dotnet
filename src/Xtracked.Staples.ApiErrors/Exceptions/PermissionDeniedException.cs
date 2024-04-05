// Copyright 2024 Xtracked
// SPDX-License-Identifier: Apache-2.0

using Xtracked.Staples.ApiErrors.Models;

namespace Xtracked.Staples.ApiErrors.Exceptions;

/// <summary>Exception when the caller does not have permission to execute the specified operation.</summary>
public class PermissionDeniedException : ApiErrorException
{
    /// <inheritdoc/>
    public override ApiError ApiError { get; }
    
    /// <inheritdoc/>
    public PermissionDeniedException() : this(null)
    {
    }

    /// <inheritdoc/>
    public PermissionDeniedException(string? message) : this(message, null)
    {
    }

    /// <inheritdoc/>
    public PermissionDeniedException(string? message, Exception? innerException) : base(message, innerException)
    {
        ApiError = new ApiError(
            403,
            ApiErrorType.PermissionDenied,
            message ?? "The user is not authorized to make this request."
        );
    }
}