// Copyright 2024 Xtracked
// SPDX-License-Identifier: Apache-2.0

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Xtracked.Staples.ApiErrors.AspNetCore;

/// <summary>
/// Sets up JSON options for <see cref="MvcOptions"/> to use <see cref="ThrowingSystemTextJsonInputFormatter"/> so
/// exceptions will be thrown.
/// </summary>
/// <remarks>
/// Based on https://github.com/dotnet/aspnetcore/blob/29f59f5d93ffe8fbae49c5916f86707cc61097f6/src/Mvc/Mvc.NewtonsoftJson/src/DependencyInjection/NewtonsoftJsonMvcOptionsSetup.cs
/// </remarks>
internal sealed class ThrowingSystemTextJsonMvcOptionsSetup : IConfigureOptions<MvcOptions>
{
    /// <summary>Factory to create <see cref="ILogger"/>.</summary>
    private readonly ILoggerFactory _loggerFactory;
    /// <summary>Options for JSON.</summary>
    private readonly IOptions<JsonOptions> _jsonOptions;

    /// <summary>Initializes properties.</summary>
    /// <param name="loggerFactory">Factory to create <see cref="ILogger"/>.</param>
    /// <param name="jsonOptions">Options for JSON.</param>
    public ThrowingSystemTextJsonMvcOptionsSetup(ILoggerFactory loggerFactory, IOptions<JsonOptions> jsonOptions)
    {
        _loggerFactory = loggerFactory;
        _jsonOptions = jsonOptions;
    }

    /// <inheritdoc/>
    public void Configure(MvcOptions options)
    {
        // Remove default SystemTextJsonInputFormatter as we're replacing it
        options.InputFormatters.RemoveType<SystemTextJsonInputFormatter>();
        // Add our own formatter that throws the exception instead of using ModelState
        options.InputFormatters.Add(new ThrowingSystemTextJsonInputFormatter(
            _jsonOptions.Value, 
            _loggerFactory.CreateLogger<ThrowingSystemTextJsonInputFormatter>())
        );
    }
}