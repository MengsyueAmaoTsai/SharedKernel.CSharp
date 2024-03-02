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
}