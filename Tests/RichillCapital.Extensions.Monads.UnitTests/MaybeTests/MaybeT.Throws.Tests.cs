using FluentAssertions;

using RichillCapital.Extensions.Monads.UnitTests.Shared;
using RichillCapital.SharedKernel.Diagnostics;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Extensions.Monads.UnitTests;

public sealed class MaybeTThrowsTests : MonadTests
{
    [Fact]
    public void ThrowIfNull_When_IsNullAndGivenError_Should_ThrowInvalidOperationWithMessageFromError()
    {
        // Arrange
        var action = () => Maybe<int>.Null
            .ThrowIfNull(UnexpectedError);

        action.Should().ThrowExactly<InvalidOperationException>()
            .WithMessage(UnexpectedError.Message);
    }

    [Fact]
    public void ThrowIfNull_When_HasValueAndGivenError_Should_NotThrow()
    {
        // Arrange
        var action = () => Value.ToMaybe().ThrowIfNull(UnexpectedError);

        // Assert
        action.Should().NotThrow();
    }
}