using FluentAssertions;

using RichillCapital.Extensions.Monads.UnitTests.Shared;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Extensions.Monads.UnitTests;

public sealed class MaybeTTests : MonadTests
{
    [Fact]
    public void HasValue_When_HasValue_Should_ReturnTrue()
    {
        // Arrange
        var maybe = Maybe<int>.Have(1);

        // Act & Assert
        maybe.HasValue.Should().BeTrue();
    }

    [Fact]
    public void HasValue_When_IsNull_Should_ReturnFalse()
    {
        // Arrange
        var maybe = Maybe<int>.Null;

        // Act & Assert
        maybe.HasValue.Should().BeFalse();
    }

    [Fact]
    public void IsNull_When_HasValue_Should_ReturnFalse()
    {
        // Arrange
        var maybe = Maybe<int>.Have(1);

        // Act & Assert
        maybe.IsNull.Should().BeFalse();
    }

    [Fact]
    public void IsNull_When_IsNull_Should_ReturnTrue()
    {
        // Arrange
        var maybe = Maybe<int>.Null;

        // Act & Assert
        maybe.IsNull.Should().BeTrue();
    }

    [Fact]
    public void Value_When_HasValue_Should_ReturnValue()
    {
        // Arrange
        var maybe = Maybe<int>.Have(1);

        // Act & Assert
        maybe.Value.Should().Be(1);
    }

    [Fact]
    public void Value_When_IsNull_Should_ThrowInvalidOperationException()
    {
        // Arrange
        var maybe = Maybe<int>.Null;

        // Act
        Action act = () => _ = maybe.Value;

        // Assert
        act.Should().Throw<InvalidOperationException>();
    }

    [Fact]
    public void ValueOrDefault_When_HasValue_Should_ReturnValue()
    {
        // Arrange
        var maybe = Maybe<int>.Have(1);

        // Act & Assert
        maybe.ValueOrDefault.Should().Be(1);
    }

    [Fact]
    public void ValueOrDefault_When_IsNull_Should_ReturnDefault()
    {
        // Arrange
        var maybe = Maybe<int>.Null;

        // Act & Assert
        maybe.ValueOrDefault.Should().Be(default);
    }
}