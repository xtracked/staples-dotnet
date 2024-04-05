// Copyright 2024 Xtracked
// SPDX-License-Identifier: Apache-2.0

namespace Xtracked.Staples.ValueHolders;

/// <inheritdoc cref="ValueHolder{T}"/>
/// <summary>
/// Holder for a value of type <typeparamref name="T"/> with a certain <see cref="Timestamp"/>. The
/// <see cref="Timestamp"/> can be used to determine when the <see cref="ValueHolder{T}.Value"/> was created. This is
/// useful when dealing with e.g. text fields, where text older than latest typed in text should be discarded.
/// </summary>
public record TimestampedValueHolder<T>(T Value) : ValueHolder<T>(Value)
{
    /// <summary>Timestamp for the <see cref="ValueHolder{T}.Value"/>. Default <see cref="DateTime.Now"/>.</summary>
    public DateTime Timestamp { get; init; } = DateTime.Now;
}