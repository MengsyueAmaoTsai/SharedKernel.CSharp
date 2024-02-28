using RichillCapital.Extensions.Monads.UnitTests.Shared;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Extensions.Monads.UnitTests;

public sealed class ResultTEnsureTests : MonadTests
{
    [Fact]
    public void EnsureFactory_When_GivenPredicateIsTrue_Should_CreateSuccessResultWithValue()
    {
        // Arrange
        Result<int> valueResult = Result<int>
            .Ensure(Value, value => value == 5, UnexpectedError);

        // Assert
        valueResult.ShouldBeSuccessWith(Value);
    }

    [Fact]
    public void EnsureFactory_When_GivenPredicateIsFalse_Should_CreateFailureResultWithError()
    {
        // Arrange
        Result<int> valueResult = Result<int>
            .Ensure(Value, value => value == 10, UnexpectedError);

        // Assert
        valueResult.ShouldBeFailureWith(UnexpectedError);
    }
}