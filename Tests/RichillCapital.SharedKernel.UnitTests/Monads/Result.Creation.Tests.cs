using FluentAssertions;

using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.SharedKernel.UnitTests.Monads;

public sealed partial class ResultTests
{
    [Fact]
    public void Success_Should_ReturnSuccessResult()
    {
        // Arrange & Act
        Result result = Result.Success();

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Error.Should().Be(Error.Null);
    }

    [Fact]
    public void Success_When_GivenValue_Should_ReturnSuccessResult()
    {
        // Arrange & Act
        Result<int> result = Result.Success(IntValue);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Error.Should().Be(Error.Null);
        result.Value.Should().Be(IntValue);
    }

    [Fact]
    public void Failure_Should_ReturnFailureResult()
    {
        // Arrange & Act
        Result result = Result.Failure(NotFoundError);
        Result<int> result2 = Result.Failure<int>(NotFoundError);

        // Assert
        result.IsFailure.Should().BeTrue();
        result2.IsFailure.Should().BeTrue();

        result.Error.Should().Be(NotFoundError);
        result2.Error.Should().Be(NotFoundError);
    }

    [Fact]
    public void Ensure_When_PredicateIsTrue_Should_ReturnSuccessResult()
    {
        // Arrange & Act
        var result = Result.Ensure(IntValue, value => value > 0, NotFoundError);
        Result<int> resultT = Result<int>.Ensure(IntValue, value => value > 0, NotFoundError);

        // Assert
        result.IsSuccess.Should().BeTrue();
        resultT.IsSuccess.Should().BeTrue();

        result.Error.Should().Be(Error.Null);
        resultT.Error.Should().Be(Error.Null);
        resultT.Value.Should().Be(IntValue);
    }

    [Fact]
    public void Ensure_When_PredicateIsFalse_Should_ReturnFailureResult()
    {
        // Arrange & Act
        var result = Result.Ensure(IntValue, value => value < 0, NotFoundError);
        Result<int> resultT = Result<int>.Ensure(IntValue, value => value < 0, NotFoundError);

        // Assert
        result.IsFailure.Should().BeTrue();
        resultT.IsFailure.Should().BeTrue();

        result.Error.Should().Be(NotFoundError);
        resultT.Error.Should().Be(NotFoundError);
    }
}