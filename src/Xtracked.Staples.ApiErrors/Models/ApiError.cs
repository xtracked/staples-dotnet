// Copyright 2025 Xtracked
// SPDX-License-Identifier: Apache-2.0

namespace Xtracked.Staples.ApiErrors.Models;

/// <summary>Response data of an API error.</summary>
/// <param name="Status">Status code for this error (e.g. the HTTP status code).</param>
/// <param name="Type">Type of the error.</param>
/// <param name="Message">Message describing the error.</param>
/// <param name="Details">Optional list with extra details of the error.</param>
public sealed record ApiError(
    int Status,
    ApiErrorType Type,
    string Message,
    IReadOnlyList<ApiErrorDetails>? Details = null
);