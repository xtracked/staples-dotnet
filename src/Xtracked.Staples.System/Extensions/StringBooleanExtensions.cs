// Copyright 2025 Xtracked
// SPDX-License-Identifier: Apache-2.0

namespace Xtracked.Staples.System.Extensions;

/// <summary>Extensions for converting <see cref="string"/> to a <see cref="bool"/>.</summary>
public static class StringBooleanExtensions
{
    /// <summary>Parses <paramref name="self"/> as a <see cref="bool"/> and returns the result.</summary>
    /// <param name="self">Value to parse.</param>
    /// <returns>Parsed value.</returns>
    /// <exception cref="FormatException">If <paramref name="self"/> not of the correct format.</exception>
    public static bool ToBool(this string self) => bool.Parse(self);
    
    /// <summary>
    /// Parses <paramref name="self"/> as a <see cref="bool"/> and returns the result or <c>null</c> if parsing failed.
    /// </summary>
    /// <param name="self">Value to parse.</param>
    /// <returns>Parsed value or <c>null</c> if parsing failed.</returns>
    public static bool? ToBoolOrNull(this string self) => bool.TryParse(self, out var boolean) ? boolean : null;
}