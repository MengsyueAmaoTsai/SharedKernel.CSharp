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
    public void ToResult_When_GivenError_Should_CreateFailureResultWithError()
    {
        // Arrange & Act
        Result<int> result = UnexpectedError.ToResult<int>();

        // Assert
        result.ShouldBeFailureWith(UnexpectedError);
    }
}