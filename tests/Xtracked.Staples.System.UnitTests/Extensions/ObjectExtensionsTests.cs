// Copyright 2025 Xtracked
// SPDX-License-Identifier: Apache-2.0

using FluentAssertions;
using Xtracked.Staples.System.Extensions;
using Xunit;

namespace Xtracked.Staples.System.UnitTests.Extensions;

public class ObjectExtensionsTests
{
    [Fact]
    public void Let_ShouldReturnResult()
    {
        /* Arrange */
        const bool expected = false;
        var source = new object();

        /* Act */
        var actual = source.Let(_ => expected);

        /* Assert */
        actual.Should().Be(expected);
    }
    
    [Fact]
    public void Also_ShouldReturnSource()
    {
        /* Arrange */
        var source = new object();
        
        /* Act */
        var actual = source.Also(_ => { });

        /* Assert */
        actual.Should().BeSameAs(source);
    }
    
    [Fact]
    public void TakeIf_ShouldReturnSource_WhenPredicateTrue()
    {
        /* Arrange */
        var source = new object();
        
        /* Act */
        var actual = source.TakeIf(_ => true);

        /* Assert */
        actual.Should().BeSameAs(source);
    }
    
    [Fact]
    public void TakeIf_ShouldReturnNull_WhenPredicateFalse()
    {
        /* Arrange */
        var source = new object();
        
        /* Act */
        var actual = source.TakeIf(_ => false);

        /* Assert */
        actual.Should().BeNull();
    }
    
    [Fact]
    public void TakeUnless_ShouldReturnNull_WhenPredicateTrue()
    {
        /* Arrange */
        var source = new object();
        
        /* Act */
        var actual = source.TakeUnless(_ => true);

        /* Assert */
        actual.Should().BeNull();
    }
    
    [Fact]
    public void TakeUnless_ShouldReturnSource_WhenPredicateFalse()
    {
        /* Arrange */
        var source = new object();
        
        /* Act */
        var actual = source.TakeUnless(_ => false);

        /* Assert */
        actual.Should().BeSameAs(source);
    }
}