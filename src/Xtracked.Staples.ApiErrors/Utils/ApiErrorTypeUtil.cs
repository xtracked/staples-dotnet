// Copyright 2024 Xtracked
// SPDX-License-Identifier: Apache-2.0

using Xtracked.Staples.ApiErrors.Models;

namespace Xtracked.Staples.ApiErrors.Utils;

/// <summary>Utility methods for <see cref="ApiErrorType"/>.</summary>
public static class ApiErrorTypeUtil
{
    /// <summary>
    /// Returns the <see cref="ApiErrorType"/> that best matches given <paramref name="statusCode"/> or <c>null</c> if
    /// there is no best match.
    /// </summary>
    /// <param name="statusCode">The status code for which to get <see cref="ApiErrorType"/>.</param>
    /// <returns>The best matching <see cref="ApiErrorType"/>.</returns>
    public static ApiErrorType? FromStatusCode(int statusCode) => statusCode switch
    {
        400 => ApiErrorType.InvalidArgument,
        401 => ApiErrorType.Unauthenticated,
        403 => ApiErrorType.PermissionDenied,
        404 => ApiErrorType.NotFound,
        409 => ApiErrorType.AlreadyExists,
        422 => ApiErrorType.InvalidArgument,
        429 => ApiErrorType.ResourceExhausted,
        500 => ApiErrorType.Internal,
        501 => ApiErrorType.NotImplemented,
        503 => ApiErrorType.Unavailable,
        _ => null
    };
    
    /// <summary>Get the default error message for given <paramref name="apiErrorType"/>.</summary>
    /// <param name="apiErrorType">The type to get default error message for.</param>
    /// <returns>The default error message.</returns>
    /// <exception cref="ArgumentOutOfRangeException">If <paramref name="apiErrorType"/> unknown.</exception>
    public static string GetDefaultErrorMessage(this ApiErrorType apiErrorType) => apiErrorType switch
    {
        ApiErrorType.InvalidArgument => "The input was not valid.",
        ApiErrorType.Unauthenticated => "The request did not include valid authentication credentials.",
        ApiErrorType.PermissionDenied => "The user is not authorized to make this request.",
        ApiErrorType.NotFound => "The specified resource was not found.",
        ApiErrorType.AlreadyExists => "The resource already exists.",
        ApiErrorType.ResourceExhausted => "Resource has been exhausted.",
        ApiErrorType.Internal => "Internal error.",
        ApiErrorType.NotImplemented => "The operation is not implemented or is not supported/enabled in this service.",
        ApiErrorType.Unavailable => "The service is currently unavailable.",
        _ => throw new ArgumentOutOfRangeException(nameof(apiErrorType), apiErrorType, null)
    };
}