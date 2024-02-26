using FluentAssertions;

using RichillCapital.SharedKernel.Monads;
using RichillCapital.SharedKernel.UnitTests.Monads.Common;

namespace RichillCapital.SharedKernel.UnitTests.Monads;

public sealed partial class GenericErrorOrTests : MonadTests
{
    [Fact]
    public void Map_When_ErrorOrIsValue_Should_MapsValue()
    {
        // Arrange & Act
        var errorOr = ErrorOr<int>
            .Is(IntValue)
            .Map(value => value * 2);

        // Assert
        errorOr.IsValue.Should().BeTrue();
        errorOr.Value.Should().Be(IntValue * 2);
    }

    [Fact]
    public void Map_When_ErrorOrIsError_ShouldNot_MapValue()
    {
        // Arrange & Act
        var errorOr = ErrorOr<int>
            .Is(NotFoundError)
            .Map(value => value * 2);

        // Assert
        errorOr.IsError.Should().BeTrue();
        errorOr.Errors.Should().BeEquivalentTo([NotFoundError]);
    }

    [Fact]
    public void Map_When_ErrorOrTaskIsValue_Should_MapsValue()
    {
        // Arrange & Act
        var errorOr = Task.FromResult(ErrorOr<int>
            .Is(IntValue))
            .Map(value => value * 2);

        // Assert
        errorOr.Result.IsValue.Should().BeTrue();
        errorOr.Result.Value.Should().Be(IntValue * 2);
    }

    [Fact]
    public void Map_When_ErrorOrTaskIsError_ShouldNot_MapValue()
    {
        // Arrange & Act
        var errorOr = Task.FromResult(ErrorOr<int>
            .Is(NotFoundError))
            .Map(value => value * 2);

        // Assert
        errorOr.Result.IsError.Should().BeTrue();
        errorOr.Result.Errors.Should().BeEquivalentTo([NotFoundError]);
    }
}