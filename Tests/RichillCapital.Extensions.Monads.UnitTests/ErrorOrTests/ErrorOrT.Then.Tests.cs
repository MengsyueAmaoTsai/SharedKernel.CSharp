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
}