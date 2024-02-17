using FluentAssertions;

using RichillCapital.SharedKernel.Monad;

namespace RichillCapital.SharedKernel.UnitTests.Monad;

public sealed class ResultExtensionsTests
{
    [Fact]
    public void Map_Should_MapSuccessResult()
    {
        // Arrange
        var result = Result.From(1);

        // Act
        var mappedResult = result.Map(x => x.ToString());

        // Assert
        mappedResult.IsSuccess.Should().BeTrue();
        mappedResult.Value.Should().Be("1");
    }

    [Fact]
    public void Map_ShouldNot_MapFailureResult()
    {
        // Arrange
        Result<int> result = Error.Invalid("Error message");

        // Act
        var mappedResult = result.Map(x => x.ToString());

        // Assert
        mappedResult.IsFailure.Should().BeTrue();
        mappedResult.Error.Message.Should().Be("Error message");
    }
}