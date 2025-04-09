// Copyright 2025 Xtracked
// SPDX-License-Identifier: Apache-2.0

using Xtracked.Staples.ApiErrors.Models;

namespace Xtracked.Staples.ApiErrors.Exceptions;

/// <summary>Exception when a requested object was not found.</summary>
public class ObjectNotFoundException : ApiErrorException
{
    /// <inheritdoc/>
    public override ApiError ApiError { get; }
    
    /// <inheritdoc/>
    public ObjectNotFoundException() : this(null)
    {
    }

    /// <inheritdoc/>
    public ObjectNotFoundException(string? message) : this(message, null)
    {
    }

    /// <inheritdoc/>
    public ObjectNotFoundException(string? message, Exception? innerException) : base(message, innerException)
    {
        ApiError = new ApiError(
            404,
            ApiErrorType.NotFound,
            message ?? "The specified resource was not found."
        );
    }
}