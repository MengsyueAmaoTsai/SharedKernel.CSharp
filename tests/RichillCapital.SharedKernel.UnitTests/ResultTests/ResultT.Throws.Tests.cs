using FluentAssertions;

using RichillCapital.Extensions.Monads.UnitTests.Shared;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Extensions.Monads.UnitTests;

public sealed class ResultTThrowsTests : MonadTests
{
    [Fact]
    public void ThrowIfFailure_When_IsFailure_Should_ThrowInvalidOperationExceptionWithErrorMessage()
    {
        // Arrange
        var result = TestError.ToResult<int>();
        Action act = () => result.ThrowIfFailure();

        // Act & Assert
        act.Should().Throw<InvalidOperationException>()
            .WithMessage(TestError.Message);
    }

    [Fact]
    public void ThrowIfFailure_When_IsSuccess_Should_NotThrowAnyExceptions()
    {
        // Arrange
        var result = 1.ToResult();
        Action act = () => result.ThrowIfFailure();

        // Act & Assert
        act.Should().NotThrow();
    }

    [Fact]
    public async Task ThrowIfFailureAsync_When_ResultTaskIsFailure_Should_ThrowInvalidOperationExceptionWithErrorMessage()
    {
        // Arrange
        var resultTask = Task.FromResult(TestError.ToResult<int>());
        Func<Task> act = async () => await resultTask.ThrowIfFailure();

        // Act & Assert
        await act.Should().ThrowAsync<InvalidOperationException>()
            .WithMessage(TestError.Message);
    }

    [Fact]
    public async Task ThrowIfFailureAsync_When_ResultTaskIsSuccess_Should_NotThrowAnyExceptions()
    {
        // Arrange
        var resultTask = Task.FromResult(1.ToResult());
        Func<Task> act = async () => await resultTask.ThrowIfFailure();

        // Act & Assert
        await act.Should().NotThrowAsync();
    }
}