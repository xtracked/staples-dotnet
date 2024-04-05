// Copyright 2024 Xtracked
// SPDX-License-Identifier: Apache-2.0

using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;

namespace Xtracked.Staples.ApiErrors.AspNetCore;

/// <summary>
/// Implementation of <see cref="TextInputFormatter"/> for JSON content using <see cref="JsonSerializer"/> that throws
/// the exception instead of using <see cref="InputFormatterContext.ModelState"/> so that the exception can be handled
/// in a different module.
/// </summary>
/// <remarks>Based on <see cref="SystemTextJsonInputFormatter"/>.</remarks>
public partial class ThrowingSystemTextJsonInputFormatter : TextInputFormatter, IInputFormatterExceptionPolicy
{
    /// <summary>Copy of <see cref="MediaTypeHeaderValues.ApplicationJson"/> as that one is internal.</summary>
    private static readonly MediaTypeHeaderValue ApplicationJson = 
        MediaTypeHeaderValue.Parse("application/json").CopyAsReadOnly();
    /// <summary>Copy of <see cref="MediaTypeHeaderValues.TextJson"/> as that one is internal.</summary>
    private static readonly MediaTypeHeaderValue TextJson =
        MediaTypeHeaderValue.Parse("text/json").CopyAsReadOnly();
    /// <summary>Copy of <see cref="MediaTypeHeaderValues.ApplicationAnyJsonSyntax"/> as that one is internal.</summary>
    private static readonly MediaTypeHeaderValue ApplicationAnyJsonSyntax = 
        MediaTypeHeaderValue.Parse("application/*+json").CopyAsReadOnly();
    
    /// <summary>Logger for this class.</summary>
    private readonly ILogger<ThrowingSystemTextJsonInputFormatter> _logger;

    /// <summary>Initializes properties.</summary>
    /// <param name="options">The <see cref="JsonOptions"/>.</param>
    /// <param name="logger">The <see cref="ILogger"/>.</param>
    public ThrowingSystemTextJsonInputFormatter(
        JsonOptions options, 
        ILogger<ThrowingSystemTextJsonInputFormatter> logger
    )
    {
        SerializerOptions = options.JsonSerializerOptions;
        _logger = logger;

        // Same as what SystemTextJsonInputFormatter defines
        SupportedEncodings.Add(UTF8EncodingWithoutBOM);
        SupportedEncodings.Add(UTF16EncodingLittleEndian);

        SupportedMediaTypes.Add(ApplicationJson);
        SupportedMediaTypes.Add(TextJson);
        SupportedMediaTypes.Add(ApplicationAnyJsonSyntax);
    }

    /// <inheritdoc cref="SystemTextJsonInputFormatter.SerializerOptions"/>
    public JsonSerializerOptions SerializerOptions { get; }

    /// <inheritdoc />
    InputFormatterExceptionPolicy IInputFormatterExceptionPolicy.ExceptionPolicy => 
        InputFormatterExceptionPolicy.MalformedInputExceptions;

    /// <inheritdoc />
    [SuppressMessage("ReSharper", "MethodHasAsyncOverload")]
    public sealed override async Task<InputFormatterResult> ReadRequestBodyAsync(
        InputFormatterContext context,
        Encoding encoding
    )
    {
        ArgumentNullException.ThrowIfNull(context);
        ArgumentNullException.ThrowIfNull(encoding);

        var httpContext = context.HttpContext;
        var (inputStream, usesTranscodingStream) = GetInputStream(httpContext, encoding);

        object? model;
        try
        {
            model = await JsonSerializer.DeserializeAsync(inputStream, context.ModelType, SerializerOptions);
        }
        // Don't catch the exception here, just let it bubble up
        finally
        {
            if (usesTranscodingStream)
            {
                await inputStream.DisposeAsync();
            }
        }

        if (model == null && !context.TreatEmptyInputAsDefaultValue)
        {
            // Some nonempty inputs might deserialize as null, for example whitespace,
            // or the JSON-encoded value "null". The upstream BodyModelBinder needs to
            // be notified that we don't regard this as a real input so it can register
            // a model binding error.
            return InputFormatterResult.NoValue();
        }

        Log.JsonInputSuccess(_logger, context.ModelType);
        return InputFormatterResult.Success(model);
    }
    
    /// <summary>Copy of <see cref="SystemTextJsonInputFormatter"/>.</summary>
    private static (Stream inputStream, bool usesTranscodingStream) GetInputStream(HttpContext httpContext, Encoding encoding)
    {
        if (encoding.CodePage == Encoding.UTF8.CodePage)
        {
            return (httpContext.Request.Body, false);
        }

        var inputStream = Encoding.CreateTranscodingStream(httpContext.Request.Body, encoding, Encoding.UTF8, leaveOpen: true);
        return (inputStream, true);
    }

    /// <summary>Copy of <see cref="SystemTextJsonInputFormatter"/>.</summary>
    private static partial class Log
    {
        [LoggerMessage(2, LogLevel.Debug, "JSON input formatter succeeded, deserializing to type '{TypeName}'", EventName = "SystemTextJsonInputSuccess")]
        private static partial void JsonInputSuccess(ILogger logger, string? typeName);

        public static void JsonInputSuccess(ILogger logger, Type modelType)
            => JsonInputSuccess(logger, modelType.FullName);
    }
}