// Copyright 2024 Xtracked
// SPDX-License-Identifier: Apache-2.0

using System.Reactive.Disposables;
using FluentAssertions;
using Moq;
using Xtracked.Staples.Reactive.Extensions;
using Xunit;

namespace Xtracked.Staples.Reactive.UnitTests.Extensions;

public class DisposableExtensionsTests
{
    [Fact]
    public void DisposeWith_ShouldDisposeSource_WhenCompositeDisposableDisposed()
    {
        /* Arrange */
        var source = new Mock<IDisposable>();
        var disposables = new CompositeDisposable();
        source.Object.DisposeWith(disposables);

        /* Act */
        disposables.Dispose();

        /* Assert */
        source.Verify(it => it.Dispose());
    }
    
    [Fact]
    public void DisposeWith_ShouldReturnSource()
    {
        /* Arrange */
        var source = new Mock<IDisposable>().Object;
        var disposables = new CompositeDisposable();

        /* Act */
        var actual = source.DisposeWith(disposables);

        /* Assert */
        actual.Should().Be(source);
    }
}