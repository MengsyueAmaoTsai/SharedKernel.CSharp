using RichillCapital.Extensions.Monads.UnitTests.Shared;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Extensions.Monads.UnitTests;

public sealed class MaybeTEnsureTests : MonadTests
{
    [Fact]
    public void EnsureFactory_When_EnsureFailure_Should_CreateMaybeNull()
    {
        // Arrange & Act
        var maybe = Maybe<int>.Ensure(3, value => value == 4);

        // Assert
        maybe.ShouldBeNull();
    }

    [Fact]
    public void EnsureFactory_When_EnsureSuccess_Should_CreateMaybeWithValue()
    {
        // Arrange & Act
        var maybe = Maybe<int>.Ensure(3, value => value == 3);

        // Assert
        maybe.ShouldBeHasValueWith(3);
    }

    [Fact]
    public void EnsureFactory_When_AnyFailure_Should_CreateMaybeNull()
    {
        // Arrange & Act
        var maybe = Maybe<int>.Ensure(
            Value,
            value => value == 10,
            value => value == 20,
            value => value == 30);

        // Assert
        maybe.ShouldBeNull();
    }

    [Fact]
    public void EnsureFactory_When_NoFailure_Should_CreateMaybeWithValue()
    {
        // Arrange & Act
        var maybe = Maybe<int>.Ensure(
            Value,
            value => value == 5,
            value => value < 10,
            value => value > 0,
            value => value <= 5);

        // Assert
        maybe.ShouldBeHasValueWith(Value);
    }
}