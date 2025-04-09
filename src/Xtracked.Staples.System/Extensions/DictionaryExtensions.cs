// Copyright 2025 Xtracked
// SPDX-License-Identifier: Apache-2.0

namespace Xtracked.Staples.System.Extensions;

/// <summary>Extensions for <see cref="IDictionary{TKey,TValue}"/></summary>
public static class DictionaryExtensions
{
    /// <summary>Gets the value for <paramref name="key"/> or <c>default</c> if not found.</summary>
    /// <param name="self">Dictionary to get value from.</param>
    /// <param name="key">Key for which to get value.</param>
    /// <typeparam name="TKey">Type of the key.</typeparam>
    /// <typeparam name="TValue">Type of the value.</typeparam>
    /// <returns>The value or <c>default</c> if not found.</returns>
    /// <remarks>
    /// Based on <see cref="CollectionExtensions.GetValueOrDefault{TKey,TValue}(IReadOnlyDictionary{TKey,TValue},TKey)"/>.
    /// Obsolete if they ever add a native version just like <c>IReadOnlyDictionary</c>. It's even an extension in the
    /// <a href="https://learn.microsoft.com/en-us/dotnet/api/microsoft.azure.devices.common.extensions.dictionaryextensions">
    /// Azure SDK</a>.
    /// </remarks>
    public static TValue? GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> self, TKey key) => 
        self!.GetValueOrDefault(key, default);

    /// <summary>Gets the value for <paramref name="key"/> or <paramref name="defaultValue"/> if not found.</summary>
    /// <param name="self">Dictionary to get value from.</param>
    /// <param name="key">Key for which to get value.</param>
    /// <param name="defaultValue">Default value if value doesn't exist.</param>
    /// <typeparam name="TKey">Type of the key.</typeparam>
    /// <typeparam name="TValue">Type of the value.</typeparam>
    /// <returns>The value or <paramref name="defaultValue"/> if not found.</returns>
    /// <remarks>
    /// Based on <see cref="CollectionExtensions.GetValueOrDefault{TKey,TValue}(IReadOnlyDictionary{TKey,TValue},TKey,TValue)"/>.
    /// Obsolete if they ever add a native version just like <c>IReadOnlyDictionary</c>. It's even an extension in the
    /// <a href="https://learn.microsoft.com/en-us/dotnet/api/microsoft.azure.devices.common.extensions.dictionaryextensions">
    /// Azure SDK</a>.
    /// </remarks>
    public static TValue GetValueOrDefault<TKey, TValue>(
        this IDictionary<TKey, TValue> self, 
        TKey key, 
        TValue defaultValue
    ) => self.TryGetValue(key, out var value) ? value : defaultValue;
}