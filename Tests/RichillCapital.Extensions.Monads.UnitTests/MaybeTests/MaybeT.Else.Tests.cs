using RichillCapital.Extensions.Monads.UnitTests.Shared;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Extensions.Monads.UnitTests;

public sealed class MaybeTElseTests : MonadTests
{
    [Fact]
    public void Else_When_IsSuccess_Should_ReturnMaybeWithOriginalValue()
    {
        // Arrange & Act
        var maybe = Value
            .ToMaybe()
            .Else(10);

        // Assert
        maybe.ShouldBeHasValueWith(Value);
    }

    [Fact]
    public void Else_When_IsNull_Should_ReturnMaybeWithElseValue()
    {
        // Arrange & Act
        var expectedValue = 10;
        var maybe = Maybe<int>.Null
            .Else(expectedValue);

        // Assert
        maybe.ShouldBeHasValueWith(expectedValue);
    }
}