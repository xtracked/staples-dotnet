// Copyright 2025 Xtracked
// SPDX-License-Identifier: Apache-2.0

using System.Text.Json;
using System.Text.Json.Serialization;

namespace Xtracked.Staples.ValueHolders.Json;

/// <summary>Extensions for <see cref="JsonSerializerOptions"/>.</summary>
public static class JsonSerializerOptionsExtensions
{
    /// <summary>Applies <see cref="ValueHolder{T}"/> related options to <paramref name="options"/>.</summary>
    /// <param name="options">Options to initialize.</param>
    /// <param name="ignoreNullValues">
    /// Whether to ignore null values: Does not write <c>ValueHolder&lt;int?&gt;? = null</c>, but does write
    /// <c>ValueHolder&lt;int?&gt;? = new ValueHolder(null)</c>. Default <c>true</c>.
    /// </param>
    /// <returns>The initialized <paramref name="options"/>.</returns>
    public static JsonSerializerOptions ApplyValueHolderOptions(
        this JsonSerializerOptions options, 
        bool ignoreNullValues = true
    )
    {
        // The factory that creates the ValueHolder<T> converters on the fly
        options.Converters.Add(new ValueHolderConverterFactory());

        if (ignoreNullValues)
        {
            // Setting to WhenWritingNull will ignore 'ValueHolder<int?> = null' but still serialize
            // 'ValueHolder<int?> = new ValueHolder(null)', which is what we want: Include explicit null
            // Note that this option only affects serialization, not deserialization
            options.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        }
            
        return options;
    }
}