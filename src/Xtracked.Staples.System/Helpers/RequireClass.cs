// Copyright 2025 Xtracked
// SPDX-License-Identifier: Apache-2.0

namespace Xtracked.Staples.System.Helpers;

/// <summary>
/// Simple class that should never be constructed. It is simply used as a workaround for not being able to define the
/// same method name for a method that may return <c>null</c> for both <c>class</c> and <c>struct</c>.
///
/// See <a href="http://code.fitness/post/2016/04/generic-type-resolution.html">Generic Type Resolution</a>.
/// </summary>
/// <typeparam name="T">Type of class.</typeparam>
public abstract class RequireClass<T> where T : class?
{
    /// <summary>Private constructor, can never create this.</summary>
    private RequireClass()
    {
    }
}