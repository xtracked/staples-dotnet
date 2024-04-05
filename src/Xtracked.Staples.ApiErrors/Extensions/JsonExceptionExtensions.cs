// Copyright 2024 Xtracked
// SPDX-License-Identifier: Apache-2.0

using System.Text;
using System.Text.Json;

namespace Xtracked.Staples.ApiErrors.Extensions;

/// <summary>Extensions for <see cref="JsonException"/></summary>
public static class JsonExceptionExtensions
{
    /// <summary>Character of the root in a JSON path.</summary>
    private const char JsonRootChar = '$';
    
    /// <summary>
    /// Builds the full path to where the exception was encountered in the JSON, using paths from any
    /// <see cref="Exception.InnerException"/> of <paramref name="exception"/>.
    /// </summary>
    /// <param name="exception">Exception to build path for.</param>
    /// <param name="removeRoot">Whether to remove the root element (<see cref="JsonRootChar"/> at the start).</param>
    /// <returns>The full path.</returns>
    public static string BuildFullPath(this JsonException exception, bool removeRoot = true)
    {
        var path = removeRoot
            ? RemoveRoot(exception.Path, true)
            : exception.Path;
        var pathBuilder = new StringBuilder(path);
        
        // Append path of inner exceptions
        var innerException = exception.InnerException;
        while (innerException is JsonException innerJsonException)
        {
            // Always remove root of inner paths as they're nested paths, so they should not have a root
            pathBuilder.Append(RemoveRoot(innerJsonException.Path, false));
            innerException = innerException.InnerException;
        }

        return pathBuilder.ToString();
    }

    /// <summary>Removes the root (<see cref="JsonRootChar"/>) from given JSON <paramref name="path"/>.</summary>
    /// <param name="path">Path to remove root from.</param>
    /// <param name="firstItem">Whether this is the first item.</param>
    /// <returns>Path without the root.</returns>
    private static string? RemoveRoot(string? path, bool firstItem)
    {
        if (path == null)
            return null;
        
        if (firstItem && path.StartsWith($"{JsonRootChar}."))
            return path.Remove(0, 2);

        if (path.StartsWith(JsonRootChar))
            return path.Remove(0, 1);

        return path;
    }
}