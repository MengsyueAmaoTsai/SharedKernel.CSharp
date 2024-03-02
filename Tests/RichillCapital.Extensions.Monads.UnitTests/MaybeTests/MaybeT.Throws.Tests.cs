using FluentAssertions;

using RichillCapital.Extensions.Monads.UnitTests.Shared;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Extensions.Monads.UnitTests;

public sealed class MaybeTThrowsTests : MonadTests
{
    private const string DefaultMessage = "Maybe<System.Int32> is null.";

    [Fact]
    public void ThrowIfNull_When_IsNull_Should_ThrowInvalidOperationExceptionWithDefaultMessage()
    {
        // Arrange
        Action act = () => Maybe<int>.Null.ThrowIfNull();

        // Act & Assert
        act.Should().Throw<InvalidOperationException>()
            .WithMessage(DefaultMessage);
    }

    [Fact]
    public void ThrowIfNull_When_HasValue_Should_NotThrowAnyExceptions()
    {
        // Arrange
        var maybe = 1.ToMaybe();
        Action act = () => maybe.ThrowIfNull();

        // Act & Assert
        act.Should().NotThrow();
    }

    [Fact]
    public async Task ThrowIfNullAsync_When_MaybeTaskIsNull_Should_ThrowInvalidOperationExceptionWithDefaultMessage()
    {
        // Arrange
        var maybeTask = Task.FromResult(Maybe<int>.Null);
        Func<Task> act = async () => await maybeTask.ThrowIfNull();

        // Act & Assert
        await act.Should().ThrowAsync<InvalidOperationException>()
            .WithMessage(DefaultMessage);
    }

    [Fact]
    public async Task ThrowIfNullAsync_When_MaybeTaskHasValue_Should_NotThrowAnyExceptions()
    {
        // Arrange
        var maybeTask = Task.FromResult(1.ToMaybe());
        Func<Task> act = async () => await maybeTask.ThrowIfNull();

        // Act & Assert
        await act.Should().NotThrowAsync();
    }
}