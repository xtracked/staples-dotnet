// Copyright 2024 Xtracked
// SPDX-License-Identifier: Apache-2.0

using Xtracked.Staples.System.Helpers;

namespace Xtracked.Staples.System.Extensions;

/// <summary>Extensions generic for all objects.</summary>
public static class ObjectExtensions
{
    /// <summary>
    /// Calls the specified <paramref name="block"/> for <paramref name="source"/> as its argument and returns its
    /// result.
    /// </summary>
    /// <param name="source">Source on which this is called.</param>
    /// <param name="block">Block that is executed for <paramref name="source"/>.</param>
    /// <typeparam name="TSource">Type of the source.</typeparam>
    /// <typeparam name="TResult">Type of the result.</typeparam>
    /// <returns>The result of <paramref name="block"/>.</returns>
    /// <remarks>
    /// Based on <a href="https://kotlinlang.org/api/latest/jvm/stdlib/kotlin/let.html">Kotlin's scope function</a>.
    /// </remarks>
    public static TResult Let<TSource, TResult>(this TSource source, Func<TSource, TResult> block) =>
        block(source);

    /// <summary>
    /// Calls the specified <paramref name="block"/> for <paramref name="source"/> as its argument and returns
    /// <paramref name="source"/>.
    /// </summary>
    /// <param name="source">Source on which this is called.</param>
    /// <param name="block">Block that is executed for <paramref name="source"/>.</param>
    /// <typeparam name="TSource">Type of the source.</typeparam>
    /// <returns>The <paramref name="source"/>.</returns>
    /// <remarks>
    /// Based on <a href="https://kotlinlang.org/api/latest/jvm/stdlib/kotlin/also.html">Kotlin's scope function</a>.
    /// </remarks>
    public static TSource Also<TSource>(this TSource source, Action<TSource> block)
    {
        block(source);
        return source;
    }

    /// <summary>
    /// Returns <paramref name="source"/> if it satisfies given <paramref name="predicate"/> or <c>null</c> if it
    /// doesn't.
    /// </summary>
    /// <param name="source">Source to check.</param>
    /// <param name="predicate">Predicate to check.</param>
    /// <param name="_">Ignored. Required for same method name for both <c>class</c> and <c>struct</c>.</param>
    /// <typeparam name="TSource">Type of the source.</typeparam>
    /// <returns>Source if it satisfies predicate.</returns>
    /// <remarks>
    /// Based on <a href="https://kotlinlang.org/api/latest/jvm/stdlib/kotlin/take-if.html">Kotlin's takeIf
    /// function</a>.
    /// </remarks>
    public static TSource? TakeIf<TSource>(
        this TSource source, 
        Func<TSource, bool> predicate,
        RequireClass<TSource>? _ = null
    ) where TSource : class => predicate(source) ? source : null;

    /// <summary>
    /// Returns <paramref name="source"/> if it satisfies given <paramref name="predicate"/> or <c>null</c> if it
    /// doesn't.
    /// </summary>
    /// <param name="source">Source to check.</param>
    /// <param name="predicate">Predicate to check.</param>
    /// <param name="_">Ignored. Required for same method name for both <c>class</c> and <c>struct</c>.</param>
    /// <typeparam name="TSource">Type of the source.</typeparam>
    /// <returns>Source if it satisfies predicate.</returns>
    /// <remarks>
    /// Based on <a href="https://kotlinlang.org/api/latest/jvm/stdlib/kotlin/take-if.html">Kotlin's takeIf
    /// function</a>.
    /// </remarks>
    public static TSource? TakeIf<TSource>(
        this TSource source, 
        Func<TSource, bool> predicate,
        RequireStruct<TSource>? _ = null
    ) where TSource : struct => predicate(source) ? source : null;

    /// <summary>
    /// Returns <paramref name="source"/> if it does not satisfy given <paramref name="predicate"/> or <c>null</c> if it
    /// does.
    /// </summary>
    /// <param name="source">Source to check.</param>
    /// <param name="predicate">Predicate to check.</param>
    /// <param name="_">Ignored. Required for same method name for both <c>class</c> and <c>struct</c>.</param>
    /// <typeparam name="TSource">Type of the source.</typeparam>
    /// <returns>Source if it does not satisfy predicate.</returns>
    /// <remarks>
    /// Based on <a href="https://kotlinlang.org/api/latest/jvm/stdlib/kotlin/take-unless.html">Kotlin's takeUnless
    /// function</a>.
    /// </remarks>
    public static TSource? TakeUnless<TSource>(
        this TSource source,
        Func<TSource, bool> predicate,
        RequireClass<TSource>? _ = null
    ) where TSource : class => !predicate(source) ? source : null;

    /// <summary>
    /// Returns <paramref name="source"/> if it does not satisfy given <paramref name="predicate"/> or <c>null</c> if it
    /// does.
    /// </summary>
    /// <param name="source">Source to check.</param>
    /// <param name="predicate">Predicate to check.</param>
    /// <param name="_">Ignored. Required for same method name for both <c>class</c> and <c>struct</c>.</param>
    /// <typeparam name="TSource">Type of the source.</typeparam>
    /// <returns>Source if it does not satisfy predicate.</returns>
    /// <remarks>
    /// Based on <a href="https://kotlinlang.org/api/latest/jvm/stdlib/kotlin/take-unless.html">Kotlin's takeUnless
    /// function</a>.
    /// </remarks>
    public static TSource? TakeUnless<TSource>(
        this TSource source, 
        Func<TSource, bool> predicate, 
        RequireStruct<TSource>? _ = null
    ) where TSource : struct => !predicate(source) ? source : null;
}