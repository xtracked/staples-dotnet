// Copyright 2025 Xtracked
// SPDX-License-Identifier: Apache-2.0

using Xtracked.Staples.ApiErrors.Models;

namespace Xtracked.Staples.ApiErrors.Exceptions;

/// <summary>Exception when request does not have valid authentication credentials for the operation.</summary>
public class UnauthenticatedException : ApiErrorException
{
    /// <inheritdoc/>
    public override ApiError ApiError { get; }
    
    /// <inheritdoc/>
    public UnauthenticatedException() : this(null)
    {
    }

    /// <inheritdoc/>
    public UnauthenticatedException(string? message) : this(message, null)
    {
    }

    /// <inheritdoc/>
    public UnauthenticatedException(string? message, Exception? innerException) : base(message, innerException)
    {
        ApiError = new ApiError(
            401,
            ApiErrorType.Unauthenticated,
            message ?? "The request did not include valid authentication credentials."
        );
    }
}