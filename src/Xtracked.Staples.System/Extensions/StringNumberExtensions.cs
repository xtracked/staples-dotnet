// Copyright 2025 Xtracked
// SPDX-License-Identifier: Apache-2.0

using System.Globalization;

namespace Xtracked.Staples.System.Extensions;

/// <summary>Extensions for converting <see cref="string"/> to a number.</summary>
public static class StringNumberExtensions
{
    /// <summary>Parses <paramref name="self"/> as a <see cref="byte"/> and returns the result.</summary>
    /// <param name="self">Value to parse.</param>
    /// <param name="style">Style to parse value with. Default <see cref="NumberStyles.Integer"/>.</param>
    /// <param name="formatProvider">Provider of format to parse value with. Default <c>null</c>.</param>
    /// <returns>Parsed value.</returns>
    /// <exception cref="FormatException">If <paramref name="self"/> not of the correct format.</exception>
    public static byte ToByte(
        this string self,
        NumberStyles style = NumberStyles.Integer, 
        IFormatProvider? formatProvider = null
    ) => byte.Parse(self, style, formatProvider);
    
    /// <summary>
    /// Parses <paramref name="self"/> as a <see cref="byte"/> and returns the result or <c>null</c> if parsing
    /// failed.
    /// </summary>
    /// <param name="self">Value to parse.</param>
    /// <param name="style">Style to parse value with. Default <see cref="NumberStyles.Integer"/>.</param>
    /// <param name="formatProvider">Provider of format to parse value with. Default <c>null</c>.</param>
    /// <returns>Parsed value or <c>null</c> if parsing failed.</returns>
    public static byte? ToByteOrNull(
        this string self,
        NumberStyles style = NumberStyles.Integer, 
        IFormatProvider? formatProvider = null
    ) => byte.TryParse(self, style, formatProvider, out var number) ? number : null;
    
    /// <summary>Parses <paramref name="self"/> as a <see cref="short"/> and returns the result.</summary>
    /// <param name="self">Value to parse.</param>
    /// <param name="style">Style to parse value with. Default <see cref="NumberStyles.Integer"/>.</param>
    /// <param name="formatProvider">Provider of format to parse value with. Default <c>null</c>.</param>
    /// <returns>Parsed value.</returns>
    /// <exception cref="FormatException">If <paramref name="self"/> not of the correct format.</exception>
    public static short ToShort(
        this string self,
        NumberStyles style = NumberStyles.Integer, 
        IFormatProvider? formatProvider = null
    ) => short.Parse(self, style, formatProvider);
    
    /// <summary>
    /// Parses <paramref name="self"/> as a <see cref="short"/> and returns the result or <c>null</c> if parsing
    /// failed.
    /// </summary>
    /// <param name="self">Value to parse.</param>
    /// <param name="style">Style to parse value with. Default <see cref="NumberStyles.Integer"/>.</param>
    /// <param name="formatProvider">Provider of format to parse value with. Default <c>null</c>.</param>
    /// <returns>Parsed value or <c>null</c> if parsing failed.</returns>
    public static short? ToShortOrNull(
        this string self,
        NumberStyles style = NumberStyles.Integer, 
        IFormatProvider? formatProvider = null
    ) => short.TryParse(self, style, formatProvider, out var number) ? number : null;
    
    /// <summary>Parses <paramref name="self"/> as a <see cref="ushort"/> and returns the result.</summary>
    /// <param name="self">Value to parse.</param>
    /// <param name="style">Style to parse value with. Default <see cref="NumberStyles.Integer"/>.</param>
    /// <param name="formatProvider">Provider of format to parse value with. Default <c>null</c>.</param>
    /// <returns>Parsed value.</returns>
    /// <exception cref="FormatException">If <paramref name="self"/> not of the correct format.</exception>
    public static ushort ToUshort(
        this string self,
        NumberStyles style = NumberStyles.Integer, 
        IFormatProvider? formatProvider = null
    ) => ushort.Parse(self, style, formatProvider);
    
    /// <summary>
    /// Parses <paramref name="self"/> as a <see cref="ushort"/> and returns the result or <c>null</c> if parsing
    /// failed.
    /// </summary>
    /// <param name="self">Value to parse.</param>
    /// <param name="style">Style to parse value with. Default <see cref="NumberStyles.Integer"/>.</param>
    /// <param name="formatProvider">Provider of format to parse value with. Default <c>null</c>.</param>
    /// <returns>Parsed value or <c>null</c> if parsing failed.</returns>
    public static ushort? ToUshortOrNull(
        this string self,
        NumberStyles style = NumberStyles.Integer, 
        IFormatProvider? formatProvider = null
    ) => ushort.TryParse(self, style, formatProvider, out var number) ? number : null;
    
    /// <summary>Parses <paramref name="self"/> as a <see cref="int"/> and returns the result.</summary>
    /// <param name="self">Value to parse.</param>
    /// <param name="style">Style to parse value with. Default <see cref="NumberStyles.Integer"/>.</param>
    /// <param name="formatProvider">Provider of format to parse value with. Default <c>null</c>.</param>
    /// <returns>Parsed value.</returns>
    /// <exception cref="FormatException">If <paramref name="self"/> not of the correct format.</exception>
    public static int ToInt(
        this string self,
        NumberStyles style = NumberStyles.Integer, 
        IFormatProvider? formatProvider = null
    ) => int.Parse(self, style, formatProvider);
    
    /// <summary>
    /// Parses <paramref name="self"/> as a <see cref="int"/> and returns the result or <c>null</c> if parsing
    /// failed.
    /// </summary>
    /// <param name="self">Value to parse.</param>
    /// <param name="style">Style to parse value with. Default <see cref="NumberStyles.Integer"/>.</param>
    /// <param name="formatProvider">Provider of format to parse value with. Default <c>null</c>.</param>
    /// <returns>Parsed value or <c>null</c> if parsing failed.</returns>
    public static int? ToIntOrNull(
        this string self,
        NumberStyles style = NumberStyles.Integer, 
        IFormatProvider? formatProvider = null
    ) => int.TryParse(self, style, formatProvider, out var number) ? number : null;
    
    /// <summary>Parses <paramref name="self"/> as a <see cref="uint"/> and returns the result.</summary>
    /// <param name="self">Value to parse.</param>
    /// <param name="style">Style to parse value with. Default <see cref="NumberStyles.Integer"/>.</param>
    /// <param name="formatProvider">Provider of format to parse value with. Default <c>null</c>.</param>
    /// <returns>Parsed value.</returns>
    /// <exception cref="FormatException">If <paramref name="self"/> not of the correct format.</exception>
    public static uint ToUint(
        this string self,
        NumberStyles style = NumberStyles.Integer, 
        IFormatProvider? formatProvider = null
    ) => uint.Parse(self, style, formatProvider);
    
    /// <summary>
    /// Parses <paramref name="self"/> as a <see cref="uint"/> and returns the result or <c>null</c> if parsing
    /// failed.
    /// </summary>
    /// <param name="self">Value to parse.</param>
    /// <param name="style">Style to parse value with. Default <see cref="NumberStyles.Integer"/>.</param>
    /// <param name="formatProvider">Provider of format to parse value with. Default <c>null</c>.</param>
    /// <returns>Parsed value or <c>null</c> if parsing failed.</returns>
    public static uint? ToUintOrNull(
        this string self,
        NumberStyles style = NumberStyles.Integer, 
        IFormatProvider? formatProvider = null
    ) => uint.TryParse(self, style, formatProvider, out var number) ? number : null;
    
    /// <summary>Parses <paramref name="self"/> as a <see cref="long"/> and returns the result.</summary>
    /// <param name="self">Value to parse.</param>
    /// <param name="style">Style to parse value with. Default <see cref="NumberStyles.Integer"/>.</param>
    /// <param name="formatProvider">Provider of format to parse value with. Default <c>null</c>.</param>
    /// <returns>Parsed value.</returns>
    /// <exception cref="FormatException">If <paramref name="self"/> not of the correct format.</exception>
    public static long ToLong(
        this string self,
        NumberStyles style = NumberStyles.Integer, 
        IFormatProvider? formatProvider = null
    ) => long.Parse(self, style, formatProvider);
    
    /// <summary>
    /// Parses <paramref name="self"/> as a <see cref="long"/> and returns the result or <c>null</c> if parsing
    /// failed.
    /// </summary>
    /// <param name="self">Value to parse.</param>
    /// <param name="style">Style to parse value with. Default <see cref="NumberStyles.Integer"/>.</param>
    /// <param name="formatProvider">Provider of format to parse value with. Default <c>null</c>.</param>
    /// <returns>Parsed value or <c>null</c> if parsing failed.</returns>
    public static long? ToLongOrNull(
        this string self,
        NumberStyles style = NumberStyles.Integer, 
        IFormatProvider? formatProvider = null
    ) => long.TryParse(self, style, formatProvider, out var number) ? number : null;
    
    /// <summary>Parses <paramref name="self"/> as a <see cref="ulong"/> and returns the result.</summary>
    /// <param name="self">Value to parse.</param>
    /// <param name="style">Style to parse value with. Default <see cref="NumberStyles.Integer"/>.</param>
    /// <param name="formatProvider">Provider of format to parse value with. Default <c>null</c>.</param>
    /// <returns>Parsed value.</returns>
    /// <exception cref="FormatException">If <paramref name="self"/> not of the correct format.</exception>
    public static ulong ToUlong(
        this string self,
        NumberStyles style = NumberStyles.Integer,
        IFormatProvider? formatProvider = null
    ) => ulong.Parse(self, style, formatProvider);
    
    /// <summary>
    /// Parses <paramref name="self"/> as a <see cref="ulong"/> and returns the result or <c>null</c> if parsing
    /// failed.
    /// </summary>
    /// <param name="self">Value to parse.</param>
    /// <param name="style">Style to parse value with. Default <see cref="NumberStyles.Integer"/>.</param>
    /// <param name="formatProvider">Provider of format to parse value with. Default <c>null</c>.</param>
    /// <returns>Parsed value or <c>null</c> if parsing failed.</returns>
    public static ulong? ToUlongOrNull(
        this string self,
        NumberStyles style = NumberStyles.Integer, 
        IFormatProvider? formatProvider = null
    ) => ulong.TryParse(self, style, formatProvider, out var number) ? number : null;
    
    /// <summary>Parses <paramref name="self"/> as a <see cref="decimal"/> and returns the result.</summary>
    /// <param name="self">Value to parse.</param>
    /// <param name="style">Style to parse value with. Default <see cref="NumberStyles.Number"/>.</param>
    /// <param name="formatProvider">Provider of format to parse value with. Default <c>null</c>.</param>
    /// <returns>Parsed value.</returns>
    /// <exception cref="FormatException">If <paramref name="self"/> not of the correct format.</exception>
    public static decimal ToDecimal(
        this string self, 
        NumberStyles style = NumberStyles.Number, 
        IFormatProvider? formatProvider = null
    ) => decimal.Parse(self, style, formatProvider);
    
    /// <summary>
    /// Parses <paramref name="self"/> as a <see cref="decimal"/> and returns the result or <c>null</c> if parsing
    /// failed.
    /// </summary>
    /// <param name="self">Value to parse.</param>
    /// <param name="style">Style to parse value with. Default <see cref="NumberStyles.Number"/>.</param>
    /// <param name="formatProvider">Provider of format to parse value with. Default <c>null</c>.</param>
    /// <returns>Parsed value or <c>null</c> if parsing failed.</returns>
    public static decimal? ToDecimalOrNull(
        this string self, 
        NumberStyles style = NumberStyles.Number, 
        IFormatProvider? formatProvider = null
    ) => decimal.TryParse(self, style, formatProvider, out var number) ? number : null;
    
    /// <summary>Parses <paramref name="self"/> as a <see cref="double"/> and returns the result.</summary>
    /// <param name="self">Value to parse.</param>
    /// <param name="style">
    /// Style to parse value with. Default <see cref="NumberStyles.Float"/> <c>|</c>
    /// <see cref="NumberStyles.AllowThousands"/>.
    /// </param>
    /// <param name="formatProvider">Provider of format to parse value with. Default <c>null</c>.</param>
    /// <returns>Parsed value.</returns>
    /// <exception cref="FormatException">If <paramref name="self"/> not of the correct format.</exception>
    public static double ToDouble(
        this string self, 
        NumberStyles style = NumberStyles.Float | NumberStyles.AllowThousands, 
        IFormatProvider? formatProvider = null
    ) => double.Parse(self, style, formatProvider);
    
    /// <summary>
    /// Parses <paramref name="self"/> as a <see cref="double"/> and returns the result or <c>null</c> if parsing
    /// failed.
    /// </summary>
    /// <param name="self">Value to parse.</param>
    /// <param name="style">
    /// Style to parse value with. Default <see cref="NumberStyles.Float"/> <c>|</c>
    /// <see cref="NumberStyles.AllowThousands"/>.
    /// </param>
    /// <param name="formatProvider">Provider of format to parse value with. Default <c>null</c>.</param>
    /// <returns>Parsed value or <c>null</c> if parsing failed.</returns>
    public static double? ToDoubleOrNull(
        this string self, 
        NumberStyles style = NumberStyles.Float | NumberStyles.AllowThousands, 
        IFormatProvider? formatProvider = null
    ) => double.TryParse(self, style, formatProvider, out var number) ? number : null;
}