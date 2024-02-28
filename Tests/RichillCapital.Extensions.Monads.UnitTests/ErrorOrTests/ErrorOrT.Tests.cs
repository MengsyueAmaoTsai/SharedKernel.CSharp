using FluentAssertions;

using RichillCapital.Extensions.Monads.UnitTests.Shared;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Extensions.Monads.UnitTests;

public sealed class ErrorOrTTests : MonadTests
{
    [Fact]
    public void HasError_When_HasError_Should_ReturnTrue()
    {
        // Arrange
        var errorOr = ErrorOr<int>.Is(Errors);

        // Act & Assert
        errorOr.HasError.Should().BeTrue();
    }

    [Fact]
    public void HasError_When_IsValue_Should_ReturnFalse()
    {
        // Arrange
        var errorOr = ErrorOr<int>.Is(1);

        // Act & Assert
        errorOr.HasError.Should().BeFalse();
    }

    [Fact]
    public void IsValue_When_HasError_Should_ReturnFalse()
    {
        // Arrange
        var errorOr = ErrorOr<int>.Is(Errors);

        // Act & Assert
        errorOr.IsValue.Should().BeFalse();
    }

    [Fact]
    public void IsValue_When_IsValue_Should_ReturnTrue()
    {
        // Arrange
        var errorOr = ErrorOr<int>.Is(1);

        // Act & Assert
        errorOr.IsValue.Should().BeTrue();
    }

    [Fact]
    public void Errors_When_HasError_Should_ReturnErrors()
    {
        // Arrange
        var errorOr = ErrorOr<int>.Is(Errors);

        // Act & Assert
        errorOr.Errors.Should().BeEquivalentTo(Errors);
    }

    [Fact]
    public void Errors_When_IsValue_Should_ReturnIsNotError()
    {
        // Arrange
        var errorOr = ErrorOr<int>.Is(1);

        // Act & Assert
        errorOr.Errors.Should().HaveCount(1);
    }

    [Fact]
    public void ErrorsOrEmpty_When_HasError_Should_ReturnErrors()
    {
        // Arrange
        var errorOr = ErrorOr<int>.Is(Errors);

        // Act & Assert
        errorOr.ErrorsOrEmpty.Should().BeEquivalentTo(Errors);
    }

    [Fact]
    public void ErrorsOrEmpty_When_IsValue_Should_ReturnEmpty()
    {
        // Arrange
        var errorOr = ErrorOr<int>.Is(1);

        // Act & Assert
        errorOr.ErrorsOrEmpty.Should().BeEmpty();
    }
}