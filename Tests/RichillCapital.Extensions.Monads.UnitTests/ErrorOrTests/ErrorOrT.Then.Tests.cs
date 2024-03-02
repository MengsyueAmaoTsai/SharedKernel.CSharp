using RichillCapital.Extensions.Monads.UnitTests.Shared;

namespace RichillCapital.SharedKernel.Monads.UnitTests;

public sealed class ErrorOrTThenTests : MonadTests
{
    // [Fact]
    // public void Then_When_HasError_Should_NotInvokeFactory_And_ReturnErrorOrWithErrors()
    // {
    //     // Arrange & Act
    //     var errorOr = TestErrors
    //         .ToErrorOr<int>()
    //         .Then(FactoryWithValue);

    //     // Assert
    //     errorOr.ShouldBeErrors(TestErrors);
    // }

    // [Fact]
    // public void Then_When_HasValue_Should_InvokeFactory_And_ReturnErrorOrWithResultValue()
    // {
    //     // Arrange & Act
    //     var errorOr = TestValue
    //         .ToErrorOr()
    //         .Then(FactoryWithValue);

    //     // Assert
    //     errorOr.ShouldBeValue(FactoryWithValue(TestValue));
    // }

    // [Fact]
    // public void Then_When_HasError_Should_NotInvokeActionWithValue_And_ReturnErrorOrWithErrors()
    // {
    //     // Arrange & Act
    //     var errorOr = TestErrors
    //         .ToErrorOr<int>()
    //         .Then(SomeActionWithValue);

    //     // Assert
    //     errorOr.ShouldBeErrors(TestErrors);
    // }

    // [Fact]
    // public void Then_When_IsValue_Should_InvokeActionWithValue_And_ReturnErrorOrWithValue()
    // {
    //     // Arrange & Act
    //     var errorOr = TestValue
    //         .ToErrorOr()
    //         .Then(SomeActionWithValue);

    //     // Assert
    //     errorOr.ShouldBeValue(TestValue);
    // }

    // [Fact]
    // public async Task ThenAsync_When_HasError_Should_NotInvokeTask_And_ReturnErrorOrWithErrors()
    // {
    //     // Arrange & Act
    //     var errorOr = await TestErrors
    //         .ToErrorOr<int>()
    //         .Then(SomeAsyncTask);

    //     // Assert
    //     errorOr.ShouldBeErrors(TestErrors);
    // }

    // [Fact]
    // public async Task ThenAsync_When_IsValue_Should_InvokeTask_And_ReturnErrorOrWithValue()
    // {
    //     // Arrange & Act
    //     var errorOr = await TestValue
    //         .ToErrorOr()
    //         .Then(SomeAsyncTask);

    //     // Assert
    //     errorOr.ShouldBeValue(TestValue);
    // }

    // [Fact]
    // public async Task ThenAsync_When_ErrorOrTaskHasError_Should_NotInvokeFactory_And_ReturnErrorOrWithErrors()
    // {
    //     // Arrange & Act
    //     var errorOr = await ErrorOrTaskWithErrors()
    //         .Then(FactoryWithValue);

    //     // Assert
    //     errorOr.ShouldBeErrors(TestErrors);
    // }

    // [Fact]
    // public async Task ThenAsync_When_ErrorOrTaskIsValue_Should_InvokeFactory_And_ReturnErrorOrWithResultValue()
    // {
    //     // Arrange & Act
    //     var errorOr = await ErrorOrTaskWithValue()
    //         .Then(FactoryWithValue);

    //     // Assert
    //     errorOr.ShouldBeValue(FactoryWithValue(TestValue));
    // }
}