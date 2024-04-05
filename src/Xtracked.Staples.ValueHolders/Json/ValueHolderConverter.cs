// Copyright 2024 Xtracked
// SPDX-License-Identifier: Apache-2.0

using System.Text.Json;
using System.Text.Json.Serialization;

namespace Xtracked.Staples.ValueHolders.Json;

/// <summary>Converter for <see cref="ValueHolder{T}"/>.</summary>
/// <typeparam name="T">Type of the value in <see cref="ValueHolder{T}"/>.</typeparam>
/// <remarks>
/// Use this to convert a specific <typeparamref name="T"/>, use <see cref="ValueHolderConverterFactory"/> to convert
/// any <see cref="ValueHolder{T}"/>.
/// </remarks>
public class ValueHolderConverter<T> : JsonConverter<ValueHolder<T>>
{
    /// <summary><see cref="ValueHolder{T}"/> requires special null-handling, so always handle <c>null</c>.</summary>
    public override bool HandleNull => true;

    /// <inheritdoc/>
    public override ValueHolder<T> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        try
        {
            var value = JsonSerializer.Deserialize<T>(ref reader, options);
#pragma warning disable CS8604 // T may be a nullable type itself, so 'null' is a valid value
            return new ValueHolder<T>(value);
#pragma warning restore CS8604
        }
        catch (JsonException e)
        {
            /* We wrap exception for nested value in a new exception so serializer will set default message, but with
             * the current path. This is because a call to JsonSerializer.Deserialize() resets the path to the root
             * again due to it missing context on where it currently is in the JSON structure. We can't get the current
             * path in this Read() method either, as it's hidden by an internal 'ReadStack', only available in internal
             * code (ReadCore()).
             *
             * The best we can do is wrap it and allow an exception handler to rebuild the full path by checking the
             * inner exceptions.
             */
            throw new JsonException(null, e);
        }
    }

    /// <inheritdoc/>
    public override void Write(Utf8JsonWriter writer, ValueHolder<T>? value, JsonSerializerOptions options)
    {
        if (value != null) 
            JsonSerializer.Serialize(writer, value.Value, options);
    }
}