// Copyright 2025 Xtracked
// SPDX-License-Identifier: Apache-2.0

namespace Xtracked.Staples.ValueHolders.Extensions;

/// <summary>Extensions related to <see cref="ValueHolder{T}"/>.</summary>
public static class ValueHolderExtensions
{
    /// <summary>Wraps <paramref name="value"/> in a <see cref="ValueHolder{T}"/>.</summary>
    /// <param name="value">Value to wrap.</param>
    /// <typeparam name="T">Type of the value.</typeparam>
    /// <returns>Value wrapped in holder.</returns>
    public static ValueHolder<T> ToValueHolder<T>(this T value) => new(value);
}