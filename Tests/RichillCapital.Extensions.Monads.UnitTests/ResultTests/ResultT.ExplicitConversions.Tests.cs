using RichillCapital.Extensions.Monads.UnitTests.Shared;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Extensions.Monads.UnitTests;

public sealed class ResultTExplicitConversionsTests : MonadTests
{
    [Fact]
    public void ToResult_When_GivenValue_Should_CreateSuccessResultWithValue()
    {
        // Arrange & Act
        Result<int> result = Value.ToResult();

        // Assert
        result.ShouldBeSuccessWith(Value);
    }

    [Fact]
    public void ToResult_When_GivenErrorOrWithErrors_Should_ConvertToFailureResultWithError()
    {
        // Arrange & Act
        Result<int> result = Errors.ToErrorOr<int>().ToResult();

        // Assert
        result.ShouldBeFailureWith(Errors.First());
    }

    [Fact]
    public void ToResult_When_GivenErrorOrWithValue_Should_ConvertToSuccessResultWithValue()
    {
        // Arrange & Act
        Result<int> result = Value.ToErrorOr().ToResult();

        // Assert
        result.ShouldBeSuccessWith(Value);
    }

    [Fact]
    public void ToResult_When_GivenMaybeNull_Should_CreateFailureResultWithError()
    {
        // Arrange & Act
        Result<int> result = Maybe<int>.Null.ToResult(UnexpectedError);

        // Assert
        result.ShouldBeFailureWith(UnexpectedError);
    }

    [Fact]
    public void ToResult_When_GivenMaybeWithValue_Should_CreateSuccessResultWithValue()
    {
        // Arrange & Act
        Result<int> result = Value.ToMaybe()
            .ToResult(UnexpectedError);

        // Assert
        result.ShouldBeSuccessWith(Value);
    }

    [Fact]
    public void ToResult_When_GivenError_Should_CreateFailureResultWithError()
    {
        // Arrange & Act
        Result<int> result = UnexpectedError.ToResult<int>();

        // Assert
        result.ShouldBeFailureWith(UnexpectedError);
    }
}