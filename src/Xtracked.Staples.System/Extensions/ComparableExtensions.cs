// Copyright 2024 Xtracked
// SPDX-License-Identifier: Apache-2.0

namespace Xtracked.Staples.System.Extensions;

/// <summary>Extensions for <see cref="IComparable"/>.</summary>
public static class ComparableExtensions
{
    /// <summary>
    /// Ensures that <paramref name="value"/> is not less than given <paramref name="minimumValue"/>.
    /// </summary>
    /// <param name="value">Value to check.</param>
    /// <param name="minimumValue">Minimum value.</param>
    /// <returns>
    /// <paramref name="value"/> if it's greater than or equal to <paramref name="minimumValue"/> or the
    /// <paramref name="minimumValue"/> otherwise.
    /// </returns>
    /// <remarks>
    /// Based on <a href="https://kotlinlang.org/api/latest/jvm/stdlib/kotlin.ranges/coerce-at-least.html">
    /// Kotlin's coerceAtLeast function</a>.
    /// </remarks>
    public static T CoerceAtLeast<T>(this T value, T minimumValue) where T : IComparable<T> =>
        value.CompareTo(minimumValue) < 0 ? minimumValue : value;
    
    /// <summary>
    /// Ensures that <paramref name="value"/> is not greater than given <paramref name="maximumValue"/>.
    /// </summary>
    /// <param name="value">Value to check.</param>
    /// <param name="maximumValue">Maximum value.</param>
    /// <returns>
    /// <paramref name="value"/> if it's less than or equal to <paramref name="maximumValue"/> or the
    /// <paramref name="maximumValue"/> otherwise.
    /// </returns>
    /// <remarks>
    /// Based on <a href="https://kotlinlang.org/api/latest/jvm/stdlib/kotlin.ranges/coerce-at-most.html">Kotlin's
    /// coerceAtMost function</a>.
    /// </remarks>
    public static T CoerceAtMost<T>(this T value, T maximumValue) where T : IComparable<T> =>
        value.CompareTo(maximumValue) > 0 ? maximumValue : value;
    
    /// <summary>
    /// Ensures that <paramref name="value"/> is in range
    /// <paramref name="minimumValue"/>..<paramref name="maximumValue"/>.
    /// </summary>
    /// <param name="value">Value to check.</param>
    /// <param name="minimumValue">Minimum value.</param>
    /// <param name="maximumValue">Maximum value.</param>
    /// <returns>
    /// <paramref name="value"/> if in range, or <paramref name="minimumValue"/> if less than
    /// <paramref name="minimumValue"/>, or <paramref name="maximumValue"/> if greater than
    /// <paramref name="maximumValue"/>.
    /// </returns>
    /// <exception cref="ArgumentException">
    /// If <paramref name="minimumValue"/> greater than <paramref name="maximumValue"/>.
    /// </exception>
    /// <remarks>
    /// Based on <a href="https://kotlinlang.org/api/latest/jvm/stdlib/kotlin.ranges/coerce-in.html">Kotlin's
    /// coerceIn function</a>.
    /// </remarks>
    public static T CoerceIn<T>(this T value, T minimumValue, T maximumValue) where T : IComparable<T>
    {
        if (minimumValue.CompareTo(maximumValue) > 0)
            throw new ArgumentException(
                $"Cannot coerce value to an empty range: maximum {maximumValue} is less than minimum {minimumValue}."
            );
        
        if (value.CompareTo(minimumValue) < 0) 
            return minimumValue;
        if (value.CompareTo(maximumValue) > 0)
            return maximumValue;
        
        return value;
    }
}