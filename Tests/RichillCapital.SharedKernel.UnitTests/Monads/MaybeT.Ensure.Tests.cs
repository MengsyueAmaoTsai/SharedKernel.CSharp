using FluentAssertions;

using RichillCapital.SharedKernel.Monads;
using RichillCapital.SharedKernel.UnitTests.Monads.Common;

namespace RichillCapital.SharedKernel.UnitTests.Monads;

public sealed partial class GenericMaybeTests : MonadTests
{
    [Fact]
    public void Ensure_When_PredicateIsFalse_Should_ReturnNoValueMaybe()
    {
        // Arrange 
        Maybe<int> maybe = Maybe<int>
            .Have(IntValue)
            .Ensure(value => value < 10);

        // Assert
        maybe.HasNoValue.Should().BeTrue();
    }

    [Fact]
    public void Ensure_When_PredicateIsTrue_Should_ReturnMaybeWithAValue()
    {
        // Arrange 
        Maybe<int> maybe = Maybe<int>
            .Have(IntValue)
            .Ensure(value => value >= 10);

        // Assert
        maybe.HasValue.Should().BeTrue();
        maybe.Value.Should().Be(IntValue);
    }

    [Fact]
    public void EnsureFactory_When_PredicateIsTrue_Should_ReturnMaybeWithAValue()
    {
        // Arrange 
        var maybe = Maybe<int>
            .Ensure(IntValue, value => value >= 10);

        // Assert
        maybe.HasValue.Should().BeTrue();
    }

    [Fact]
    public void EnsureFactory_When_PredicateIsFalse_Should_ReturnNoValueMaybe()
    {
        // Arrange 
        var maybe = Maybe<int>
            .Ensure(IntValue, value => value < 10);

        // Assert
        maybe.HasNoValue.Should().BeTrue();
    }
}