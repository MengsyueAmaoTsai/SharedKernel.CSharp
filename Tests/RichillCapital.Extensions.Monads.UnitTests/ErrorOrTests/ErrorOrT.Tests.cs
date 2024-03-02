using FluentAssertions;

using RichillCapital.Extensions.Monads.UnitTests.Shared;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Extensions.Monads.UnitTests;

public sealed class ErrorOrTTests : MonadTests
{
    // [Fact]
    // public void Equals_When_ErrorOrAreSameValues_Should_ReturnTrue()
    // {
    //     // Arrange
    //     var errorOr1 = ErrorOr<int>.With(3);
    //     var errorOr2 = ErrorOr<int>.With(3);

    //     // Act
    //     var result = errorOr1.Equals(errorOr2);

    //     // Assert
    //     result.Should().BeTrue();
    // }

    [Fact]
    public void Equals_When_ErrorOrHasSameErrors_Should_ReturnTrue()
    {
        // Arrange
        var errorOr1 = ErrorOr<int>.WithError(TestErrors);
        var errorOr2 = ErrorOr<int>.WithError(TestErrors);

        // Act
        var result = errorOr1.Equals(errorOr2);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void Equals_When_ErrorOrHasSameErrors_And_DifferentTypes_Should_ReturnFalse()
    {
        // Arrange
        var errorOr1 = ErrorOr<int>.WithError(TestErrors);
        var errorOr2 = ErrorOr<string>.WithError(TestErrors);

        // Act
        var result = errorOr1.Equals(errorOr2);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void Errors_When_IsValue_Should_Return_ErrorsWithUnexpectedError()
    {
        // Arrange & Act
        var errorOr = ErrorOr<int>.With(TestValue);

        // Assert
        errorOr.Errors.Should().HaveCount(1);
    }

    [Fact]
    public void Errors_When_HasError_Should_Return_Errors()
    {
        // Arrange & Act
        var errorOr = ErrorOr<int>.WithError(TestErrors);

        // Assert
        errorOr.Errors.Should().HaveCount(TestErrors.Count);
        errorOr.Errors.Should().BeEquivalentTo(TestErrors);
    }

    [Fact]
    public void ErrorsOrEmpty_When_IsValue_Should_ReturnEmptyList()
    {
        // Arrange & Act
        var errorOr = ErrorOr<int>.With(TestValue);

        // Assert
        errorOr.ErrorsOrEmpty.Should().BeEmpty();
    }

    [Fact]
    public void ErrorsOrEmpty_When_HasError_Should_Return_Errors()
    {
        // Arrange & Act
        var errorOr = ErrorOr<int>.WithError(TestErrors);

        // Assert
        errorOr.ErrorsOrEmpty.Should().HaveCount(TestErrors.Count);
        errorOr.ErrorsOrEmpty.Should().BeEquivalentTo(TestErrors);
    }

    [Fact]
    public void Value_When_IsValue_Should_ReturnValue()
    {
        // Arrange & Act
        var errorOr = ErrorOr<int>.With(TestValue);

        // Assert
        errorOr.Value.Should().Be(TestValue);
    }

    [Fact]
    public void Value_When_HasError_Should_ThrowException()
    {
        // Arrange
        var errorOr = ErrorOr<int>.WithError(TestErrors);

        // Act
        Action act = () => _ = errorOr.Value;

        // Assert
        act.Should().Throw<InvalidOperationException>();
    }

    [Fact]
    public void ValueOrDefault_When_IsValue_Should_ReturnValue()
    {
        // Arrange & Act
        var errorOr = ErrorOr<int>.With(TestValue);

        // Assert
        errorOr.ValueOrDefault.Should().Be(TestValue);
    }

    [Fact]
    public void ValueOrDefault_When_HasError_Should_ReturnDefaultValue()
    {
        // Arrange
        var errorOr = ErrorOr<int>.WithError(TestErrors);
        var errorOr2 = ErrorOr<string>.WithError(TestErrors);

        // Act & Assert
        errorOr.ValueOrDefault.Should().Be(0);
        errorOr2.ValueOrDefault.Should().Be(null);
    }
}