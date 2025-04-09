// Copyright 2025 Xtracked
// SPDX-License-Identifier: Apache-2.0

namespace Xtracked.Staples.ValueHolders.Extensions;

/// <summary>Extensions related to <see cref="TimestampedValueHolder{T}"/>.</summary>
public static class TimestampedValueHolderExtensions
{
    /// <summary>
    /// Wraps <paramref name="value"/> in a <see cref="TimestampedValueHolder{T}"/> using default
    /// <see cref="TimestampedValueHolder{T}.Timestamp"/>.
    /// </summary>
    /// <param name="value">Value to wrap.</param>
    /// <typeparam name="T">Type of the value.</typeparam>
    /// <returns>Value wrapped in timestamped holder.</returns>
    public static TimestampedValueHolder<T> ToTimestampedValueHolder<T>(this T value) => new(value);

    /// <summary>
    /// Wraps <paramref name="value"/> in a <see cref="TimestampedValueHolder{T}"/> using given
    /// <paramref name="timestamp"/>.
    /// </summary>
    /// <param name="value">Value to wrap.</param>
    /// <param name="timestamp">Timestamp for the value.</param>
    /// <typeparam name="T">Type of the value.</typeparam>
    /// <returns>Value wrapped in holder.</returns>
    public static TimestampedValueHolder<T> ToTimestampedValueHolder<T>(
        this T value, 
        DateTime timestamp
    ) => new(value) { Timestamp = timestamp };

    /// <summary>
    /// Returns the <see cref="TimestampedValueHolder{T}"/> for which the
    /// <see cref="TimestampedValueHolder{T}.Timestamp"/> is newer.
    ///
    /// In case <see cref="TimestampedValueHolder{T}.Timestamp"/> is equal, <paramref name="self"/> is returned.
    /// </summary>
    /// <param name="self">Holder to compare.</param>
    /// <param name="other">Other holder to compare with.</param>
    /// <typeparam name="T">Type of the value in the holder.</typeparam>
    /// <returns>Holder for which timestamp is newest.</returns>
    /// <remarks>Uses <see cref="Nullable.Compare{T}"/> to check value.</remarks>
    public static TimestampedValueHolder<T> Latest<T>(
        this TimestampedValueHolder<T> self,
        TimestampedValueHolder<T>? other
    ) => Nullable.Compare(self.Timestamp, other?.Timestamp) switch
    {
        < 0 => other!,
        0 => self,
        > 0 => self
    };
    
    /// <summary>
    /// Returns a <see cref="TimestampedValueHolder{T}"/> for given <paramref name="self"/> using default
    /// <see cref="TimestampedValueHolder{T}.Timestamp"/>.
    /// </summary>
    /// <param name="self">Holder to add timestamp to.</param>
    /// <typeparam name="T">Type of the value in the holder.</typeparam>
    /// <returns>Holder with timestamp.</returns>
    public static TimestampedValueHolder<T> WithTimestamp<T>(this ValueHolder<T> self) => 
        self.Value.ToTimestampedValueHolder();
    
    /// <summary>
    /// Returns a <see cref="TimestampedValueHolder{T}"/> for given <paramref name="self"/> using given
    /// <paramref name="timestamp"/>.
    /// </summary>
    /// <param name="self">Holder to add timestamp to.</param>
    /// <param name="timestamp">Timestamp for the value.</param>
    /// <typeparam name="T">Type of the value in the holder.</typeparam>
    /// <returns>Holder with timestamp.</returns>
    public static TimestampedValueHolder<T> WithTimestamp<T>(this ValueHolder<T> self, DateTime timestamp) => 
        self.Value.ToTimestampedValueHolder(timestamp);
}