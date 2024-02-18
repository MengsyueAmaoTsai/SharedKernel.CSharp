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

    [Fact]
    public void ThrowIfFailure_Should_ThrowException_When_ResultIsFailure()
    {
        // Arrange
        Result result = Error.Invalid("Error message");
        Result<int> result2 = Error.Invalid("Error message");

        // Act
        Action action = () => result.ThrowIfFailure();
        Action action2 = () => result2.ThrowIfFailure();

        // Assert
        action.Should()
            .Throw<InvalidOperationException>()
            .WithMessage("Error message");


        action2.Should()
            .Throw<InvalidOperationException>()
            .WithMessage("Error message");
    }
}