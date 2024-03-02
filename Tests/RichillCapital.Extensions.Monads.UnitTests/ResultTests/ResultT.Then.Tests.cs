using RichillCapital.Extensions.Monads.UnitTests.Shared;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Extensions.Monads.UnitTests;

public sealed class ResultTThenTests : MonadTests
{
    [Fact]
    public void Then_When_IsSuccess_Should_InvokeAction_And_ReturnOriginal()
    {
        // Arrange & Act
        var result = TestValue
            .ToResult()
            .Then(DoSomeAction);

        // Assert
        result.ShouldBeSuccessWith(TestValue);
    }

    [Fact]
    public void Then_When_IsFailure_Should_NotInvokeAction_And_ReturnOriginal()
    {
        // Arrange & Act
        var result = TestError
            .ToResult<int>()
            .Then(DoSomeAction);

        // Assert
        result.ShouldBeFailureWith(TestError);
    }

    [Fact]
    public void Then_When_IsSuccess_Should_InvokeActionWithValue_And_ReturnOriginal()
    {
        // Arrange & Act
        var result = TestValue
            .ToResult()
            .Then(DoSomeActionWithValue);

        // Assert
        result.ShouldBeSuccessWith(TestValue);
    }

    [Fact]
    public void Then_When_IsFailure_Should_NotInvokeActionWithValue_And_ReturnOriginal()
    {
        // Arrange & Act
        var result = TestError
            .ToResult<int>()
            .Then(DoSomeActionWithValue);

        // Assert
        result.ShouldBeFailureWith(TestError);
    }

    [Fact]
    public void Then_When_IsSuccess_Should_InvokeFactory_And_ReturnResultWithResultValue()
    {
        // Arrange & Act
        var result = TestValue
            .ToResult()
            .Then(ValueFactory);

        // Assert
        result.ShouldBeSuccessWith(TestValue * 2);
    }

    [Fact]
    public void Then_When_IsFailure_Should_NotInvokeFactory_And_ReturnOriginal()
    {
        // Arrange & Act
        var result = TestError
            .ToResult<int>()
            .Then(ValueFactory);

        // Assert
        result.ShouldBeFailureWith(TestError);
    }

    [Fact]
    public void Then_When_IsSuccess_Should_InvokeFactoryWithValue_And_ReturnResultWithResultValue()
    {
        // Arrange & Act
        var result = TestValue
            .ToResult()
            .Then(ValueFactoryWithValue);

        // Assert
        result.ShouldBeSuccessWith(TestValue * 2);
    }

    [Fact]
    public void Then_When_IsFailure_Should_NotInvokeFactoryWithValue_And_ReturnOriginal()
    {
        // Arrange & Act
        var result = TestError
            .ToResult<int>()
            .Then(ValueFactoryWithValue);

        // Assert
        result.ShouldBeFailureWith(TestError);
    }
}