using RichillCapital.Extensions.Monads.UnitTests.Shared;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Extensions.Monads.UnitTests;

public sealed class MaybeTThenTests : MonadTests
{
    [Fact]
    public void Then_When_IsNull_Should_NotInvokeFactory_And_ReturnNull()
    {
        // Arrange & Act
        var maybe = Maybe<int>.Null
            .Then(FactoryWithValue);

        // Assert
        maybe.ShouldBeNull();
    }

    [Fact]
    public void Then_When_HasValue_Should_InvokeFactory_And_ReturnMaybeWithValue()
    {
        // Arrange & Act
        var maybe = TestValue
            .ToMaybe()
            .Then(FactoryWithValue);

        // Assert
        maybe.ShouldBeHas(FactoryWithValue(TestValue));
    }

    [Fact]
    public void Then_When_IsNull_Should_NotInvokeActionWithValue_And_ReturnNull()
    {
        // Arrange & Act
        var maybe = Maybe<int>.Null
            .Then(SomeActionWithValue);

        // Assert
        maybe.ShouldBeNull();
    }

    [Fact]
    public void Then_When_HasValue_Should_InvokeActionWithValue_And_ReturnMaybeWithValue()
    {
        // Arrange & Act
        var maybe = TestValue
            .ToMaybe()
            .Then(SomeActionWithValue);

        // Assert
        maybe.ShouldBeHas(TestValue);
    }

    [Fact]
    public async Task ThenAsync_When_IsNull_Should_NotInvokeTask_And_ReturnNull()
    {
        // Arrange & Act
        var maybe = await Maybe<int>.Null
            .Then(SomeAsyncTask);

        // Assert
        maybe.ShouldBeNull();
    }

    [Fact]
    public async Task ThenAsync_When_HasValue_Should_InvokeTask_And_ReturnMaybeWithValue()
    {
        // Arrange & Act
        var maybe = await TestValue
            .ToMaybe()
            .Then(SomeAsyncTask);

        // Assert
        maybe.ShouldBeHas(TestValue);
    }

    [Fact]
    public async Task ThenAsync_When_IsNull_Should_NotInvokeFactory_And_ReturnNull()
    {
        // Arrange & Act
        var maybe = await MaybeTaskWithNull()
            .Then(FactoryWithValue);

        // Assert
        maybe.ShouldBeNull();
    }

    [Fact]
    public async Task ThenAsync_When_HasValue_Should_InvokeFactory_And_ReturnMaybeWithValue()
    {
        // Arrange & Act
        var maybe = await MaybeTaskWithValue()
            .Then(FactoryWithValue);

        // Assert
        maybe.ShouldBeHas(FactoryWithValue(TestValue));
    }
}