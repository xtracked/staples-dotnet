// Copyright 2024 Xtracked
// SPDX-License-Identifier: Apache-2.0

using FluentAssertions;
using Xtracked.Staples.System.Extensions;
using Xunit;

namespace Xtracked.Staples.System.UnitTests.Extensions;

public class DictionaryExtensionsTests
{
    [Fact]
    public void GetValueOrDefault_ShouldReturnDefault_WhenValueNotInDictionary()
    {
        /* Arrange */
        const int expected = default;
        IDictionary<string, int> dict = new Dictionary<string, int>();

        /* Act */
        var actual = dict.GetValueOrDefault("0");

        /* Assert */
        actual.Should().Be(expected);
    }
    
    [Fact]
    public void GetValueOrDefault_ShouldReturnValue_WhenValueInDictionary()
    {
        /* Arrange */
        const int expected = 1;
        IDictionary<string, int> dict = new Dictionary<string, int> { ["1"] = 1 };
        
        /* Act */
        var actual = dict.GetValueOrDefault("1");

        /* Assert */
        actual.Should().Be(expected);
    }
    
    [Fact]
    public void GetValueOrDefault_ShouldReturnGivenDefault_WhenValueNotInDictionary()
    {
        /* Arrange */
        const int expected = 1;
        IDictionary<string, int> dict = new Dictionary<string, int>();
        
        /* Act */
        var actual = dict.GetValueOrDefault("1", expected);

        /* Assert */
        actual.Should().Be(expected);
    }
}