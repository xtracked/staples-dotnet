// Copyright 2024 Xtracked
// SPDX-License-Identifier: Apache-2.0

namespace Xtracked.Staples.System.Extensions;

/// <summary>Extensions related to <see cref="Task"/> generic for all objects.</summary>
public static class ObjectTaskExtensions
{
    /// <summary>Wraps <paramref name="value"/> in a <see cref="Task{T}"/>.</summary>
    /// <seealso cref="Task.FromResult{T}"/>
    /// <param name="value">Value to wrap.</param>
    /// <typeparam name="T">Type of the value.</typeparam>
    /// <returns>Value wrapped in task.</returns>
    public static Task<T> ToTask<T>(this T value) => Task.FromResult(value);
}