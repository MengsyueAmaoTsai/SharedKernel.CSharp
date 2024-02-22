using FluentAssertions;

namespace RichillCapital.SharedKernel.UnitTests;

public sealed partial class ErrorTests
{
    [Fact]
    public void Equals_When_ComparingWithNull_Should_ReturnsFalse()
    {
        var error = Error.Invalid("test");

        // Arrange & Act & Assert
        error.Equals(null).Should().BeFalse();
    }

    [Fact]
    public void Equals_When_ComparingWithDifferentType_Should_ReturnsFalse()
    {
        var error = Error.Invalid("test");

        // Arrange & Act & Assert
        error.Equals(new object()).Should().BeFalse();
    }

    [Fact]
    public void Equals_When_ComparingWithDifferentTypeOfErrorAndSameMessage_Should_ReturnsFalse()
    {
        // Arrange
        var message = "Error message";
        var invalidError = Error.Invalid(message);
        var notFoundError = Error.NotFound(message);

        // Act & Assert
        invalidError.Equals(notFoundError).Should().BeFalse();
    }

    [Fact]
    public void Equals_When_ComparingWithDifferentTypeOfErrorAndDifferentMessage_Should_ReturnsFalse()
    {
        // Arrange
        var invalidError = Error.Invalid("Invalid error message");
        var notFoundError = Error.NotFound("Not found error message");

        // Act & Assert
        invalidError.Equals(notFoundError).Should().BeFalse();
    }

    [Fact]
    public void Equals_When_ComparingWithSameMember_Should_ReturnsTrue()
    {
        // Arrange
        var message = "Error message";
        var invalidError = Error.Invalid(message);
        var invalidError2 = Error.Invalid(message);

        // Arrange & Act & Assert
        invalidError.Equals(invalidError2).Should().BeTrue();
    }

    [Fact]
    public void EqualsOperator_When_ComparingWithSameMember_Should_ReturnsTrue()
    {
        // Arrange
        var error = Error.Invalid("test");

        // Act & Assert
        (error == Error.Invalid("test")).Should().BeTrue();
    }

    [Fact]
    public void NotEqualsOperator_When_ComparingWithSameMember_Should_ReturnsFalse()
    {
        // Arrange
        var error = Error.Invalid("test");

        // Act & Assert
        (error != Error.Invalid("test")).Should().BeFalse();
    }

    [Fact]
    public void GetHashCode_When_ComparingWithSameMember_Should_ReturnsTrue()
    {
        // Arrange
        var error = Error.Invalid("test");

        // Act & Assert
        error.GetHashCode().Should().Be(Error.Invalid("test").GetHashCode());
    }

    [Fact]
    public void GetHashCode_When_ComparingWithDifferentMember_Should_ReturnsFalse()
    {
        // Arrange
        var error = Error.Invalid("test");

        // Act & Assert
        error.GetHashCode().Should().NotBe(Error.Invalid("test2").GetHashCode());
    }

    [Fact]
    public void GetHashCode_When_ComparingWithDifferentTypeOfErrorAndSameMessage_Should_ReturnsFalse()
    {
        // Arrange
        var message = "Error message";
        var invalidError = Error.Invalid(message);
        var notFoundError = Error.NotFound(message);

        // Act & Assert
        invalidError.GetHashCode().Should().NotBe(notFoundError.GetHashCode());
    }

    [Fact]
    public void GetHashCode_When_ComparingWithDifferentTypeOfErrorAndDifferentMessage_Should_ReturnsFalse()
    {
        // Arrange
        var invalidError = Error.Invalid("Invalid error message");
        var notFoundError = Error.NotFound("Not found error message");

        // Act & Assert
        invalidError.GetHashCode().Should().NotBe(notFoundError.GetHashCode());
    }
}