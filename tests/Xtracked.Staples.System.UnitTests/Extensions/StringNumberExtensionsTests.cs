// Copyright 2024 Xtracked
// SPDX-License-Identifier: Apache-2.0

using FluentAssertions;
using Xtracked.Staples.System.Extensions;
using Xunit;

namespace Xtracked.Staples.System.UnitTests.Extensions;

public class StringNumberExtensionsTests
{
    #region byte
    [Fact]
    public void ToByte_ShouldReturnByte_WhenStringIsByte()
    {
        /* Arrange */
        const byte expected = 0;
        const string value = "0";

        /* Act */
        var actual = value.ToByte();

        /* Assert */
        actual.Should().Be(expected);
    }
    
    [Fact]
    public void ToByte_ShouldThrowFormatException_WhenStringIsInvalid()
    {
        /* Arrange */
        const string value = "invalid";

        /* Act */
        var action = value.Invoking(it => it.ToByte());
            
        /* Assert */
        action.Should().Throw<FormatException>();
    }
    
    [Fact]
    public void ToByte_ShouldThrowOverflowException_WhenStringIsGreaterThanMaxByteValue()
    {
        /* Arrange */
        var value = $"{byte.MaxValue + 1}";

        /* Act */
        var action = value.Invoking(it => it.ToByte());
            
        /* Assert */
        action.Should().Throw<OverflowException>();
    }
    
    [Fact]
    public void ToByte_ShouldThrowOverflowException_WhenStringIsLessThanMinByteValue()
    {
        /* Arrange */
        var value = $"{byte.MinValue - 1}";

        /* Act */
        var action = value.Invoking(it => it.ToByte());
            
        /* Assert */
        action.Should().Throw<OverflowException>();
    }
    
    [Fact]
    public void ToByteOrNull_ShouldReturnByte_WhenStringIsByte()
    {
        /* Arrange */
        const byte expected = 0;
        const string value = "0";

        /* Act */
        var actual = value.ToByteOrNull();

        /* Assert */
        actual.Should().Be(expected);
    }
    
    [Fact]
    public void ToByteOrNull_ShouldReturnNull_WhenStringIsInvalid()
    {
        /* Arrange */
        const string value = "invalid";

        /* Act */
        var actual = value.ToByteOrNull();
            
        /* Assert */
        actual.Should().BeNull();
    }
    
    [Fact]
    public void ToByteOrNull_ShouldReturnNull_WhenStringIsGreaterThanMaxByteValue()
    {
        /* Arrange */
        var value = $"{byte.MaxValue + 1}";

        /* Act */
        var actual = value.ToByteOrNull();
            
        /* Assert */
        actual.Should().BeNull();
    }
    
    [Fact]
    public void ToByteOrNull_ShouldReturnNull_WhenStringIsLessThanMinByteValue()
    {
        /* Arrange */
        var value = $"{byte.MinValue - 1}";

        /* Act */
        var actual = value.ToByteOrNull();
            
        /* Assert */
        actual.Should().BeNull();
    }
    #endregion
    
    #region short
    [Fact]
    public void ToShort_ShouldReturnShort_WhenStringIsShort()
    {
        /* Arrange */
        const short expected = 0;
        const string value = "0";

        /* Act */
        var actual = value.ToShort();

        /* Assert */
        actual.Should().Be(expected);
    }
    
    [Fact]
    public void ToShort_ShouldThrowFormatException_WhenStringIsInvalid()
    {
        /* Arrange */
        const string value = "invalid";

        /* Act */
        var action = value.Invoking(it => it.ToShort());
            
        /* Assert */
        action.Should().Throw<FormatException>();
    }
    
    [Fact]
    public void ToShort_ShouldThrowFormatException_WhenStringIsGreaterThanMaxShortValue()
    {
        /* Arrange */
        var value = $"{short.MaxValue + 1}";

        /* Act */
        var action = value.Invoking(it => it.ToShort());
            
        /* Assert */
        action.Should().Throw<OverflowException>();
    }
    
    [Fact]
    public void ToShort_ShouldThrowFormatException_WhenStringIsLessThanMinShortValue()
    {
        /* Arrange */
        var value = $"{short.MinValue - 1}";

        /* Act */
        var action = value.Invoking(it => it.ToShort());
            
        /* Assert */
        action.Should().Throw<OverflowException>();
    }
    
    [Fact]
    public void ToShortOrNull_ShouldReturnShort_WhenStringIsShort()
    {
        /* Arrange */
        const short expected = 0;
        const string value = "0";

        /* Act */
        var actual = value.ToShortOrNull();

        /* Assert */
        actual.Should().Be(expected);
    }
    
    [Fact]
    public void ToShortOrNull_ShouldReturnNull_WhenStringIsInvalid()
    {
        /* Arrange */
        const string value = "invalid";

        /* Act */
        var actual = value.ToShortOrNull();
            
        /* Assert */
        actual.Should().BeNull();
    }
    
    [Fact]
    public void ToShortOrNull_ShouldReturnNull_WhenStringIsGreaterThanMaxShortValue()
    {
        /* Arrange */
        var value = $"{short.MaxValue + 1}";

        /* Act */
        var actual = value.ToShortOrNull();
            
        /* Assert */
        actual.Should().BeNull();
    }
    
    [Fact]
    public void ToShortOrNull_ShouldReturnNull_WhenStringIsLessThanMinShortValue()
    {
        /* Arrange */
        var value = $"{short.MinValue - 1}";

        /* Act */
        var actual = value.ToShortOrNull();
            
        /* Assert */
        actual.Should().BeNull();
    }
    #endregion
    
    #region ushort
    [Fact]
    public void ToUshort_ShouldReturnUshort_WhenStringIsUshort()
    {
        /* Arrange */
        const ushort expected = 0;
        const string value = "0";

        /* Act */
        var actual = value.ToUshort();

        /* Assert */
        actual.Should().Be(expected);
    }
    
    [Fact]
    public void ToUshort_ShouldThrowFormatException_WhenStringIsInvalid()
    {
        /* Arrange */
        const string value = "invalid";

        /* Act */
        var action = value.Invoking(it => it.ToUshort());
           
        /* Assert */ 
        action.Should().Throw<FormatException>();
    }
    
    [Fact]
    public void ToUshort_ShouldThrowFormatException_WhenStringIsGreaterThanMaxUshortValue()
    {
        /* Arrange */
        var value = $"{ushort.MaxValue + 1}";

        /* Act */
        var action = value.Invoking(it => it.ToUshort());
            
        /* Assert */
        action.Should().Throw<OverflowException>();
    }
    
    [Fact]
    public void ToUshort_ShouldThrowFormatException_WhenStringIsLessThanMinUshortValue()
    {
        /* Arrange */
        var value = $"{ushort.MinValue - 1}";

        /* Act */
        var action = value.Invoking(it => it.ToUshort());
            
        /* Assert */
        action.Should().Throw<OverflowException>();
    }
    
    [Fact]
    public void ToUshortOrNull_ShouldReturnUshort_WhenStringIsUshort()
    {
        /* Arrange */
        const ushort expected = 0;
        const string value = "0";

        /* Act */
        var actual = value.ToUshortOrNull();
            
        /* Assert */
        actual.Should().Be(expected);
    }
    
    [Fact]
    public void ToUshortOrNull_ShouldReturnNull_WhenStringIsInvalid()
    {
        /* Arrange */
        const string value = "invalid";

        /* Act */
        var actual = value.ToUshortOrNull();
            
        /* Assert */
        actual.Should().BeNull();
    }
    
    [Fact]
    public void ToUshortOrNull_ShouldReturnNull_WhenStringIsGreaterThanMaxUshortValue()
    {
        /* Arrange */
        var value = $"{ushort.MaxValue + 1}";

        /* Act */
        var actual = value.ToUshortOrNull();
            
        /* Assert */
        actual.Should().BeNull();
    }
    
    [Fact]
    public void ToUshortOrNull_ShouldReturnNull_WhenStringIsLessThanMinUshortValue()
    {
        /* Arrange */
        var value = $"{ushort.MinValue - 1}";

        /* Act */
        var actual = value.ToUshortOrNull();
            
        /* Assert */
        actual.Should().BeNull();
    }
    #endregion
    
    #region int
    [Fact]
    public void ToInt_ShouldReturnInt_WhenStringIsInt()
    {
        /* Arrange */
        const int expected = 0;
        const string value = "0";

        /* Act */
        var actual = value.ToInt();
            
        /* Assert */
        actual.Should().Be(expected);
    }
    
    [Fact]
    public void ToInt_ShouldThrowFormatException_WhenStringIsInvalid()
    {
        /* Arrange */
        const string value = "invalid";

        /* Act */
        var action = value.Invoking(it => it.ToInt());
            
        /* Assert */
        action.Should().Throw<FormatException>();
    }
    
    [Fact]
    public void ToInt_ShouldThrowFormatException_WhenStringIsGreaterThanMaxIntValue()
    {
        /* Arrange */
        var value = $"{int.MaxValue}0";

        /* Act */
        var action = value.Invoking(it => it.ToInt());
            
        /* Assert */
        action.Should().Throw<OverflowException>();
    }
    
    [Fact]
    public void ToInt_ShouldThrowFormatException_WhenStringIsLessThanMinIntValue()
    {
        /* Arrange */
        var value = $"{int.MinValue}0";

        /* Act */
        var action = value.Invoking(it => it.ToInt());
            
        /* Assert */
        action.Should().Throw<OverflowException>();
    }
    
    [Fact]
    public void ToIntOrNull_ShouldReturnInt_WhenStringIsInt()
    {
        /* Arrange */
        const int expected = 0;
        const string value = "0";

        /* Act */
        var actual = value.ToIntOrNull();
            
        /* Assert */
        actual.Should().Be(expected);
    }
    
    [Fact]
    public void ToIntOrNull_ShouldReturnNull_WhenStringIsInvalid()
    {
        /* Arrange */
        const string value = "invalid";

        /* Act */
        var actual = value.ToIntOrNull();
            
        /* Assert */
        actual.Should().BeNull();
    }
    
    [Fact]
    public void ToIntOrNull_ShouldReturnNull_WhenStringIsGreaterThanMaxIntValue()
    {
        /* Arrange */
        var value = $"{int.MaxValue}0";

        /* Act */
        var actual = value.ToIntOrNull();
            
        /* Assert */
        actual.Should().BeNull();
    }
    
    [Fact]
    public void ToIntOrNull_ShouldReturnNull_WhenStringIsLessThanMinIntValue()
    {
        /* Arrange */
        var value = $"{int.MinValue}0";

        /* Act */
        var actual = value.ToIntOrNull();
            
        /* Assert */
        actual.Should().BeNull();
    }
    #endregion
    
    #region uint
    [Fact]
    public void ToUint_ShouldReturnUint_WhenStringIsUint()
    {
        /* Arrange */
        const uint expected = 0;
        const string value = "0";

        /* Act */
        var actual = value.ToUint();
            
        /* Assert */
        actual.Should().Be(expected);
    }
    
    [Fact]
    public void ToUint_ShouldThrowFormatException_WhenStringIsInvalid()
    {
        /* Arrange */
        const string value = "invalid";

        /* Act */
        var action = value.Invoking(it => it.ToUint());
            
        /* Assert */
        action.Should().Throw<FormatException>();
    }
    
    [Fact]
    public void ToUint_ShouldThrowFormatException_WhenStringIsGreaterThanMaxUintValue()
    {
        /* Arrange */
        var value = $"{uint.MaxValue}0";

        /* Act */
        var action = value.Invoking(it => it.ToUint());
            
        /* Assert */
        action.Should().Throw<OverflowException>();
    }
    
    [Fact]
    public void ToUint_ShouldThrowFormatException_WhenStringIsLessThanMinUintValue()
    {
        /* Arrange */
        const string value = "-1";

        /* Act */
        var action = value.Invoking(it => it.ToUint());
            
        /* Assert */
        action.Should().Throw<OverflowException>();
    }
    
    [Fact]
    public void ToUintOrNull_ShouldReturnUint_WhenStringIsUint()
    {
        /* Arrange */
        const uint expected = 0;
        const string value = "0";

        /* Act */
        var actual = value.ToUintOrNull();
            
        /* Assert */
        actual.Should().Be(expected);
    }
    
    [Fact]
    public void ToUintOrNull_ShouldReturnNull_WhenStringIsInvalid()
    {
        /* Arrange */
        const string value = "invalid";

        /* Act */
        var actual = value.ToUintOrNull();
            
        /* Assert */
        actual.Should().BeNull();
    }
    
    [Fact]
    public void ToUintOrNull_ShouldReturnNull_WhenStringIsGreaterThanMaxUintValue()
    {
        /* Arrange */
        var value = $"{uint.MaxValue}0";

        /* Act */
        var actual = value.ToUintOrNull();
            
        /* Assert */
        actual.Should().BeNull();
    }
    
    [Fact]
    public void ToUintOrNull_ShouldReturnNull_WhenStringIsLessThanMinUintValue()
    {
        /* Arrange */
        const string value = "-1";

        /* Act */
        var actual = value.ToUintOrNull();
            
        /* Assert */
        actual.Should().BeNull();
    }
    #endregion
    
    #region long
    [Fact]
    public void ToLong_ShouldReturnLong_WhenStringIsLong()
    {
        /* Arrange */
        const long expected = 0;
        const string value = "0";

        /* Act */
        var actual = value.ToLong();
            
        /* Assert */
        actual.Should().Be(expected);
    }
    
    [Fact]
    public void ToLong_ShouldThrowFormatException_WhenStringIsInvalid()
    {
        /* Arrange */
        const string value = "invalid";

        /* Act */
        var action = value.Invoking(it => it.ToLong());
            
        /* Assert */
        action.Should().Throw<FormatException>();
    }
    
    [Fact]
    public void ToLong_ShouldThrowFormatException_WhenStringIsGreaterThanMaxLongValue()
    {
        /* Arrange */
        var value = $"{long.MaxValue}0";

        /* Act */
        var action = value.Invoking(it => it.ToLong());
            
        /* Assert */
        action.Should().Throw<OverflowException>();
    }
    
    [Fact]
    public void ToLong_ShouldThrowFormatException_WhenStringIsLessThanMinLongValue()
    {
        /* Arrange */
        var value = $"{long.MinValue}0";

        /* Act */
        var action = value.Invoking(it => it.ToLong());
            
        /* Assert */
        action.Should().Throw<OverflowException>();
    }
    
    [Fact]
    public void ToLongOrNull_ShouldReturnNull_WhenStringIsLong()
    {
        /* Arrange */
        const long expected = 0;
        const string value = "0";

        /* Act */
        var actual = value.ToLongOrNull();
            
        /* Assert */
        actual.Should().Be(expected);
    }
    
    [Fact]
    public void ToLongOrNull_ShouldReturnNull_WhenStringIsInvalid()
    {
        /* Arrange */
        const string value = "invalid";

        /* Act */
        var actual = value.ToLongOrNull();
            
        /* Assert */
        actual.Should().BeNull();
    }
    
    [Fact]
    public void ToLongOrNull_ShouldReturnNull_WhenStringIsGreaterThanMaxLongValue()
    {
        /* Arrange */
        var value = $"{long.MaxValue}0";

        /* Act */
        var actual = value.ToLongOrNull();
            
        /* Assert */
        actual.Should().BeNull();
    }
    
    [Fact]
    public void ToLongOrNull_ShouldReturnNull_WhenStringIsLessThanMinLongValue()
    {
        /* Arrange */
        var value = $"{long.MinValue}0";

        /* Act */
        var actual = value.ToLongOrNull();
            
        /* Assert */
        actual.Should().BeNull();
    }
    #endregion
    
    #region ulong
    [Fact]
    public void ToUlong_ShouldReturnUlong_WhenStringIsUlong()
    {
        /* Arrange */
        const ulong expected = 0;
        const string value = "0";

        /* Act */
        var actual = value.ToUlong();
            
        /* Assert */
        actual.Should().Be(expected);
    }
    
    [Fact]
    public void ToUlong_ShouldThrowFormatException_WhenStringIsInvalid()
    {
        /* Arrange */
        const string value = "invalid";

        /* Act */
        var action = value.Invoking(it => it.ToUlong());
            
        /* Assert */
        action.Should().Throw<FormatException>();
    }
    
    [Fact]
    public void ToUlong_ShouldThrowFormatException_WhenStringIsGreaterThanMaxUlongValue()
    {
        /* Arrange */
        var value = $"{ulong.MaxValue}0";

        /* Act */
        var action = value.Invoking(it => it.ToUlong());
            
        /* Assert */
        action.Should().Throw<OverflowException>();
    }
    
    [Fact]
    public void ToUlong_ShouldThrowFormatException_WhenStringIsLessThanMinUlongValue()
    {
        /* Arrange */
        const string value = "-1";

        /* Act */
        var action = value.Invoking(it => it.ToUlong());
            
        /* Assert */
        action.Should().Throw<OverflowException>();
    }
    
    [Fact]
    public void ToUlongOrNull_ShouldReturnUlong_WhenStringIsUlong()
    {
        /* Arrange */
        const ulong expected = 0;
        const string value = "0";

        /* Act */
        var actual = value.ToUlongOrNull();
            
        /* Assert */
        actual.Should().Be(expected);
    }
    
    [Fact]
    public void ToUlongOrNull_ShouldReturnNull_WhenStringIsInvalid()
    {
        /* Arrange */
        const string value = "invalid";

        /* Act */
        var actual = value.ToUlongOrNull();
            
        /* Assert */
        actual.Should().BeNull();
    }
    
    [Fact]
    public void ToUlongOrNull_ShouldReturnNull_WhenStringIsGreaterThanMaxUlongValue()
    {
        /* Arrange */
        var value = $"{ulong.MaxValue}0";

        /* Act */
        var actual = value.ToUlongOrNull();
            
        /* Assert */
        actual.Should().BeNull();
    }
    
    [Fact]
    public void ToUlongOrNull_ShouldReturnNull_WhenStringIsLessThanMinUlongValue()
    {
        /* Arrange */
        const string value = "-1";

        /* Act */
        var actual = value.ToUlongOrNull();
            
        /* Assert */
        actual.Should().BeNull();
    }
    #endregion
    
    #region decimal
    [Fact]
    public void ToDecimal_ShouldReturnDecimal_WhenStringIsDecimal()
    {
        /* Arrange */
        const decimal expected = 0;
        const string value = "0.0";

        /* Act */
        var actual = value.ToDecimal();
            
        /* Assert */
        actual.Should().Be(expected);
    }
    
    [Fact]
    public void ToDecimal_ShouldThrowFormatException_WhenStringIsInvalid()
    {
        /* Arrange */
        const string value = "invalid";

        /* Act */
        var action = value.Invoking(it => it.ToDecimal());
            
        /* Assert */
        action.Should().Throw<FormatException>();
    }
    
    [Fact]
    public void ToDecimal_ShouldThrowFormatException_WhenStringIsGreaterThanMaxDecimalValue()
    {
        /* Arrange */
        var value = $"{decimal.MaxValue}0";

        /* Act */
        var action = value.Invoking(it => it.ToDecimal());
            
        /* Assert */
        action.Should().Throw<OverflowException>();
    }
    
    [Fact]
    public void ToDecimal_ShouldThrowFormatException_WhenStringIsLessThanMinDecimalValue()
    {
        /* Arrange */
        var value = $"{decimal.MinValue}0";

        /* Act */
        var action = value.Invoking(it => it.ToDecimal());
            
        /* Assert */
        action.Should().Throw<OverflowException>();
    }
    
    [Fact]
    public void ToDecimalOrNull_ShouldReturnDecimal_WhenStringIsDecimal()
    {
        /* Arrange */
        const decimal expected = 0;
        const string value = "0";

        /* Act */
        var actual = value.ToDecimalOrNull();
            
        /* Assert */
        actual.Should().Be(expected);
    }
    
    [Fact]
    public void ToDecimalOrNull_ShouldReturnNull_WhenStringIsInvalid()
    {
        /* Arrange */
        const string value = "invalid";

        /* Act */
        var actual = value.ToDecimalOrNull();
            
        /* Assert */
        actual.Should().BeNull();
    }
    
    [Fact]
    public void ToDecimalOrNull_ShouldReturnNull_WhenStringIsGreaterThanMaxDecimalValue()
    {
        /* Arrange */
        var value = $"{decimal.MaxValue}0";

        /* Act */
        var actual = value.ToDecimalOrNull();
            
        /* Assert */
        actual.Should().BeNull();
    }
    
    [Fact]
    public void ToDecimalOrNull_ShouldReturnNull_WhenStringIsLessThanMinDecimalValue()
    {
        /* Arrange */
        var value = $"{decimal.MinValue}0";

        /* Act */
        var actual = value.ToDecimalOrNull();
            
        /* Assert */
        actual.Should().BeNull();
    }
    #endregion
    
    #region double
    [Fact]
    public void ToDouble_ShouldReturnDouble_WhenStringIsDouble()
    {
        /* Arrange */
        const double expected = 0;
        const string value = "0.0";

        /* Act */
        var actual = value.ToDouble();
            
        /* Assert */
        actual.Should().Be(expected);
    }
    
    [Fact]
    public void ToDouble_ShouldThrowFormatException_WhenStringIsInvalid()
    {
        /* Arrange */
        const string value = "invalid";

        /* Act */
        var action = value.Invoking(it => it.ToDouble());
            
        /* Assert */
        action.Should().Throw<FormatException>();
    }
    
    // 'double' is odd in that parsing greater than double.MaxValue gives us double.PositiveInfinity
    [Fact]
    public void ToDouble_ShouldReturnDoublePositiveInfinity_WhenStringIsGreaterThanMaxDoubleValue()
    {
        /* Arrange */
        var value = $"{double.MaxValue}0";

        /* Act */
        var actual = value.ToDouble();
            
        /* Assert */
        actual.Should().Be(double.PositiveInfinity);
    }
    
    // 'double' is odd in that parsing less than double.MinValue gives us double.NegativeInfinity
    [Fact]
    public void ToDouble_ShouldReturnDoubleNegativeInfinity_WhenStringIsLessThanMinDoubleValue()
    {
        /* Arrange */
        var value = $"{double.MinValue}0";

        /* Act */
        var actual = value.ToDouble();
            
        /* Assert */
        actual.Should().Be(double.NegativeInfinity);
    }
    
    [Fact]
    public void ToDoubleOrNull_ShouldReturnDouble_WhenStringIsDouble()
    {
        /* Arrange */
        const double expected = 0;
        const string value = "0";

        /* Act */
        var actual = value.ToDoubleOrNull();
            
        /* Assert */
        actual.Should().Be(expected);
    }
    
    [Fact]
    public void ToDoubleOrNull_ShouldReturnNull_WhenStringIsInvalid()
    {
        /* Arrange */
        const string value = "invalid";

        /* Act */
        var actual = value.ToDoubleOrNull();
            
        /* Assert */
        actual.Should().BeNull();
    }
    
    // 'double' is odd in that parsing greater than double.MaxValue gives us double.PositiveInfinity
    [Fact]
    public void ToDoubleOrNull_ShouldReturnDoublePositiveInfinity_WhenStringIsGreaterThanMaxDoubleValue()
    {
        /* Arrange */
        var value = $"{double.MaxValue}0";

        /* Act */
        var actual = value.ToDoubleOrNull();
            
        /* Assert */
        actual.Should().Be(double.PositiveInfinity);
    }
    
    // 'double' is odd in that parsing less than double.MinValue gives us double.NegativeInfinity
    [Fact]
    public void ToDoubleOrNull_ShouldReturnDoubleNegativeInfinity_WhenStringIsLessThanMinDoubleValue()
    {
        /* Arrange */
        var value = $"{double.MinValue}0";

        /* Act */
        var actual = value.ToDoubleOrNull();
            
        /* Assert */
        actual.Should().Be(double.NegativeInfinity);
    }
    #endregion
}