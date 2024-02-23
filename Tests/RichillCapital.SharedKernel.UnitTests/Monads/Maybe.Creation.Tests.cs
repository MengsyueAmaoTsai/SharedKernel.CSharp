using FluentAssertions;

using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.SharedKernel.UnitTests.Monads;

public sealed partial class MaybeTests : MonadTests
{
    [Fact]
    public void With_When_GivenPrimitiveValue_Should_CreateMaybeWithValue()
    {
        // Arrange & Act
        var maybeInt = Maybe.With(IntValue);

        // Assert
        maybeInt.HasValue.Should().BeTrue();
        maybeInt.HasNoValue.Should().BeFalse();
        maybeInt.Value.Should().Be(IntValue);
    }
}