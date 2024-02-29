using FluentAssertions;

using RichillCapital.SharedKernel;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Extensions.Monads.UnitTests;

public sealed class ResultTTests
{
    [Fact]
    public void IsSuccess_When_IsSuccess_Should_ReturnTrue()
    {
        // Arrange
        Result<int> intResult = Result<int>.Success(1);

        // Act & Assert
        intResult.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public void IsSuccess_When_IsFailure_Should_ReturnFalse()
    {
        // Arrange
        Result<int> intResult = Result<int>.Failure(Error.Invalid("Invalid"));

        // Act & Assert
        intResult.IsSuccess.Should().BeFalse();
    }

    [Fact]
    public void IsFailure_When_IsFailure_Should_ReturnTrue()
    {
        // Arrange
        Result<int> intResult = Result<int>.Failure(Error.Invalid("Invalid"));

        // Act & Assert
        intResult.IsFailure.Should().BeTrue();
    }

    [Fact]
    public void IsFailure_When_IsSuccess_Should_ReturnFalse()
    {
        // Arrange
        Result<int> intResult = Result<int>.Success(1);

        // Act & Assert
        intResult.IsFailure.Should().BeFalse();
    }

    [Fact]
    public void Error_When_IsSuccess_Should_ReturnNullError()
    {
        // Arrange
        Result<int> intResult = Result<int>.Success(1);

        // Act & Assert
        intResult.Error.Should().Be(Error.Null);
    }

    [Fact]
    public void Error_When_IsFailure_Should_ReturnError()
    {
        // Arrange
        Error error = Error.Invalid("Invalid");
        Result<int> intResult = Result<int>.Failure(error);

        // Act & Assert
        intResult.Error.Should().Be(error);
    }

    [Fact]
    public void Value_When_IsSuccess_Should_ReturnValue()
    {
        // Arrange
        Result<int> intResult = Result<int>.Success(1);

        // Act & Assert
        intResult.Value.Should().Be(1);
    }

    [Fact]
    public void Value_When_IsFailure_Should_ThrowInvalidOperationException()
    {
        // Arrange
        Result<int> intResult = Result<int>.Failure(Error.Invalid("Invalid"));

        // Act & Assert
        Action act = () => intResult.Value.Should().Be(1);
        act.Should().Throw<InvalidOperationException>().WithMessage("Cannot access the value of a failed result.");
    }

    [Fact]
    public void ValueOrDefault_When_IsSuccess_Should_ReturnValue()
    {
        // Arrange
        Result<int> intResult = Result<int>.Success(1);

        // Act & Assert
        intResult.ValueOrDefault.Should().Be(1);
    }

    [Fact]
    public void ValueOrDefault_When_IsFailure_Should_ReturnDefault()
    {
        // Arrange
        Result<int> intResult = Result<int>.Failure(Error.Invalid("Invalid"));

        // Act & Assert
        intResult.ValueOrDefault.Should().Be(default);
    }

    [Fact]
    public void Equals_When_IsFailureAndSameError_Should_ReturnTrue()
    {
        // Arrange
        Error error = Error.Invalid("Invalid");
        Result<int> intResult1 = Result<int>.Failure(error);
        Result<int> intResult2 = Result<int>.Failure(error);

        // Act & Assert
        intResult1.Equals(intResult2).Should().BeTrue();
    }

    [Fact]
    public void Equals_When_IsFailureAndDifferentError_Should_ReturnFalse()
    {
        // Arrange
        Result<int> intResult1 = Result<int>.Failure(Error.Invalid("Invalid"));
        Result<int> intResult2 = Result<int>.Failure(Error.Invalid("Invalid2"));

        // Act & Assert
        intResult1.Equals(intResult2).Should().BeFalse();
    }

    [Fact]
    public void Equals_When_IsSuccessAndSameValue_Should_ReturnTrue()
    {
        // Arrange
        Result<int> intResult1 = Result<int>.Success(1);
        Result<int> intResult2 = Result<int>.Success(1);

        // Act & Assert
        intResult1.Equals(intResult2).Should().BeTrue();
    }

    [Fact]
    public void Equals_When_IsSuccessAndDifferentValue_Should_ReturnFalse()
    {
        // Arrange
        Result<int> intResult1 = Result<int>.Success(1);
        Result<int> intResult2 = Result<int>.Success(2);

        // Act & Assert
        intResult1.Equals(intResult2).Should().BeFalse();
    }
}