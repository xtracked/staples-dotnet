// Copyright 2025 Xtracked
// SPDX-License-Identifier: Apache-2.0

using FluentAssertions;
using Xtracked.Staples.ValueHolders.Extensions;
using Xunit;

namespace Xtracked.Staples.ValueHolders.UnitTests.Extensions;

public class TimestampedValueHolderExtensionsTests
{
    [Fact]
    public void Latest_ShouldReturnSelf_WhenOtherNull()
    {
        /* Arrange */
        var self = new TimestampedValueHolder<int>(0);
        TimestampedValueHolder<int>? other = null;

        /* Act */
        var result = self.Latest(other);

        /* Assert */
        result.Should().Be(self);
    }
    
    [Fact]
    public void Latest_ShouldReturnSelf_WhenOtherOlder()
    {
        /* Arrange */
        var self = new TimestampedValueHolder<int>(0);
        var other = new TimestampedValueHolder<int>(0) { Timestamp = DateTime.MinValue };

        /* Act */
        var result = self.Latest(other);

        /* Assert */
        result.Should().Be(self);
    }
    
    [Fact]
    public void Latest_ShouldReturnOther_WhenOtherNewer()
    {
        /* Arrange */
        var self = new TimestampedValueHolder<int>(0) { Timestamp = DateTime.MinValue };
        var other = new TimestampedValueHolder<int>(0);

        /* Act */
        var result = self.Latest(other);

        /* Assert */
        result.Should().Be(other);
    }
    
    [Fact]
    public void Latest_ShouldReturnSelf_WhenOtherSameTimestamp()
    {
        /* Arrange */
        var timestamp = DateTime.Now;
        var self = new TimestampedValueHolder<int>(0) { Timestamp = timestamp };
        var other = new TimestampedValueHolder<int>(0) { Timestamp = timestamp };

        /* Act */
        var result = self.Latest(other);

        /* Assert */
        result.Should().Be(self);
    }
}