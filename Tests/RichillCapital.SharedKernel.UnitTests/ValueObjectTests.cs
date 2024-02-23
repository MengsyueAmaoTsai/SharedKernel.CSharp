using FluentAssertions;

namespace RichillCapital.SharedKernel.UnitTests;

public sealed class ValueObjectTests
{
    private sealed class TestValueObject : ValueObject
    {
        public TestValueObject(string stringValue, int intValue) =>
            (StringValue, IntValue) = (stringValue, intValue);

        public string StringValue { get; private init; }

        public int IntValue { get; private init; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return StringValue;
            yield return IntValue;
        }
    }

    [Fact]
    public void Equals_When_ValueObjectsHaveTheSameValues_Should_ReturnTrue()
    {
        // Arrange
        var valueObject1 = new TestValueObject("string", 1);
        var valueObject2 = new TestValueObject("string", 1);

        // Act
        var result = valueObject1.Equals(valueObject2);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void Equals_When_ValueObjectsHaveDifferentValues_Should_ReturnFalse()
    {
        // Arrange
        var valueObject1 = new TestValueObject("string1", 1);
        var valueObject2 = new TestValueObject("string2", 2);

        // Act
        var result = valueObject1.Equals(valueObject2);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void EqualOperator_When_ValueObjectsHaveTheSameValues_Should_ReturnTrue()
    {
        // Arrange
        var valueObject1 = new TestValueObject("string", 1);
        var valueObject2 = new TestValueObject("string", 1);

        // Act
        var result = valueObject1 == valueObject2;

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void EqualOperator_When_ValueObjectsHaveDifferentValues_Should_ReturnFalse()
    {
        // Arrange
        var valueObject1 = new TestValueObject("string1", 1);
        var valueObject2 = new TestValueObject("string2", 2);

        // Act
        var result = valueObject1 == valueObject2;

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void NotEqualOperator_When_ValueObjectsHaveTheSameValues_Should_ReturnFalse()
    {
        // Arrange
        var valueObject1 = new TestValueObject("string", 1);
        var valueObject2 = new TestValueObject("string", 1);

        // Act
        var result = valueObject1 != valueObject2;

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void NotEqualOperator_When_ValueObjectsHaveDifferentValues_Should_ReturnTrue()
    {
        // Arrange
        var valueObject1 = new TestValueObject("string1", 1);
        var valueObject2 = new TestValueObject("string2", 2);

        // Act
        var result = valueObject1 != valueObject2;

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void GetHashCode_When_ValueObjectsHaveTheSameValues_Should_ReturnTheSameHashCode()
    {
        // Arrange
        var valueObject1 = new TestValueObject("string", 1);
        var valueObject2 = new TestValueObject("string", 1);

        // Act
        var hashCode1 = valueObject1.GetHashCode();
        var hashCode2 = valueObject2.GetHashCode();

        // Assert
        hashCode1.Should().Be(hashCode2);
    }

    [Fact]
    public void GetHashCode_When_ValueObjectsHaveDifferentValues_Should_ReturnDifferentHashCodes()
    {
        // Arrange
        var valueObject1 = new TestValueObject("string1", 1);
        var valueObject2 = new TestValueObject("string2", 2);

        // Act
        var hashCode1 = valueObject1.GetHashCode();
        var hashCode2 = valueObject2.GetHashCode();

        // Assert
        hashCode1.Should().NotBe(hashCode2);
    }
}