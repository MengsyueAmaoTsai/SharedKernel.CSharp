using FluentAssertions;

using RichillCapital.SharedKernel.Monads;
using RichillCapital.SharedKernel.UnitTests.Monads.Common;

namespace RichillCapital.SharedKernel.UnitTests.Monads;

public sealed partial class GenericMaybeTests : MonadTests
{
    [Fact]
    public void Value_When_MaybeHasValue_Should_ReturnValue()
    {
        // Arrange
        var maybeInt = Maybe<int>.Have(IntValue);

        // Act
        var value = maybeInt.Value;

        // Assert
        value.Should().Be(IntValue);
    }

    [Fact]
    public void Value_When_MaybeHasNoValue_Should_ThrowInvalidOperationException()
    {
        // Arrange
        var maybeInt = Maybe<int>.Null;

        // Act
        Action act = () => _ = maybeInt.Value;

        // Assert
        act.Should().Throw<InvalidOperationException>()
            .WithMessage($"Maybe<{typeof(int)}> is not value");
    }

    [Fact]
    public void ValueOrDefault_When_MaybeHasValue_Should_ReturnValue()
    {
        // Arrange
        var maybeInt = Maybe<int>.Have(IntValue);

        // Act
        var value = maybeInt.ValueOrDefault;

        // Assert
        value.Should().Be(IntValue);
    }

    [Fact]
    public void ValueOrDefault_When_MaybeHasNoValue_Should_ReturnDefaultValue()
    {
        // Arrange
        var maybeInt = Maybe<int>.Null;

        // Act
        var value = maybeInt.ValueOrDefault;

        // Assert
        value.Should().Be(default);
    }
}