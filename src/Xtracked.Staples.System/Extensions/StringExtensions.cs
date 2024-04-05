// Copyright 2024 Xtracked
// SPDX-License-Identifier: Apache-2.0

namespace Xtracked.Staples.System.Extensions;

/// <summary>Extensions for <see cref="string"/>.</summary>
public static class StringExtensions
{
    /// <summary>Returns true if <paramref name="self"/> is empty.</summary>
    public static bool IsEmpty(this string self) => string.IsNullOrEmpty(self);
    /// <summary>Returns true if <paramref name="self"/> is not empty.</summary>
    public static bool IsNotEmpty(this string self) => !string.IsNullOrEmpty(self);
    /// <summary>Returns true if <paramref name="self"/> is null or empty.</summary>
    public static bool IsNullOrEmpty(this string? self) => string.IsNullOrEmpty(self);

    /// <summary>Returns true if <paramref name="self"/> is empty or consists solely of whitespace characters.</summary>
    public static bool IsBlank(this string self) => string.IsNullOrWhiteSpace(self);
    /// <summary>
    /// Returns true if <paramref name="self"/> is not empty and does not consist of solely whitespace characters.
    /// </summary>
    public static bool IsNotBlank(this string self) => !string.IsNullOrWhiteSpace(self);
    /// <summary>
    /// Returns true if <paramref name="self"/> is null, empty or consists solely of whitespace characters.
    /// </summary>
    public static bool IsNullOrBlank(this string? self) => string.IsNullOrWhiteSpace(self);
}