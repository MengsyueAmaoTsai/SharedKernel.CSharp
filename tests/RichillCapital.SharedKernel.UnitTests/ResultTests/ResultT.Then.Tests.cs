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

    [Fact]
    public void Then_When_IsSuccess_Should_InvokeResultFactoryWithValue_And_ReturnSuccessResultWithResultValue()
    {
        // Arrange & Act
        var result = TestValue
            .ToResult()
            .Then(ResultFactoryWithValue);

        // Assert
        result.ShouldBeSuccessWith(TestValue.ToString());
    }

    [Fact]
    public void Then_When_IsFailure_Should_NotInvokeResultFactoryWithValue_And_ReturnOriginal()
    {
        // Arrange & Act
        var result = TestError
            .ToResult<int>()
            .Then(ResultFactoryWithValue);

        // Assert
        result.ShouldBeFailureWith(TestError);
    }

    [Fact]
    public async Task ThenAsync_When_IsFailure_Should_NotInvokeFactoryWithValueTask_And_ReturnFailureResultWithError()
    {
        // Arrange & Act
        var result = await TestError
            .ToResult<int>()
            .Then(ValueFactoryWithValueTask);

        // Assert
        result.ShouldBeFailureWith(TestError);
    }

    [Fact]
    public async Task ThenAsync_When_IsSuccess_Should_InvokeFactoryWithValueTask_And_ReturnSuccessResultWithResultValue()
    {
        // Arrange & Act
        var result = await TestValue
            .ToResult()
            .Then(ValueFactoryWithValueTask);

        // Assert
        result.ShouldBeSuccessWith(TestValue * 2);
    }

    [Fact]
    public async Task ThenAsync_When_IsSuccess_Should_InvokeResultFactoryWithValueTask_And_ReturnSuccessResultWithResultValue()
    {
        // Arrange & Act
        var result = await TestValue
            .ToResult()
            .Then(ResultFactoryWithValueTask);

        // Assert
        result.ShouldBeSuccessWith(TestValue.ToString());
    }

    [Fact]
    public async Task ThenAsync_When_IsFailure_Should_NotInvokeResultFactoryWithValueTask_And_ReturnOriginal()
    {
        // Arrange & Act
        var result = await TestError
            .ToResult<int>()
            .Then(ResultFactoryWithValueTask);

        // Assert
        result.ShouldBeFailureWith(TestError);
    }

    [Fact]
    public async Task ThenAsync_When_ResultTaskIsSuccess_Should_InvokeFactoryWithValue_And_ReturnSuccessResultWithResultValue()
    {
        // Arrange & Act
        var result = await Task.FromResult(TestValue.ToResult())
            .Then(ValueFactoryWithValue);

        // Assert
        result.ShouldBeSuccessWith(TestValue * 2);
    }

    [Fact]
    public async Task ThenAsync_When_ResultTaskIsFailure_Should_NotInvokeFactoryWithValue_And_ReturnOriginal()
    {
        // Arrange & Act
        var result = await Task.FromResult(TestError.ToResult<int>())
            .Then(ValueFactoryWithValue);

        // Assert
        result.ShouldBeFailureWith(TestError);
    }

    [Fact]
    public async Task ThenAsync_When_IsFailure_Should_NotInvokeMaybeFactoryWithValueTask_And_ReturnFailureResultWithError()
    {
        // Arrange & Act
        var result = await TestError
            .ToResult<int>()
            .Then(MaybeFactoryWithValueTask, ErrorFactoryWithValue);

        // Assert
        result.ShouldBeFailureWith(TestError);
    }

    [Fact]
    public async Task ThenAsync_When_IsSuccess_And_MaybeTaskIsNull_Should_InvokeMaybeFactoryWithValueTask_And_ReturnFailureResultWithGivenError()
    {
        // Arrange & Act
        var result = await TestValue
            .ToResult()
            .Then(MaybeFactoryWithValueTask_Null, ErrorFactoryWithValue);

        // Assert
        result.ShouldBeFailureWith(ErrorFactoryWithValue(TestValue));
    }

    [Fact]
    public async Task ThenAsync_When_IsSuccess_And_MaybeTaskHasValue_Should_InvokeMaybeFactoryWithValueTask_And_ReturnSuccessResultWithValue()
    {
        // Arrange & Act
        var result = await TestValue
            .ToResult()
            .Then(MaybeFactoryWithValueTask, ErrorFactoryWithValue);

        // Assert
        result.ShouldBeSuccessWith(TestValue.ToString());
    }

    [Fact]
    public async Task ThenAsync_When_IsFailure_Should_NotInvokeErrorOrFactoryWithValueTask_And_ReturnFailureResultWithError()
    {
        // Arrange & Act
        var result = await TestError
            .ToResult<int>()
            .Then(ErrorOrFactoryWithValueTask);

        // Assert
        result.ShouldBeFailureWith(TestError);
    }

    [Fact]
    public async Task ThenAsync_When_IsSuccess_And_ErrorOrTaskHasError_Should_InvokeErrorOrFactoryWithValueTask_And_ReturnFailureResultWithError()
    {
        // Arrange & Act
        var result = await TestValue
            .ToResult()
            .Then(ErrorOrFactoryWithValueTask_HasError);

        // Assert
        result.ShouldBeFailureWith(TestErrors.First());
    }

    [Fact]
    public async Task ThenAsync_When_IsSuccess_And_ErrorOrTaskIsValue_Should_InvokeErrorOrFactoryWithValueTask_And_ReturnSuccessResultWithValue()
    {
        // Arrange & Act
        var result = await TestValue
            .ToResult()
            .Then(ErrorOrFactoryWithValueTask);

        // Assert
        result.ShouldBeSuccessWith(TestValue.ToString());
    }
}