using RichillCapital.Extensions.Monads.UnitTests.Shared;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Extensions.Monads.UnitTests;

public sealed class MaybeTThenTests : MonadTests
{
    [Fact]
    public void Then_When_HasValue_Should_InvokeAction_And_ReturnOriginal()
    {
        // Arrange & Act
        var maybe = TestValue
            .ToMaybe()
            .Then(DoSomeAction);

        // Assert
        maybe.ShouldBeHas(TestValue);
    }

    [Fact]
    public void Then_When_IsNull_Should_NotInvokeAction_And_ReturnOriginal()
    {
        // Arrange & Act
        var maybe = Maybe<int>.Null
            .Then(DoSomeAction);

        // Assert
        maybe.ShouldBeNull();
    }

    [Fact]
    public void Then_When_HasValue_Should_InvokeActionWithValue_And_ReturnOriginal()
    {
        // Arrange & Act
        var maybe = TestValue
            .ToMaybe()
            .Then(DoSomeActionWithValue);

        // Assert
        maybe.ShouldBeHas(TestValue);
    }

    [Fact]
    public void Then_When_IsNull_Should_NotInvokeActionWithValue_And_ReturnOriginal()
    {
        // Arrange & Act
        var maybe = Maybe<int>.Null
            .Then(DoSomeActionWithValue);

        // Assert
        maybe.ShouldBeNull();
    }

    [Fact]
    public void Then_When_HasValue_Should_InvokeFactory_And_ReturnMaybeWithResultValue()
    {
        // Arrange & Act
        var maybe = TestValue
            .ToMaybe()
            .Then(ValueFactory);

        // Assert
        maybe.ShouldBeHas(TestValue * 2);
    }

    [Fact]
    public void Then_When_IsNull_Should_NotInvokeFactory_And_ReturnOriginal()
    {
        // Arrange & Act
        var maybe = Maybe<int>.Null
            .Then(ValueFactory);

        // Assert
        maybe.ShouldBeNull();
    }

    [Fact]
    public void Then_When_HasValue_Should_InvokeFactoryWithValue_And_ReturnMaybeWithResultValue()
    {
        // Arrange & Act
        var maybe = TestValue
            .ToMaybe()
            .Then(ValueFactoryWithValue);

        // Assert
        maybe.ShouldBeHas(TestValue * 2);
    }

    [Fact]
    public void Then_When_IsNull_Should_NotInvokeFactoryWithValue_And_ReturnOriginal()
    {
        // Arrange & Act
        var maybe = Maybe<int>.Null
            .Then(ValueFactoryWithValue);

        // Assert
        maybe.ShouldBeNull();
    }

    [Fact]
    public void Then_When_HasValue_Should_InvokeMaybeFactoryWithValue_And_ReturnMaybeWithResultValue()
    {
        // Arrange & Act
        var maybe = TestValue
            .ToMaybe()
            .Then(MaybeFactoryWithValue);

        // Assert
        maybe.ShouldBeHas(TestValue.ToString());
    }

    [Fact]
    public void Then_When_IsNull_Should_NotInvokeMaybeFactoryWithValue_And_ReturnOriginal()
    {
        // Arrange & Act
        var maybe = Maybe<int>.Null
            .Then(MaybeFactoryWithValue);

        // Assert
        maybe.ShouldBeNull();
    }

    [Fact]
    public async Task ThenAsync_When_IsNull_Should_NotInvokeFactoryWithValueTask_And_ReturnNull()
    {
        // Arrange & Act
        var maybe = await Maybe<int>.Null
            .Then(ValueFactoryWithValueTask);

        // Assert
        maybe.ShouldBeNull();
    }

    [Fact]
    public async Task ThenAsync_When_HasValue_Should_InvokeFactoryWithValueTask_And_ReturnMaybeWithResultValue()
    {
        // Arrange & Act
        var maybe = await TestValue
            .ToMaybe()
            .Then(ValueFactoryWithValueTask);

        // Assert
        maybe.ShouldBeHas(TestValue * 2);
    }

    [Fact]
    public async Task Then_When_HasValue_Should_InvokeMaybeFactoryWithValueTask_And_ReturnMaybeWithResultValue()
    {
        // Arrange & Act
        var maybe = await TestValue
            .ToMaybe()
            .Then(MaybeFactoryWithValueTask);

        // Assert
        maybe.ShouldBeHas(TestValue.ToString());
    }

    [Fact]
    public async Task Then_When_IsNull_Should_NotInvokeMaybeFactoryWithValueTask_And_ReturnOriginal()
    {
        // Arrange & Act
        var maybe = await Maybe<int>.Null
            .Then(MaybeFactoryWithValueTask);

        // Assert
        maybe.ShouldBeNull();
    }

    [Fact]
    public async Task ThenAsync_When_MaybeTaskHasValue_Should_InvokeFactoryWithValue_And_ReturnMaybeWithResultValue()
    {
        // Arrange & Act
        var maybe = await Task.FromResult(TestValue.ToMaybe())
            .Then(ValueFactoryWithValue);

        // Assert
        maybe.ShouldBeHas(TestValue * 2);
    }

    [Fact]
    public async Task ThenAsync_When_MaybeTaskIsNull_Should_NotInvokeFactoryWithValue_And_ReturnOriginal()
    {
        // Arrange & Act
        var maybe = await Task.FromResult(Maybe<int>.Null)
            .Then(ValueFactoryWithValue);

        // Assert
        maybe.ShouldBeNull();
    }

    [Fact]
    public async Task ThenAsync_When_IsNull_Should_NotInvokeResultFactoryWithValueTask_And_ReturnNull()
    {
        // Arrange & Act
        var maybe = await Maybe<int>.Null
            .Then(ResultFactoryWithValueTask);

        // Assert
        maybe.ShouldBeNull();
    }

    [Fact]
    public async Task ThenAsync_When_HasValue_And_ResultTaskIsFailure_Should_InvokeResultFactoryWithValueTask_And_ReturnNull()
    {
        // Arrange & Act
        var maybe = await TestValue
            .ToMaybe()
            .Then(ResultFactoryWithValueTask_IsFailure);

        // Assert
        maybe.ShouldBeNull();
    }

    [Fact]
    public async Task ThenAsync_When_HasValue_And_ResultTaskIsSuccess_Should_InvokeFactoryWithValue_And_ReturnMaybeWithResultValue()
    {
        // Arrange & Act
        var maybe = await TestValue
            .ToMaybe()
            .Then(ResultFactoryWithValueTask);

        // Assert
        maybe.ShouldBeHas(TestValue.ToString());
    }

    [Fact]
    public async Task ThenAsync_When_IsNull_Should_NotInvokeErrorOrFactoryWithValueTask_And_ReturnNull()
    {
        // Arrange & Act
        var maybe = await Maybe<int>.Null
            .Then(ErrorOrFactoryWithValueTask);

        // Assert
        maybe.ShouldBeNull();
    }

    [Fact]
    public async Task ThenAsync_When_HasValue_And_ErrorOrTaskHasError_Should_InvokeErrorOrFactoryWithValueTask_And_ReturnNull()
    {
        // Arrange & Act
        var maybe = await TestValue
            .ToMaybe()
            .Then(ErrorOrFactoryWithValueTask_HasError);

        // Assert
        maybe.ShouldBeNull();
    }

    [Fact]
    public async Task ThenAsync_When_HasValue_And_ErrorOrTaskIsValue_Should_InvokeErrorOrFactoryWithValueTask_And_ReturnMaybeWithResultValue()
    {
        // Arrange & Act
        var maybe = await TestValue
            .ToMaybe()
            .Then(ErrorOrFactoryWithValueTask);

        // Assert
        maybe.ShouldBeHas(TestValue.ToString());
    }
}