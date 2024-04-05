// Copyright 2024 Xtracked
// SPDX-License-Identifier: Apache-2.0

using FluentAssertions;
using Xtracked.Staples.System.Extensions;
using Xunit;

namespace Xtracked.Staples.System.UnitTests.Extensions;

public class ObjectTaskExtensionsTests
{
    [Fact]
    public void ToTask_ShouldReturnSourceInTask()
    {
        /* Arrange */
        var source = new object();
        
        /* Act */
        var actual = source.ToTask();

        /* Assert */
        actual.Should().BeOfType<Task<object>>();
#pragma warning disable xUnit1031
        actual.Result.Should().BeSameAs(source);
#pragma warning restore xUnit1031
    }
}