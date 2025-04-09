// Copyright 2025 Xtracked
// SPDX-License-Identifier: Apache-2.0

using FluentAssertions;
using Xtracked.Staples.System.Extensions;
using Xunit;

namespace Xtracked.Staples.System.UnitTests.Extensions;

public class StringExtensionsTests
{
    #region IsEmpty
    [Fact]
    public void IsEmpty_ShouldReturnTrue_WhenStringIsEmpty()
    {
        /* Arrange */
        const string value = "";

        /* Act */
        var actual = value.IsEmpty();

        /* Assert */
        actual.Should().BeTrue();
    }
    
    [Fact]
    public void IsEmpty_ShouldReturnFalse_WhenStringIsNotEmpty()
    {
        /* Arrange */
        const string value = "aaa";

        /* Act */
        var actual = value.IsEmpty();

        /* Assert */
        actual.Should().BeFalse();
    }
    
    [Fact]
    public void IsEmpty_ShouldReturnFalse_WhenStringIsWhitespaces()
    {
        /* Arrange */
        const string value = "   ";

        /* Act */
        var actual = value.IsEmpty();

        /* Assert */
        actual.Should().BeFalse();
    }
    #endregion

    #region IsNotEmpty
    [Fact]
    public void IsNotEmpty_ShouldReturnFalse_WhenStringIsEmpty()
    {
        /* Arrange */
        const string value = "";

        /* Act */
        var actual = value.IsNotEmpty();

        /* Assert */
        actual.Should().BeFalse();
    }
    
    [Fact]
    public void IsNotEmpty_ShouldReturnTrue_WhenStringIsNotEmpty()
    {
        /* Arrange */
        const string value = "aaa";

        /* Act */
        var actual = value.IsNotEmpty();

        /* Assert */
        actual.Should().BeTrue();
    }
    
    [Fact]
    public void IsNotEmpty_ShouldReturnTrue_WhenStringIsWhitespaces()
    {
        /* Arrange */
        const string value = "   ";

        /* Act */
        var actual = value.IsNotEmpty();

        /* Assert */
        actual.Should().BeTrue();
    }
    #endregion

    #region IsNullOrEmpty
    [Fact]
    public void IsNullOrEmpty_ShouldReturnTrue_WhenStringIsEmpty()
    {
        /* Arrange */
        const string value = "";

        /* Act */
        var actual = value.IsNullOrEmpty();

        /* Assert */
        actual.Should().BeTrue();
    }
    
    [Fact]
    public void IsNullOrEmpty_ShouldReturnFalse_WhenStringIsNotEmpty()
    {
        /* Arrange */
        const string value = "aaa";

        /* Act */
        var actual = value.IsNullOrEmpty();

        /* Assert */
        actual.Should().BeFalse();
    }
    
    [Fact]
    public void IsNullOrEmpty_ShouldReturnFalse_WhenStringIsWhitespaces()
    {
        /* Arrange */
        const string value = "   ";

        /* Act */
        var actual = value.IsNullOrEmpty();

        /* Assert */
        actual.Should().BeFalse();
    }
    
    [Fact]
    public void IsNullOrEmpty_ShouldReturnTrue_WhenStringIsNull()
    {
        /* Arrange */
        const string? value = null;

        /* Act */
        var actual = value.IsNullOrEmpty();

        /* Assert */
        actual.Should().BeTrue();
    }
    #endregion
    
    #region IsBlank
    [Fact]
    public void IsBlank_ShouldReturnTrue_WhenStringIsEmpty()
    {
        /* Arrange */
        const string value = "";

        /* Act */
        var actual = value.IsBlank();

        /* Assert */
        actual.Should().BeTrue();
    }
    
    [Fact]
    public void IsBlank_ShouldReturnFalse_WhenStringIsNotEmpty()
    {
        /* Arrange */
        const string value = "aaa";

        /* Act */
        var actual = value.IsBlank();

        /* Assert */
        actual.Should().BeFalse();
    }
    
    [Fact]
    public void IsBlank_ShouldReturnTrue_WhenStringIsWhitespaces()
    {
        /* Arrange */
        const string value = "   ";

        /* Act */
        var actual = value.IsBlank();

        /* Assert */
        actual.Should().BeTrue();
    }
    #endregion

    #region IsNotBlank
    [Fact]
    public void IsNotBlank_ShouldReturnFalse_WhenStringIsEmpty()
    {
        /* Arrange */
        const string value = "";

        /* Act */
        var actual = value.IsNotBlank();

        /* Assert */
        actual.Should().BeFalse();
    }
    
    [Fact]
    public void IsNotBlank_ShouldReturnTrue_WhenStringIsNotEmpty()
    {
        /* Arrange */
        const string value = "aaa";

        /* Act */
        var actual = value.IsNotBlank();

        /* Assert */
        actual.Should().BeTrue();
    }
    
    [Fact]
    public void IsNotBlank_ShouldReturnFalse_WhenStringIsWhitespaces()
    {
        /* Arrange */
        const string value = "   ";

        /* Act */
        var actual = value.IsNotBlank();

        /* Assert */
        actual.Should().BeFalse();
    }
    #endregion

    #region IsNullOrBlank
    [Fact]
    public void IsNullOrBlank_ShouldReturnTrue_WhenStringIsEmpty()
    {
        /* Arrange */
        const string value = "";

        /* Act */
        var actual = value.IsNullOrBlank();

        /* Assert */
        actual.Should().BeTrue();
    }
    
    [Fact]
    public void IsNullOrBlank_ShouldReturnFalse_WhenStringIsNotEmpty()
    {
        /* Arrange */
        const string value = "aaa";

        /* Act */
        var actual = value.IsNullOrBlank();

        /* Assert */
        actual.Should().BeFalse();
    }
    
    [Fact]
    public void IsNullOrBlank_ShouldReturnTrue_WhenStringIsWhitespaces()
    {
        /* Arrange */
        const string value = "   ";

        /* Act */
        var actual = value.IsNullOrBlank();

        /* Assert */
        actual.Should().BeTrue();
    }
    
    [Fact]
    public void IsNullOrBlank_ShouldReturnTrue_WhenStringIsNull()
    {
        /* Arrange */
        const string? value = null;

        /* Act */
        var actual = value.IsNullOrBlank();

        /* Assert */
        actual.Should().BeTrue();
    }
    #endregion
}