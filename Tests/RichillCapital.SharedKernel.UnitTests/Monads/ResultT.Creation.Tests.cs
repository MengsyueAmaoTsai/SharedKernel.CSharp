using FluentAssertions;

using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.SharedKernel.UnitTests.Monads;

public sealed partial class GenericResultTests : MonadTests
{
    [Fact]
    public void Success_When_GivenPrimitiveValue_Should_ReturnSuccessResultWithValue()
    {
        // Arrange & Act
        var resultInt = Result<int>.Success(IntValue);

        // Assert
        resultInt.IsSuccess.Should().BeTrue();
        resultInt.IsFailure.Should().BeFalse();
        resultInt.Value.Should().Be(IntValue);
    }

    [Fact]
    public void Failure_When_GivenError_Should_ReturnFailureResultWithError()
    {
        // Arrange & Act
        var resultInt = Result<int>.Failure(NotFoundError);

        // Assert
        resultInt.IsFailure.Should().BeTrue();
        resultInt.IsSuccess.Should().BeFalse();
        resultInt.Error
            .Should().Be(NotFoundError);
    }

    [Fact]
    public void Ensure_When_GivenPredicateThatReturnsTrue_Should_ReturnSuccessResult()
    {
        // Arrange & Act
        var ensuredResult = Result<int>.Ensure(IntValue, value => value != 0, NotFoundError);

        // Assert
        ensuredResult.IsSuccess.Should().BeTrue();
        ensuredResult.Error.Should().Be(Error.Null);
    }

    [Fact]
    public void Ensure_When_GivenPredicateThatReturnsFalse_Should_ReturnFailureResult()
    {
        // Arrange & Act
        var ensuredResult = Result<int>.Ensure(IntValue, value => value == 0, NotFoundError);

        // Assert
        ensuredResult.IsFailure.Should().BeTrue();
        ensuredResult.Error.Should().Be(NotFoundError);
    }
}

