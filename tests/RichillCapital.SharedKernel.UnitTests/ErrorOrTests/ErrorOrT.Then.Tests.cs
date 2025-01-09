using RichillCapital.Extensions.Monads.UnitTests.Shared;

namespace RichillCapital.SharedKernel.Monads.UnitTests;

public sealed class ErrorOrTThenTests : MonadTests
{
    [Fact]
    public void Then_When_IsValue_Should_InvokeAction_And_ReturnOriginal()
    {
        // Arrange & Act
        var errorOr = TestValue
            .ToErrorOr()
            .Then(DoSomeAction);

        // Assert
        errorOr.ShouldBeValue(TestValue);
    }

    [Fact]
    public void Then_When_HasError_Should_NotInvokeAction_And_ReturnOriginal()
    {
        // Arrange & Act
        var errorOr = TestError
            .ToErrorOr<int>()
            .Then(DoSomeAction);

        // Assert
        errorOr.ShouldBeError(TestError);
    }

    [Fact]
    public void Then_When_IsValue_Should_InvokeActionWithValue_And_ReturnOriginal()
    {
        // Arrange & Act
        var errorOr = TestValue
            .ToErrorOr()
            .Then(DoSomeActionWithValue);

        // Assert
        errorOr.ShouldBeValue(TestValue);
    }

    [Fact]
    public void Then_When_HasError_Should_NotInvokeActionWithValue_And_ReturnOriginal()
    {
        // Arrange & Act
        var errorOr = TestError
            .ToErrorOr<int>()
            .Then(DoSomeActionWithValue);

        // Assert
        errorOr.ShouldBeError(TestError);
    }

    [Fact]
    public void Then_When_IsValue_Should_InvokeFactory_And_ReturnErrorOrWithResultValue()
    {
        // Arrange & Act
        var errorOr = TestValue
            .ToErrorOr()
            .Then(ValueFactory);

        // Assert
        errorOr.ShouldBeValue(TestValue * 2);
    }

    [Fact]
    public void Then_When_HasError_Should_NotInvokeFactory_And_ReturnOriginal()
    {
        // Arrange & Act
        var errorOr = TestError
            .ToErrorOr<int>()
            .Then(ValueFactory);

        // Assert
        errorOr.ShouldBeError(TestError);
    }

    [Fact]
    public void Then_When_IsValue_Should_InvokeFactoryWithValue_And_ReturnErrorOrWithResultValue()
    {
        // Arrange & Act
        var errorOr = TestValue
            .ToErrorOr()
            .Then(ValueFactoryWithValue);

        // Assert
        errorOr.ShouldBeValue(TestValue * 2);
    }

    [Fact]
    public void Then_When_HasError_Should_NotInvokeFactoryWithValue_And_ReturnOriginal()
    {
        // Arrange & Act
        var errorOr = TestError
            .ToErrorOr<int>()
            .Then(ValueFactoryWithValue);

        // Assert
        errorOr.ShouldBeError(TestError);
    }

    [Fact]
    public async Task ThenAsync_When_HasError_Should_NotInvokeFactoryWithValueTask_And_ReturnErrorOrWithErrors()
    {
        // Arrange & Act
        var errorOr = await TestErrors
            .ToErrorOr<int>()
            .Then(ValueFactoryWithValueTask);

        // Assert
        errorOr.ShouldBeErrors(TestErrors);
    }

    [Fact]
    public async Task ThenAsync_When_IsValue_Should_InvokeFactoryWithValueTask_And_ReturnErrorOrWithValue()
    {
        // Arrange & Act
        var errorOr = await TestValue
            .ToErrorOr()
            .Then(ValueFactoryWithValueTask);

        // Assert
        errorOr.ShouldBeValue(TestValue * 2);
    }

    [Fact]
    public void Then_When_IsValue_Should_InvokeErrorOrFactoryWithValue_And_ReturnErrorOrWithResultValue()
    {
        // Arrange & Act
        var errorOr = TestValue
            .ToErrorOr()
            .Then(ErrorOrFactoryWithValue);

        // Assert
        errorOr.ShouldBeValue(TestValue.ToString());
    }

    [Fact]
    public void Then_When_HasError_Should_NotInvokeErrorOrFactoryWithValue_And_ReturnOriginal()
    {
        // Arrange & Act
        var errorOr = TestError
            .ToErrorOr<int>()
            .Then(ErrorOrFactoryWithValue);

        // Assert
        errorOr.ShouldBeError(TestError);
    }

    [Fact]
    public async Task ThenAsync_When_IsValue_Should_InvokeErrorOrFactoryWithValueTask_And_ReturnErrorOrWithResultValue()
    {
        // Arrange & Act
        var errorOr = await TestValue
            .ToErrorOr()
            .Then(ErrorOrFactoryWithValueTask);

        // Assert
        errorOr.ShouldBeValue(TestValue.ToString());
    }

    [Fact]
    public async Task ThenAsync_When_HasError_Should_NotInvokeErrorOrFactoryWithValueTask_And_ReturnOriginal()
    {
        // Arrange & Act
        var errorOr = await TestError
            .ToErrorOr<int>()
            .Then(ErrorOrFactoryWithValueTask);

        // Assert
        errorOr.ShouldBeError(TestError);
    }

    [Fact]
    public async Task ThenAsync_When_ErrorOrTaskIsValue_Should_InvokeFactoryWithValue_And_ReturnErrorOrWithResultValue()
    {
        // Arrange & Act
        var errorOr = await Task.FromResult(TestValue.ToErrorOr())
            .Then(ValueFactoryWithValue);

        // Assert
        errorOr.ShouldBeValue(TestValue * 2);
    }

    [Fact]
    public async Task ThenAsync_When_ErrorOrTaskHasError_Should_NotInvokeFactoryWithValue_And_ReturnOriginal()
    {
        // Arrange & Act
        var errorOr = await Task.FromResult(TestError.ToErrorOr<int>())
            .Then(ErrorOrFactoryWithValueTask)
            .Then(value => value);

        // Assert
        errorOr.ShouldBeError(TestError);
    }

    [Fact]
    public async Task ThenAsync_When_HasError_Should_NotInvokeMaybeFactoryWithValueTask_And_ReturnErrors()
    {
        // Arrange & Act
        var errorOr = await TestError
            .ToErrorOr<int>()
            .Then(MaybeFactoryWithValueTask, ErrorFactoryWithValue);

        // Assert
        errorOr.ShouldBeError(TestError);
    }

    [Fact]
    public async Task ThenAsync_When_IsValue_And_MaybeTaskIsNull_Should_InvokeMaybeFactoryWithValueTask_And_ReturnErrorFromFactory()
    {
        // Arrange & Act
        var errorOr = await TestValue
            .ToErrorOr()
            .Then(MaybeFactoryWithValueTask_Null, ErrorFactoryWithValue);

        // Assert
        errorOr.ShouldBeError(ErrorFactoryWithValue(TestValue));
    }

    [Fact]
    public async Task ThenAsync_When_IsValue_And_MaybeTaskHasValue_Should_InvokeMaybeFactoryWithValueTask_And_ReturnErrorOrWithValue()
    {
        // Arrange & Act
        var errorOr = await TestValue
            .ToErrorOr()
            .Then(MaybeFactoryWithValueTask, ErrorFactoryWithValue);

        // Assert
        errorOr.ShouldBeValue(TestValue.ToString());
    }

    [Fact]
    public async Task ThenAsync_When_HasError_Should_NotInvokeResultFactoryWithValueTask_And_ReturnErrors()
    {
        // Arrange & Act
        var errorOr = await TestErrors
            .ToErrorOr<int>()
            .Then(ResultFactoryWithValueTask);

        // Assert
        errorOr.ShouldBeErrors(TestErrors);
    }

    [Fact]
    public async Task ThenAsync_When_IsValue_And_ResultTaskIsFailure_Should_InvokeResultFactoryWithValueTask_And_ReturnErrorOrWithError()
    {
        // Arrange & Act
        var errorOr = await TestValue
            .ToErrorOr()
            .Then(ResultFactoryWithValueTask_IsFailure);

        // Assert
        errorOr.ShouldBeError(TestError);
    }

    [Fact]
    public async Task ThenAsync_When_IsValue_And_ResultTaskIsSuccess_Should_InvokeResultFactoryWithValueTask_And_ReturnErrorOrWithValue()
    {
        // Arrange & Act
        var errorOr = await TestValue
            .ToErrorOr()
            .Then(ResultFactoryWithValueTask);

        // Assert
        errorOr.ShouldBeValue(TestValue.ToString());
    }
}