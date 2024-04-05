// Copyright 2024 Xtracked
// SPDX-License-Identifier: Apache-2.0

using FluentAssertions;
using Xtracked.Staples.System.Extensions;
using Xunit;

namespace Xtracked.Staples.System.UnitTests.Extensions;

public class ComparableExtensionsTests
{
    [Fact]
    public void CoerceAtLeast_ShouldReturnSource_WhenGreaterThanMinimum()
    {
        /* Arrange */
        const int source = 15;
        const int minimumValue = 10;

        /* Act */
        var actual = source.CoerceAtLeast(minimumValue);

        /* Assert */
        actual.Should().Be(source);
    }
    
    [Fact]
    public void CoerceAtLeast_ShouldReturnMinimum_WhenLessThanMinimum()
    {
        /* Arrange */
        const int source = 5;
        const int minimumValue = 10;

        /* Act */
        var actual = source.CoerceAtLeast(minimumValue);

        /* Assert */
        actual.Should().Be(minimumValue);
    }
    
    [Fact]
    public void CoerceAtMost_ShouldReturnSource_WhenLessThanMaximum()
    {
        /* Arrange */
        const int source = 15;
        const int maximumValue = 20;

        /* Act */
        var actual = source.CoerceAtMost(maximumValue);

        /* Assert */
        actual.Should().Be(source);
    }
    
    [Fact]
    public void CoerceAtMost_ShouldReturnMaximum_WhenGreaterThanMaximum()
    {
        /* Arrange */
        const int source = 25;
        const int maximumValue = 20;

        /* Act */
        var actual = source.CoerceAtMost(maximumValue);

        /* Assert */
        actual.Should().Be(maximumValue);
    }
    
    [Fact]
    public void CoerceIn_ShouldReturnSource_WhenGreaterThanMinimumAndLessThanMaximum()
    {
        /* Arrange */
        const int source = 15;
        const int minimumValue = 10;
        const int maximumValue = 20;

        /* Act */
        var actual = source.CoerceIn(minimumValue, maximumValue);

        /* Assert */
        actual.Should().Be(source);
    }
    
    [Fact]
    public void CoerceIn_ShouldReturnMinimum_WhenLessThanMinimum()
    {
        /* Arrange */
        const int source = 5;
        const int minimumValue = 10;
        const int maximumValue = 20;

        /* Act */
        var actual = source.CoerceIn(minimumValue, maximumValue);

        /* Assert */
        actual.Should().Be(minimumValue);
    }
    
    [Fact]
    public void CoerceIn_ShouldReturnMaximum_WhenGreaterThanMaximum()
    {
        /* Arrange */
        const int source = 25;
        const int minimumValue = 10;
        const int maximumValue = 20;

        /* Act */
        var actual = source.CoerceIn(minimumValue, maximumValue);

        /* Assert */
        actual.Should().Be(maximumValue);
    }
}