// Copyright 2025 Xtracked
// SPDX-License-Identifier: Apache-2.0

using System.Text.Json;
using System.Text.Json.Serialization;

namespace Xtracked.Staples.ValueHolders.Json;

/// <summary>
/// Factory to create <see cref="ValueHolderConverter{T}"/> for specific <see cref="ValueHolder{T}"/>.
/// </summary>
public class ValueHolderConverterFactory : JsonConverterFactory
{
    /// <summary>
    /// Get the <see cref="ValueHolder{T}.Value"/> type of <paramref name="objectType"/> or null if not a
    /// <see cref="ValueHolder{T}"/>.
    /// </summary>
    /// <param name="objectType">Type to get value type for.</param>
    /// <returns>Value type or null if can't get it.</returns>
    private static Type? GetValueType(Type objectType) =>
        objectType.FindGenericType(typeof(ValueHolder<>))?.GetGenericArguments()[0];
    
    /// <summary>Returns true if <paramref name="typeToConvert"/> is a <see cref="ValueHolder{T}"/>.</summary>
    /// <param name="typeToConvert">Type to check.</param>
    /// <returns>True if can convert.</returns>
    public override bool CanConvert(Type typeToConvert) => GetValueType(typeToConvert) != null;

    /// <summary>Creates a <see cref="ValueHolderConverter{T}"/> for given <paramref name="typeToConvert"/>.</summary>
    /// <param name="typeToConvert">Type to create converter for.</param>
    /// <param name="options">Options for serializing.</param>
    /// <returns>New converter.</returns>
    public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        var valueType = GetValueType(typeToConvert)!;
        var converterType = typeof(ValueHolderConverter<>).MakeGenericType(valueType);
    
        return (JsonConverter) Activator.CreateInstance(converterType)!;
    }
}