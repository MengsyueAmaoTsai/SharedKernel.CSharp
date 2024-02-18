using FluentAssertions;

using RichillCapital.SharedKernel.Monad;

namespace RichillCapital.SharedKernel.UnitTests.Monad;

public sealed class ErrorOrTests
{
    [Fact]
    public void NoError_Should_ReturnErrorOrWithNoError()
    {
        // Arrange
        var errorOr = ErrorOr.NoError;

        // Act & Assert
        errorOr.IsNoError.Should().BeTrue();
    }

    [Fact]
    public void From_Should_ReturnErrorOrWithValue()
    {
        // Arrange
        var value = 1;

        // Act
        ErrorOr<int> errorOr = ErrorOr<int>.From(value);

        // Assert
        errorOr.Value.Should().Be(value);
    }

    [Fact]
    public void From_Should_ReturnErrorOrWithError()
    {
        // Arrange
        var errorMessage = "error";
        var error = Error.Invalid(errorMessage);

        // Act
        ErrorOr<int> errorOr = error;

        // Assert
        errorOr.IsError.Should().BeTrue();
        errorOr.Error.Should().Be(error);
        errorOr.Error.Message.Should().Be(errorMessage);
    }

    [Fact]
    public void ImplicitConversion_Should_ReturnErrorOrWithValue()
    {
        // Arrange
        var value = 1;

        // Act
        ErrorOr<int> errorOr = value;

        // Assert
        errorOr.Value.Should().Be(value);
    }

    [Fact]
    public void ImplicitConversion_Should_ReturnErrorOrWithError()
    {
        // Arrange
        var errorMessage = "error";
        var error = Error.Invalid(errorMessage);

        // Act
        ErrorOr<int> errorOr = error;

        // Assert
        errorOr.IsError.Should().BeTrue();
        errorOr.Error.Should().Be(error);
        errorOr.Error.Message.Should().Be(errorMessage);
    }
}