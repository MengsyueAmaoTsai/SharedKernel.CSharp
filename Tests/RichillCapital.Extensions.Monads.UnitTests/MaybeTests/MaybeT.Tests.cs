using FluentAssertions;

using RichillCapital.Extensions.Monads.UnitTests.Shared;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Extensions.Monads.UnitTests;

public sealed class MaybeTTests : MonadTests
{
    [Fact]
    public void Equals_When_GivenTwoNullMaybesWithDifferenceTypes_Should_ReturnFalse()
    {
        // Arrange
        var maybe1 = Maybe<int>.Null;
        var maybe2 = Maybe<string>.Null;

        // Act
        var result = maybe1.Equals(maybe2);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void Equals_When_GivenTwoNullMaybesWithSameTypes_Should_ReturnTrue()
    {
        // Arrange
        var maybe1 = Maybe<int>.Null;
        var maybe2 = Maybe<int>.Null;

        // Act
        var result = maybe1.Equals(maybe2);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void Equals_When_GivenTwoMaybesWithSameValues_Should_ReturnTrue()
    {
        // Arrange
        var maybe1 = Maybe<int>.With(TestValue);
        var maybe2 = Maybe<int>.With(TestValue);

        // Act
        var result = maybe1.Equals(maybe2);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void Equals_When_GivenTwoMaybesWithDifferentValues_Should_ReturnFalse()
    {
        // Arrange
        var maybe1 = Maybe<int>.With(TestValue);
        var maybe2 = Maybe<int>.With(TestValue + 1);

        // Act
        var result = maybe1.Equals(maybe2);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void Null_Should_ReturnNullMaybe()
    {
        // Arrange & Act
        var maybe = Maybe<int>.Null;

        // Assert
        maybe.ShouldBeNull();
    }

    [Fact]
    public void Value_When_IsNull_Should_ThrowInvalidOperationException()
    {
        // Arrange
        var maybe = Maybe<int>.Null;

        // Act
        Action action = () => _ = maybe.Value;

        // Assert
        action.Should().Throw<InvalidOperationException>()
            .WithMessage($"Maybe<{typeof(int)}> is not value");
    }

    [Fact]
    public void Value_When_IsNotNull_Should_ReturnValue()
    {
        // Arrange
        var maybe = Maybe<int>.With(TestValue);

        // Act
        maybe.Value.Should().Be(TestValue);
    }

    [Fact]
    public void ValueOrDefault_When_IsNull_Should_ReturnDefault()
    {
        // Arrange
        var maybeInt = Maybe<int>.Null;
        var maybeString = Maybe<string>.Null;

        // Act
        maybeInt.ValueOrDefault.Should().Be(0);
        maybeString.ValueOrDefault.Should().BeNull();
    }

    [Fact]
    public void ValueOrDefault_When_IsNotNull_Should_ReturnValue()
    {
        // Arrange
        var maybe = Maybe<int>.With(TestValue);

        // Act
        maybe.ValueOrDefault.Should().Be(TestValue);
    }
}