using FluentAssertions;

using RichillCapital.SharedKernel.Monads;
using RichillCapital.SharedKernel.UnitTests.Monads.Common;

namespace RichillCapital.SharedKernel.UnitTests.Monads;

public sealed partial class GenericMaybeTests : MonadTests
{
    [Fact]
    public void Ensure_When_PredicateIsFalse_Should_ReturnMaybeWithNoValue()
    {
        // Arrange
        Maybe<int> maybeInt = Maybe<int>
            .Have(IntValue)
            .Ensure(value => value < 10);

        // Assert
        maybeInt.HasValue.Should().BeFalse();
    }

    [Fact]
    public void Ensure_When_PredicateIsTrue_Should_ReturnMaybeWithValue()
    {
        // Arrange
        Maybe<int> maybeInt = Maybe<int>
            .Have(IntValue)
            .Ensure(value => value >= 10);

        // Assert
        maybeInt.HasValue.Should().BeTrue();
        maybeInt.Value.Should().Be(IntValue);
    }
}