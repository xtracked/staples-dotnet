// Copyright 2025 Xtracked
// SPDX-License-Identifier: Apache-2.0

using FluentAssertions;
using Xtracked.Staples.System.Extensions;
using Xunit;

namespace Xtracked.Staples.System.UnitTests.Extensions;

public class StringBooleanExtensionsTests
{
    [Fact]
    public void ToBool_ShouldReturnTrue_WhenStringIsTrue()
    {
        /* Arrange */
        const string value = "true";
        
        /* Act */
        var actual = value.ToBool();

        /* Assert */
        actual.Should().BeTrue();
    }
    
    [Fact]
    public void ToBool_ShouldReturnFalse_WhenStringIsFalse()
    {
        /* Arrange */
        const string value = "false";
        
        /* Act */
        var actual = value.ToBool();

        /* Assert */
        actual.Should().BeFalse();
    }
    
    [Fact]
    public void ToBool_ShouldThrowFormatException_WhenStringIsEmpty()
    {
        /* Arrange */
        const string value = "";
        
        /* Act */
        var action = value.Invoking(it => it.ToBool());

        /* Assert */
        action.Should().Throw<FormatException>();
    }
    
    [Fact]
    public void ToBool_ShouldThrowFormatException_WhenStringIsInvalid()
    {
        /* Arrange */
        const string value = "invalid";
        
        /* Act */
        var action = value.Invoking(it => it.ToBool());

        /* Assert */
        action.Should().Throw<FormatException>();
    }
    
    [Fact]
    public void ToBoolOrNull_ShouldReturnTrue_WhenStringIsTrue()
    {
        /* Arrange */
        const string value = "true";
        
        /* Act */
        var actual = value.ToBoolOrNull();

        /* Assert */
        actual.Should().BeTrue();
    }
    
    [Fact]
    public void ToBoolOrNull_ShouldReturnFalse_WhenStringIsFalse()
    {
        /* Arrange */
        const string value = "false";
        
        /* Act */
        var actual = value.ToBoolOrNull();

        /* Assert */
        actual.Should().BeFalse();
    }
    
    [Fact]
    public void ToBoolOrNull_ShouldReturnNull_WhenStringIsEmpty()
    {
        /* Arrange */
        const string value = "";
        
        /* Act */
        var actual = value.ToBoolOrNull();

        /* Assert */
        actual.Should().BeNull();
    }
    
    [Fact]
    public void ToBoolOrNull_ShouldReturnNull_WhenStringIsInvalid()
    {
        /* Arrange */
        const string value = "invalid";
        
        /* Act */
        var actual = value.ToBoolOrNull();

        /* Assert */
        actual.Should().BeNull();
    }
}