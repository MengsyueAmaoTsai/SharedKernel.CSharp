using FluentAssertions;

using RichillCapital.SharedKernel.Monads;
using RichillCapital.SharedKernel.UnitTests.Monads.Common;

namespace RichillCapital.SharedKernel.UnitTests;

public sealed partial class GenericMaybeTests : MonadTests
{
    [Fact]
    public void OrElse_When_MaybeHasValue_Should_ReturnMaybeWithValue()
    {
        // Arrange & Act
        var expected = IntValue;

        Maybe<int> maybeInt = Maybe<int>
            .Have(IntValue)
            .OrElse(50);

        // Assert
        maybeInt.HasValue.Should().BeTrue();
        maybeInt.Value.Should().Be(expected);
        maybeInt.ValueOrDefault.Should().Be(expected);
    }

    [Fact]
    public void OrElse_When_MaybeHasNoValue_Should_ReturnMaybeWithElseValue()
    {
        // Arrange & Act
        var expected = 50;

        Maybe<int> maybeInt = Maybe<int>
            .Null
            .OrElse(expected);

        // Assert
        maybeInt.HasValue.Should().BeTrue();
        maybeInt.Value.Should().Be(expected);
        maybeInt.ValueOrDefault.Should().Be(expected);
    }
}