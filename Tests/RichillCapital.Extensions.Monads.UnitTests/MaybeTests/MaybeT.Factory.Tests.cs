using RichillCapital.Extensions.Monads.UnitTests.Shared;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Extensions.Monads.UnitTests;

public sealed class MaybeTFactoryTests : MonadTests
{
    [Fact]
    public void Have_When_GivenValue_Should_CreateMaybeWithValue()
    {
        // Arrange & Act
        var maybe = Maybe<int>.Have(Value);

        // Assert
        maybe.ShouldBeHasValueWith(Value);
    }

    [Fact]
    public void Null_Should_CreateMaybeWithNoValue()
    {
        // Arrange & Act
        var maybe = Maybe<int>.Null;

        // Assert
        maybe.ShouldBeNull();
    }
}