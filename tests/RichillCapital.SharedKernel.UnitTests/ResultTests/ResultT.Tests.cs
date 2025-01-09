using FluentAssertions;

using RichillCapital.Extensions.Monads.UnitTests.Shared;
using RichillCapital.SharedKernel;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Extensions.Monads.UnitTests;

public sealed class ResultTTests : MonadTests
{
    [Fact]
    public void Equals_When_SuccessResultsWithDifferentValues_Should_ReturnFalse()
    {
        // Arrange
        Result<int> result1 = TestValue.ToResult();
        Result<int> result2 = 1.ToResult();

        // Act
        var result = result1.Equals(result2);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void Equals_When_SuccessResultWithSameValue_Should_ReturnTrue()
    {
        // Arrange
        Result<int> result1 = TestValue.ToResult();
        Result<int> result2 = TestValue.ToResult();

        // Act
        var result = result1.Equals(result2);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void Equals_When_FailureResultsWithSameError_And_DifferentTypes_Should_ReturnFalse()
    {
        // Arrange
        Result<int> result1 = TestError.ToResult<int>();
        Result<string> result2 = TestError.ToResult<string>();

        // Act
        var result = result1.Equals(result2);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void Equals_When_FailureResultsWithDifferentErrors_Should_ReturnFalse()
    {
        // Arrange
        Result<int> result1 = TestError.ToResult<int>();
        Result<int> result2 = Error.Invalid("other").ToResult<int>();

        // Act
        var result = result1.Equals(result2);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void Equals_When_FailureResultsWithSameError_Should_ReturnTrue()
    {
        // Arrange
        Result<int> result1 = TestError.ToResult<int>();
        Result<int> result2 = TestError.ToResult<int>();

        // Act
        var result = result1.Equals(result2);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void Error_When_IsFailure_Should_ReturnError()
    {
        // Arrange
        var result = TestError.ToResult<int>();

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

    [Fact]
    public void Value_When_IsFailure_Should_ThrowInvalidOperationException()
    {
        // Arrange
        var result = TestError.ToResult<int>();

        // Act
        var action = () => _ = result.Value;

        // Assert
        action.Should().Throw<InvalidOperationException>()
            .WithMessage("Cannot access the value of a failed result.");
    }

    [Fact]
    public void Value_When_IsSuccess_Should_ReturnValue()
    {
        // Arrange
        var result = TestValue.ToResult();

        // Assert
        result.Value.Should().Be(TestValue);
    }

    [Fact]
    public void ValueOrDefault_When_IsSuccess_Should_ReturnValue()
    {
        // Arrange
        var result = TestValue.ToResult();

        // Assert
        result.ValueOrDefault.Should().Be(TestValue);
    }

    [Fact]
    public void ValueOrDefault_When_IsFailure_Should_ReturnDefaultValue()
    {
        // Arrange
        var result = TestError.ToResult<int>();
        var result2 = TestError.ToResult<string>();

        // Assert
        result.ValueOrDefault.Should().Be(0);
        result2.ValueOrDefault.Should().Be(null);
    }
}