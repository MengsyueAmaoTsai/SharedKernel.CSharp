using RichillCapital.Extensions.Monads.UnitTests.Shared;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Extensions.Monads.UnitTests;

public sealed class ResultTThenTests : MonadTests
{
    [Fact]
    public void Then_When_IsFailure_Should_NotInvokeFactory_And_ReturnFailureResultWithError()
    {
        // Arrange & Act
        var result = TestError
            .ToResult<int>()
            .Then(MapValueToResult);

        // Assert
        result.ShouldBeFailureWith(TestError);
    }

    [Fact]
    public void Then_When_IsSuccess_Should_InvokeFactory_And_ReturnSuccessResultWithResultValue()
    {
        // Arrange & Act
        var result = TestValue
            .ToResult()
            .Then(MapValueToResult);

        // Assert
        result.ShouldBeSuccessWith(MapValueToResult(TestValue));
    }
}