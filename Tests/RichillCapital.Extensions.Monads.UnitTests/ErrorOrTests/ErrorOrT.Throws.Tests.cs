using FluentAssertions;

using RichillCapital.Extensions.Monads.UnitTests.Shared;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Extensions.Monads.UnitTests;

public sealed class ErrorOrTThrowsTests : MonadTests
{
    [Fact]
    public void ThrowIfError_When_IsError_Should_ThrowInvalidOperationWithMessageFromError()
    {
        // Arrange
        var action = () => UnexpectedError.ToErrorOr<int>()
            .ThrowIfError();

        action
            .Should().ThrowExactly<InvalidOperationException>()
            .WithMessage(UnexpectedError.Message);
    }

    [Fact]
    public void ThrowIfError_When_IsValue_Should_NotThrow()
    {
        // Arrange
        var action = () => Value.ToErrorOr().ThrowIfError();

        // Assert
        action.Should().NotThrow();
    }
}