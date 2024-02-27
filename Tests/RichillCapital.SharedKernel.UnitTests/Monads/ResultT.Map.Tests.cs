using FluentAssertions;

using RichillCapital.SharedKernel.Monads;
using RichillCapital.SharedKernel.UnitTests.Monads.Common;

namespace RichillCapital.SharedKernel.UnitTests.Monads;

public sealed partial class GenericResultTests : MonadTests
{
    [Fact]
    public void Map_When_ResultIsSuccess_Should_MapsValue()
    {
        // Arrange & Act
        var result = Result<int>
            .Success(IntValue)
            .Map(value => value * 2);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be(IntValue * 2);
    }

    [Fact]
    public void Map_When_ResultIsFailure_ShouldNot_MapValue()
    {
        // Arrange & Act
        var result = Result<int>
            .Failure(NotFoundError)
            .Map(value => value * 2);

        // Assert
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(NotFoundError);
    }

    [Fact]
    public void Map_When_ResultTaskIsSuccess_Should_MapsValue()
    {
        // Arrange & Act
        var result = Task.FromResult(Result<int>
            .Success(IntValue))
            .Map(value => value * 2);

        // Assert
        result.Result.IsSuccess.Should().BeTrue();
        result.Result.Value.Should().Be(IntValue * 2);
    }

    [Fact]
    public void Map_When_ResultTaskIsFailure_ShouldNot_MapValue()
    {
        // Arrange & Act
        var result = Task.FromResult(Result<int>
            .Failure(NotFoundError))
            .Map(value => value * 2);

        // Assert
        result.Result.IsFailure.Should().BeTrue();
        result.Result.Error.Should().Be(NotFoundError);
    }
}