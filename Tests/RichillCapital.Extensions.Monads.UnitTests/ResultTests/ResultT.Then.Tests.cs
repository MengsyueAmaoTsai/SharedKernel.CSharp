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

    [Fact]
    public void Then_When_IsFailure_Should_NotInvokeActionWithValue_And_ReturnFailureResultWithError()
    {
        // Arrange & Act
        var result = TestError
            .ToResult<int>()
            .Then(SomeActionWithValue);

        // Assert
        result.ShouldBeFailureWith(TestError);
    }

    [Fact]
    public void Then_When_IsSuccess_Should_InvokeActionWithValue_And_ReturnSuccessResultWithValue()
    {
        // Arrange & Act
        var result = TestValue
            .ToResult()
            .Then(SomeActionWithValue);

        // Assert
        result.ShouldBeSuccessWith(TestValue);
    }
}