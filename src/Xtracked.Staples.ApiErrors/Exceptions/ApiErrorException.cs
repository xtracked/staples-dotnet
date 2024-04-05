// Copyright 2024 Xtracked
// SPDX-License-Identifier: Apache-2.0

using Xtracked.Staples.ApiErrors.Models;

namespace Xtracked.Staples.ApiErrors.Exceptions;

/// <summary>Base exception for API error exceptions.</summary>
public abstract class ApiErrorException : Exception
{
    /// <summary>The error for this exception.</summary>
    public abstract ApiError ApiError { get; }
    
    /// <inheritdoc/>
    protected ApiErrorException()
    {
    }

    /// <inheritdoc/>
    protected ApiErrorException(string? message) : base(message)
    {
    }
    
    /// <inheritdoc/>
    protected ApiErrorException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}