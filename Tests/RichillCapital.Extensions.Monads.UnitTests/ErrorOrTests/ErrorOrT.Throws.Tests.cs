using FluentAssertions;

using RichillCapital.Extensions.Monads.UnitTests.Shared;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Extensions.Monads.UnitTests;

public sealed class ErrorOrTThrowsTests : MonadTests
{
    [Fact]
    public void ThrowIfError_When_HasError_Should_ThrowInvalidOperationExceptionWithErrorMessage()
    {
        // Arrange
        var errorOr = TestError.ToErrorOr<int>();
        Action act = () => errorOr.ThrowIfError();

        // Act & Assert
        act.Should().Throw<InvalidOperationException>()
            .WithMessage(TestError.Message);
    }

    [Fact]
    public void ThrowIfError_When_IsValue_Should_NotThrowAnyExceptions()
    {
        // Arrange
        var errorOr = 1.ToErrorOr();
        Action act = () => errorOr.ThrowIfError();

        // Act & Assert
        act.Should().NotThrow();
    }

    [Fact]
    public async Task ThrowIfErrorAsync_When_ErrorOrTaskHasError_Should_ThrowInvalidOperationExceptionWithErrorMessage()
    {
        // Arrange
        var errorOrTask = Task.FromResult(TestError.ToErrorOr<int>());
        Func<Task> act = async () => await errorOrTask.ThrowIfError();

        // Act & Assert
        await act.Should().ThrowAsync<InvalidOperationException>()
            .WithMessage(TestError.Message);
    }

    [Fact]
    public async Task ThrowIfErrorAsync_When_ErrorOrTaskIsValue_Should_NotThrowAnyExceptions()
    {
        // Arrange
        var errorOrTask = Task.FromResult(1.ToErrorOr());
        Func<Task> act = async () => await errorOrTask.ThrowIfError();

        // Act & Assert
        await act.Should().NotThrowAsync();
    }
}