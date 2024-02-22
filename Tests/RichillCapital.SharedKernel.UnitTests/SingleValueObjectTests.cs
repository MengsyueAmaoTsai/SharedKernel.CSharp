using FluentAssertions;

namespace RichillCapital.SharedKernel.UnitTests;

public sealed class SingleValueObjectTests
{
    [Fact]
    public void ToString_Should_ReturnTheValueOfTheSingleValueObject()
    {
        // Arrange
        var value = 56;
        var singleValueObject = new TestSingleValueObject(value);

        // Act
        var result = singleValueObject.ToString();

        // Assert
        result.Should().Be(value.ToString());
    }
}