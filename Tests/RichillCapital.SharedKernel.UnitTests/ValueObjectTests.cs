using FluentAssertions;

using RichillCapital.SharedKernel.UnitTests.Common;

namespace RichillCapital.SharedKernel.UnitTests;

public sealed class ValueObjectTests
{
    private static readonly TestValueObject ValueObject = new("1", 1);
    private static readonly TestValueObject ValueObjectWithSameValues = new("1", 1);
    private static readonly TestValueObject ValueObjectWithDifferentString = new("2", 1);
    private static readonly TestValueObject ValueObjectWithDifferentInt = new("1", 2);

    [Fact]
    public void Equals_When_HasSameValues_Should_ReturnsTrue()
    {
        // Arrange & Act & Assert
        ValueObject.Equals(ValueObjectWithSameValues).Should().BeTrue();
    }

    [Fact]
    public void Equals_When_HasAnyDifferentValue_Should_ReturnsFalse()
    {
        // Arrange & Act & Assert
        ValueObject.Equals(ValueObjectWithDifferentString).Should().BeFalse();
        ValueObject.Equals(ValueObjectWithDifferentInt).Should().BeFalse();
    }

    [Fact]
    public void Equals_When_ComparingWithNull_Should_ReturnsFalse()
    {
        // Arrange & Act & Assert
        ValueObject.Equals(null).Should().BeFalse();
    }

    [Fact]
    public void Equals_When_ComparingWithDifferentType_Should_ReturnsFalse()
    {
        // Arrange & Act & Assert
        ValueObject.Equals(new object()).Should().BeFalse();
    }

    [Fact]
    public void GetHashCode_When_HasSameValues_Should_ReturnsSameHashCode()
    {
        // Arrange & Act & Assert
        ValueObject.GetHashCode()
            .Should().Be(ValueObjectWithSameValues.GetHashCode());
    }

    [Fact]
    public void GetHashCode_When_HasDifferentValues_Should_ReturnsDifferentHashCode()
    {
        // Arrange & Act & Assert
        ValueObject.GetHashCode()
            .Should().NotBe(ValueObjectWithDifferentString.GetHashCode());
        ValueObject.GetHashCode()
            .Should().NotBe(ValueObjectWithDifferentInt.GetHashCode());
    }

    [Fact]
    public void EqualsOperator_When_HasSameValues_Should_ReturnsTrue()
    {
        // Arrange & Act & Assert
        (ValueObject == ValueObjectWithSameValues).Should().BeTrue();
    }

    [Fact]
    public void EqualsOperator_When_HasAnyDifferentValue_Should_ReturnsFalse()
    {
        // Arrange & Act & Assert
        (ValueObject == ValueObjectWithDifferentString).Should().BeFalse();
        (ValueObject == ValueObjectWithDifferentInt).Should().BeFalse();
    }

    [Fact]
    public void NotEqualsOperator_When_HasSameValues_Should_ReturnsFalse()
    {
        // Arrange & Act & Assert
        (ValueObject != ValueObjectWithSameValues).Should().BeFalse();
    }

    [Fact]
    public void NotEqualsOperator_When_HasAnyDifferentValue_Should_ReturnsTrue()
    {
        // Arrange & Act & Assert
        (ValueObject != ValueObjectWithDifferentString).Should().BeTrue();
        (ValueObject != ValueObjectWithDifferentInt).Should().BeTrue();
    }
}