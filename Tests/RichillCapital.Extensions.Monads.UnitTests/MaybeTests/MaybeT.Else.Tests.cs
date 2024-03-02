using RichillCapital.Extensions.Monads.UnitTests.Shared;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Extensions.Monads.UnitTests;

public sealed class MaybeTElseTests : MonadTests
{
    [Fact]
    public void Else_When_IsNull_Should_ReturnElseValue()
    {
        // Arrange & Act
        var maybe = Maybe<int>.Null
            .Else(TestValue);

        // Assert
        maybe.ShouldBeHas(TestValue);
    }

    [Fact]
    public void Else_When_HasValue_Should_ReturnOriginal()
    {
        // Arrange & Act
        var maybe = TestValue.ToMaybe()
            .Else(0);

        // Assert
        maybe.ShouldBeHas(TestValue);
    }
}