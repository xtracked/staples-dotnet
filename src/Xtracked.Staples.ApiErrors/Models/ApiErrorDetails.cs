// Copyright 2025 Xtracked
// SPDX-License-Identifier: Apache-2.0

namespace Xtracked.Staples.ApiErrors.Models;

/// <summary>Extra details for an <see cref="ApiError"/>.</summary>
/// <param name="Location">
/// The specific item that caused the error. For example if you specify an invalid value for a parameter, the location
/// will be the name of the parameter.
/// </param>
/// <param name="Message">Message describing the error.</param>
public sealed record ApiErrorDetails(
    string Location,
    string Message
);