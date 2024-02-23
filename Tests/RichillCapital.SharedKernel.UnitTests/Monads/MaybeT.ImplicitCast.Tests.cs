using FluentAssertions;

using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.SharedKernel.UnitTests.Monads;

public sealed partial class GenericMaybeTests : MonadTests
{
    [Fact]
    public void ImplicitCast_When_GivenPrimitiveValue_Should_ReturnMaybeWithValue()
    {
        // Arrange & Act
        Maybe<int> maybeInt = IntValue;

        // Assert
        maybeInt.HasValue.Should().BeTrue();
        maybeInt.HasNoValue.Should().BeFalse();
        maybeInt.Value.Should().Be(IntValue);
    }
}