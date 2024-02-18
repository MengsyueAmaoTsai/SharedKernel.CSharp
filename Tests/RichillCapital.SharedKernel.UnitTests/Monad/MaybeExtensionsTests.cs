using FluentAssertions;

using RichillCapital.SharedKernel.Monad;

namespace RichillCapital.SharedKernel.UnitTests.Monad;

public sealed class MaybeExtensionsTests
{
    [Fact]
    public void Map_Should_MapValue_WhenMaybeHasValue()
    {
        // Arrange
        var maybe = Maybe<int>.From(1);

        // Act
        var mapped = maybe.Map(x => x + 1);

        // Assert
        mapped.HasValue.Should().BeTrue();
        mapped.Value.Should().Be(2);
    }

    [Fact]
    public void Map_Should_ReturnNoValue_WhenMaybeHasNoValue()
    {
        // Arrange
        var maybe = Maybe<int>.Null;

        // Act
        var mapped = maybe.Map(x => x + 1);

        // Assert
        mapped.HasValue.Should().BeFalse();
    }

    [Fact]
    public void ThrowIfNoValue_Should_ThrowException_WhenMaybeHasNoValue()
    {
        // Arrange
        var maybe = Maybe<int>.Null;

        // Act
        Action action = () => maybe.ThrowIfNoValue();

        // Assert
        action.Should().Throw<InvalidOperationException>();
    }
}