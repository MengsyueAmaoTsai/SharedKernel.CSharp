using FluentAssertions;

using RichillCapital.SharedKernel.Monad;

namespace RichillCapital.SharedKernel.UnitTests.Monad;

public sealed class MaybeTests
{
    [Fact]
    public void From_Should_CreateMaybeWithValue()
    {
        // Arrange
        var value = 1;

        // Act
        var maybe = Maybe<int>.From(value);
        var maybe2 = Maybe.From(value);

        // Assert
        maybe.HasValue.Should().BeTrue();
        maybe.Value.Should().Be(value);
        maybe2.HasValue.Should().BeTrue();
        maybe2.Value.Should().Be(value);
    }

    [Fact]
    public void Null_Should_CreateMaybeWithNoValue()
    {
        // Arrange
        var maybe = Maybe<int>.Null;

        // Act
        var hasValue = maybe.HasValue;

        // Assert
        hasValue.Should().BeFalse();
    }
}