// Copyright 2024 Xtracked
// SPDX-License-Identifier: Apache-2.0

using Xtracked.Staples.ApiErrors.Models;

namespace Xtracked.Staples.ApiErrors.Handlers;

/// <summary>
/// Handler for an <see cref="Exception"/> that it might be able to translate to a corresponding <see cref="ApiError"/>.
/// </summary>
public interface IExceptionApiErrorHandler
{
    /// <summary>
    /// In case multiple handlers are registered, this defines the order in which handlers should be called. Highest
    /// order will be executed first.
    /// </summary>
    public int Order { get; }

    /// <summary>
    /// Handles the <paramref name="exception"/>, returning a corresponding <see cref="ApiError"/> or <c>null</c> if
    /// <paramref name="exception"/> was not handled.
    /// </summary>
    /// <param name="exception">The exception to handle.</param>
    /// <returns>The <see cref="ApiError"/> or <c>null</c> if not handled.</returns>
    public ApiError? Handle(Exception exception);
}