using FluentAssertions;

namespace RichillCapital.SharedKernel.UnitTests;

public sealed partial class ErrorTests
{
    [Fact]
    public void Equal_Should_Return_True_When_Both_Instances_Are_Equal()
    {
        // Arrange
        var error1 = Error.Invalid("Invalid input.");
        var error2 = Error.Invalid("Invalid input.");

        // Act
        var result = error1.Equals(error2);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void Equal_Should_Return_False_When_Both_Instances_Are_Not_Equal()
    {
        // Arrange
        var error1 = Error.Invalid("Invalid input.");
        var error2 = Error.Unauthorized("Unauthorized access.");

        // Act
        var result = error1.Equals(error2);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void EqualsOperator_Should_Return_True_When_Both_Instances_Are_Equal()
    {
        // Arrange
        var error1 = Error.Invalid("Invalid input.");
        var error2 = Error.Invalid("Invalid input.");

        // Act
        var result = error1 == error2;

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void EqualsOperator_Should_Return_False_When_Both_Instances_Are_Not_Equal()
    {
        // Arrange
        var error1 = Error.Invalid("Invalid input.");
        var error2 = Error.Unauthorized("Unauthorized access.");

        // Act
        var result = error1 == error2;

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void NotEqualsOperator_Should_Return_True_When_Both_Instances_Are_Not_Equal()
    {
        // Arrange
        var error1 = Error.Invalid("Invalid input.");
        var error2 = Error.Unauthorized("Unauthorized access.");

        // Act
        var result = error1 != error2;

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void NotEqualsOperator_Should_Return_False_When_Both_Instances_Are_Equal()
    {
        // Arrange
        var error1 = Error.Invalid("Invalid input.");
        var error2 = Error.Invalid("Invalid input.");

        // Act
        var result = error1 != error2;

        // Assert
        result.Should().BeFalse();
    }
}