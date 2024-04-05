// Copyright 2024 Xtracked
// SPDX-License-Identifier: Apache-2.0

using Microsoft.AspNetCore.Builder;
using Xtracked.Staples.ApiErrors.Models;

namespace Xtracked.Staples.ApiErrors.AspNetCore.Extensions;

/// <summary>Extensions for <see cref="IApplicationBuilder"/>.</summary>
public static class ApplicationBuilderExtensions
{
    /// <summary>Adds middleware types related to <see cref="ApiError"/>.</summary>
    /// <param name="app">The <see cref="IApplicationBuilder"/> instance.</param>
    /// <returns>The <see cref="IApplicationBuilder"/> instance.</returns>
    /// <remarks>
    /// This must be called early in the pipeline so that it can handle exceptions thrown early in the pipeline (e.g. by
    /// other middlewares).
    /// </remarks>
    public static IApplicationBuilder UseApiErrorMiddlewares(this IApplicationBuilder app) =>
        app.UseMiddleware<ApiErrorHandlerMiddleware>()
            .UseMiddleware<AuthorizationApiErrorMiddleware>();
}