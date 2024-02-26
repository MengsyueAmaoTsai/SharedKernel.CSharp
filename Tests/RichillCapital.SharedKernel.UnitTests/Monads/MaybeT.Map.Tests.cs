using FluentAssertions;

using RichillCapital.SharedKernel.Monads;
using RichillCapital.SharedKernel.UnitTests.Monads.Common;

namespace RichillCapital.SharedKernel.UnitTests.Monads;

public sealed partial class GenericMaybeTests : MonadTests
{
    [Fact]
    public void Map_When_MaybeHasValue_Should_MapsValue()
    {
        // Arrange & Act
        var maybe = Maybe<int>
            .Have(IntValue)
            .Map(value => value * 2);

        // Assert
        maybe.HasValue.Should().BeTrue();
        maybe.Value.Should().Be(IntValue * 2);
    }

    [Fact]
    public void Map_When_MaybeHasNoValue_ShouldNot_MapValue()
    {
        // Arrange & Act
        var maybe = Maybe<int>
            .Null
            .Map(value => value * 2);

        // Assert
        maybe.HasNoValue.Should().BeTrue();
    }

    [Fact]
    public void Map_When_MaybeTaskHasValue_Should_MapsValue()
    {
        // Arrange & Act
        var maybe = Task.FromResult(Maybe<int>
            .Have(IntValue))
            .Map(value => value * 2);

        // Assert
        maybe.Result.HasValue.Should().BeTrue();
        maybe.Result.Value.Should().Be(IntValue * 2);
    }

    [Fact]
    public void Map_When_MaybeTaskHasNoValue_ShouldNot_MapValue()
    {
        // Arrange & Act
        var maybe = Task.FromResult(Maybe<int>
            .Null)
            .Map(value => value * 2);

        // Assert
        maybe.Result.HasNoValue.Should().BeTrue();
    }
}