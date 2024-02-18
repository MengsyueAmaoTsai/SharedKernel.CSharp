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

    [Fact]
    public void ImplicitConversion_Should_CreateMaybeWithValue()
    {
        // Arrange
        var value = 1;

        // Act
        Maybe<int> maybe = value;
        Maybe<int> maybe2 = value;

        // Assert
        maybe.HasValue.Should().BeTrue();
        maybe.Value.Should().Be(value);
        maybe2.HasValue.Should().BeTrue();
        maybe2.Value.Should().Be(value);
    }

    [Fact]
    public void ImplicitConversion_Should_ConvertMaybeToValue()
    {
        // Arrange
        var value = 1;
        var maybe = Maybe<int>.From(value);

        // Act
        int converted = maybe;

        // Assert
        converted.Should().Be(value);
    }
}