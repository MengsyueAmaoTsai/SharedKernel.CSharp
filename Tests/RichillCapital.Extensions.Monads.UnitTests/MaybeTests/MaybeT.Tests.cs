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
}