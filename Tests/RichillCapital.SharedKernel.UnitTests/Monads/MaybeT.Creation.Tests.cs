using FluentAssertions;

using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.SharedKernel.UnitTests.Monads;

public sealed partial class GenericMaybeTests : MonadTests
{
    [Fact]
    public void With_When_GivenPrimitiveValue_Should_CreateMaybeWithValue()
    {
        // Arrange & Act
        var maybeInt = Maybe<int>.With(IntValue);

        // Assert
        maybeInt.HasValue.Should().BeTrue();
        maybeInt.HasNoValue.Should().BeFalse();
        maybeInt.Value.Should().Be(IntValue);
    }
}