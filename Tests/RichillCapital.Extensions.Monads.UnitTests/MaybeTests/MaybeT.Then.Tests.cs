using FluentAssertions;

using RichillCapital.Extensions.Monads.UnitTests.Shared;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Extensions.Monads.UnitTests;

public sealed class MaybeTThenTests : MonadTests
{
    [Fact]
    public void Then_When_IsNull_Should_NotInvokeResultFactoryWithValue_And_ReturnMaybeWithNull()
    {
        // Arrange & Act
        var maybe = Maybe<int>.Null
            .Then(value => value.ToString());

        // Assert
        maybe.ShouldBeNull();
    }

    [Fact]
    public void Then_When_IsValue_Should_InvokeResultFactoryWithValue_And_ReturnMaybeWithValue()
    {
        // Arrange & Act
        var maybe = Value.ToMaybe()
            .Then(value => value.ToString());

        // Assert
        maybe.ShouldBeHasValueWith(Value.ToString());
    }

    [Fact]
    public void Then_When_IsNull_Should_NotInvokeResultFactory_And_ReturnMaybeWithNull()
    {
        // Arrange & Act
        var maybe = Maybe<int>.Null
            .Then(() => 1);

        // Assert
        maybe.ShouldBeNull();
    }

    [Fact]
    public void Then_When_IsNull_Should_NotInvokeActionWithValue_And_ReturnNullMaybe()
    {
        // Arrange & Act
        var maybe = Maybe<int>.Null
            .Then(value => throw new InvalidOperationException());

        // Assert   
        maybe.ShouldBeNull();
    }

    [Fact]
    public void Then_When_IsValue_Should_InvokeResultFactory_And_ReturnMaybeWithValue()
    {
        // Arrange & Act
        var maybe = Value.ToMaybe()
            .Then(() => 1);

        // Assert
        maybe.ShouldBeHasValueWith(1);
    }

    [Fact]
    public void Then_When_IsValue_Should_InvokeActionWithValue_And_ReturnMaybeWithValue()
    {
        // Arrange
        var actionInvoked = false;

        // Act
        Value.ToMaybe()
            .Then(value => actionInvoked = true);

        // Assert
        actionInvoked.Should().BeTrue();
    }
}