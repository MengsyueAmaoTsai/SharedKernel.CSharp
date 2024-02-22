using FluentAssertions;

using RichillCapital.SharedKernel.UnitTests.Common;

namespace RichillCapital.SharedKernel.UnitTests;

public sealed class ValueObjectTests
{
    [Fact]
    public void EqualsOperator_WithSameValues_ReturnsTrue()
    {
        // Arrange
        var valueObject1 = new TestValueObject("test", 1);
        var valueObject2 = new TestValueObject("test", 1);

        // Act
        var areEqual = valueObject1 == valueObject2;

        // Assert
        areEqual.Should().BeTrue();
    }

    [Fact]
    public void EqualsOperator_WithDifferentValues_ReturnsFalse()
    {
        // Arrange
        var valueObject1 = new TestValueObject("test", 1);
        var valueObject2 = new TestValueObject("test", 2);

        // Act
        var areEqual = valueObject1 == valueObject2;

        // Assert
        areEqual.Should().BeFalse();
    }

    [Fact]
    public void NotEqualsOperator_WithSameValues_ReturnsFalse()
    {
        // Arrange
        var valueObject1 = new TestValueObject("test", 1);
        var valueObject2 = new TestValueObject("test", 1);

        // Act
        var areNotEqual = valueObject1 != valueObject2;

        // Assert
        areNotEqual.Should().BeFalse();
    }

    [Fact]
    public void NotEqualsOperator_WithDifferentValues_ReturnsTrue()
    {
        // Arrange
        var valueObject1 = new TestValueObject("test", 1);
        var valueObject2 = new TestValueObject("test", 2);

        // Act
        var areNotEqual = valueObject1 != valueObject2;

        // Assert
        areNotEqual.Should().BeTrue();
    }

    [Fact]
    public void ValueObjects_WithSameValues_AreEqual()
    {
        // Arrange
        var valueObject1 = new TestValueObject("test", 1);
        var valueObject2 = new TestValueObject("test", 1);

        // Act
        var areEqual = valueObject1.Equals(valueObject2);

        // Assert
        areEqual.Should().BeTrue();
    }

    [Fact]
    public void ValueObjects_WithDifferentValues_AreNotEqual()
    {
        // Arrange
        var valueObject1 = new TestValueObject("test", 1);
        var valueObject2 = new TestValueObject("test", 2);

        // Act
        var areEqual = valueObject1.Equals(valueObject2);

        // Assert
        areEqual.Should().BeFalse();
    }

    [Fact]
    public void ValueObjects_WithSameValues_HaveSameHashCode()
    {
        // Arrange
        var valueObject1 = new TestValueObject("test", 1);
        var valueObject2 = new TestValueObject("test", 1);

        // Act
        var hashCode1 = valueObject1.GetHashCode();
        var hashCode2 = valueObject2.GetHashCode();

        // Assert
        hashCode1.Should().Be(hashCode2);
    }

    [Fact]
    public void ValueObjects_WithDifferentValues_HaveDifferentHashCode()
    {
        // Arrange
        var valueObject1 = new TestValueObject("test", 1);
        var valueObject2 = new TestValueObject("test", 2);

        // Act
        var hashCode1 = valueObject1.GetHashCode();
        var hashCode2 = valueObject2.GetHashCode();

        // Assert
        hashCode1.Should().NotBe(hashCode2);
    }
}