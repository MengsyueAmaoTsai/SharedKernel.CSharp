using FluentAssertions;

using RichillCapital.Extensions.Monads.UnitTests.Shared;
using RichillCapital.SharedKernel;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Extensions.Monads.UnitTests;

public sealed class ResultTests : MonadTests
{
    [Fact]
    public void Equals_When_FailureResultsWithDifferentErrors_Should_ReturnFalse()
    {
        // Arrange
        Result result1 = TestError.ToResult();
        Result result2 = Error.Invalid("other").ToResult();

        // Act
        var result = result1.Equals(result2);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void Equals_When_FailureResultsWithSameError_Should_ReturnTrue()
    {
        // Arrange
        Result result1 = TestError.ToResult();
        Result result2 = TestError.ToResult();

        // Act
        var result = result1.Equals(result2);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void Success_Should_ReturnSuccessResult()
    {
        // Arrange & Act
        var result = Result.Success;

        // Assert
        result.ShouldBeSuccess();
    }

    [Fact]
    public void Error_When_IsFailure_Should_ReturnError()
    {
        // Arrange
        var result = TestError.ToResult();

        // Assert
        result.Error.Should().Be(TestError);
    }

    [Fact]
    public void Error_When_IsSuccess_Should_ReturnNullError()
    {
        // Arrange
        var result = TestValue.ToResult();

        // Assert
        result.Error.Should().Be(Error.Null);
    }
}