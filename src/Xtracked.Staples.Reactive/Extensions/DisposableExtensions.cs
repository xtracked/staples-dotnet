// Copyright 2024 Xtracked
// SPDX-License-Identifier: Apache-2.0

using System.Reactive.Disposables;

namespace Xtracked.Staples.Reactive.Extensions;

/// <summary>Extensions for <see cref="IDisposable"/>.</summary>
public static class DisposableExtensions
{
    /// <summary>
    /// Adds <paramref name="disposable"/> to <paramref name="disposables"/> so it is disposed when
    /// <paramref name="disposables"/> is disposed.
    /// </summary>
    /// <param name="disposable">Disposable to dispose.</param>
    /// <param name="disposables">Composite disposables to add disposable to.</param>
    /// <returns>The <paramref name="disposable"/>.</returns>
    public static T DisposeWith<T>(this T disposable, CompositeDisposable disposables) where T : IDisposable
    {
        disposables.Add(disposable);
        return disposable;
    }
}