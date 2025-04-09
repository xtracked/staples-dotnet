// Copyright 2025 Xtracked
// SPDX-License-Identifier: Apache-2.0

namespace Xtracked.Staples.ValueHolders.Json;

/// <summary>Extensions related to <see cref="TimestampedValueHolder{T}"/>.</summary>
internal static class TypeExtensions
{
    /// <summary>Find the <paramref name="generic"/> type for <paramref name="type"/> or null if not found.</summary>
    /// <param name="type">Type to search from.</param>
    /// <param name="generic">Type of the generic to search for.</param>
    /// <returns>The generic type or null if not found.</returns>
    /// <remarks>
    /// This should probably be in Staples.System, but that would require dependency on that project, so we'll keep the
    /// implementation here instead and make it internal.
    /// </remarks>
    internal static Type? FindGenericType(this Type type, Type generic)
    {
        var currentType = type;
        while (currentType != null && currentType != typeof(object))
        {
            if (currentType.IsGenericType && currentType.GetGenericTypeDefinition() == generic)
                return currentType;

            // If 'generic' is an interface, check the interfaces of 'type'
            if (generic.IsInterface)
            {
                foreach (var interfaceType in currentType.GetInterfaces())
                {
                    var found = FindGenericType(interfaceType, generic);
                    if (found != null)
                        return found;
                }
            }

            currentType = currentType.BaseType;
        }

        return null;
    }
}