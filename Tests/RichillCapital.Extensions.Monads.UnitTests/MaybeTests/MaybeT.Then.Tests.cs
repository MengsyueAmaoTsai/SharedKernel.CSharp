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
            .Then(MapValueToResult);

        // Assert
        maybe.ShouldBeNull();
    }

    [Fact]
    public void Then_When_HasValue_Should_InvokeFactory_And_ReturnMaybeWithValue()
    {
        // Arrange & Act
        var maybe = TestValue
            .ToMaybe()
            .Then(MapValueToResult);

        // Assert
        maybe.ShouldBeHas(MapValueToResult(TestValue));
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
}