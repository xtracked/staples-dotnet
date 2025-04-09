// Copyright 2025 Xtracked
// SPDX-License-Identifier: Apache-2.0

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Xtracked.Staples.ApiErrors.Models;
using Xtracked.Staples.ApiErrors.Utils;

namespace Xtracked.Staples.ApiErrors.AspNetCore;

/// <summary>
/// Factory for producing <see cref="ApiError"/> for the given <see cref="IClientErrorActionResult"/>.
/// </summary>
public class ApiErrorClientErrorFactory : IClientErrorFactory
{
    /// <inheritdoc/>
    public IActionResult GetClientError(ActionContext actionContext, IClientErrorActionResult clientError)
    {
        var statusCode = clientError.StatusCode ?? 500;
        var apiErrorType = ApiErrorTypeUtil.FromStatusCode(statusCode);

        // If no matching ApiErrorType, then this must be a specific HTTP error and not a known API error, so simply
        // return an empty result instead
        if (apiErrorType == null)
            return new StatusCodeResult(statusCode);
        
        var apiError = new ApiError(
            statusCode,
            apiErrorType.Value,
            apiErrorType.Value.GetDefaultErrorMessage()
        );
                
        return new ObjectResult(apiError)
        {
            StatusCode = apiError.Status,
        };
    }
}