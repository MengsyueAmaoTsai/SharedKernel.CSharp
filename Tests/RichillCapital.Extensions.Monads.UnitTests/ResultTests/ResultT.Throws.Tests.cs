using FluentAssertions;

using RichillCapital.Extensions.Monads.UnitTests.Shared;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Extensions.Monads.UnitTests;

public sealed class ResultTThrowsTests : MonadTests
{
    [Fact]
    public void ThrowIfFailure_When_IsFailure_Should_ThrowInvalidOperationWithMessageFromError()
    {
        // Arrange
        var action = () => UnexpectedError.ToResult<int>()
            .ThrowIfFailure();

        action
            .Should().ThrowExactly<InvalidOperationException>()
            .WithMessage(UnexpectedError.Message);
    }

    [Fact]
    public void ThrowIfFailure_When_IsSuccess_Should_NotThrow()
    {
        // Arrange
        var action = () => Value.ToResult().ThrowIfFailure();

        // Assert
        action.Should().NotThrow();
    }
}